using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Couchbase.Lite;

public class DatabaseManager : MonoBehaviour {

	private Manager manager;
	private Database db;

	private static DatabaseManager instance;
	private DatabaseManager() {}

	public static DatabaseManager Instance {
		get {
			if(instance == null) {
				instance = (DatabaseManager)GameObject.FindObjectOfType(typeof(DatabaseManager));
			}
			return instance;
		}
	}

	void Start () {
		DontDestroyOnLoad(this);
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
			return;
		}
		manager = Manager.SharedInstance;
		db = manager.GetDatabase(Constants.DB_NAME);
		db.Changed += (sender, e) => {
			var changes = e.Changes.ToList();
			foreach (DocumentChange change in changes) {
				print("Document " + change.DocumentId + " changed");
			}
		};

		// initialize views
		// account username-password
		View viewAccount = db.GetView(Constants.DB_TYPE_ACCOUNT);
		viewAccount.SetMap ((doc, emit) => {
			if(doc[Constants.DB_KEYWORD_TYPE].ToString () == Constants.DB_TYPE_ACCOUNT)
				emit(doc[Constants.DB_KEYWORD_USERNAME], doc[Constants.DB_KEYWORD_PASSWORD]);
		}, "1");

		// initialize database, use Unity inspector to change value in GameManager
		if (GameManager.Instance.initializeDatabase) {
			InitializeDatabase();
		}
	}

	private void InitializeDatabase() {
		print(SaveEntry(GameManager.Instance.CreateAccount ("test", "test@test.com")));

		// Reimu cards
		print(SaveEntry (GameManager.Instance.CreateCharacterCard(
			"0100",
			"Reimu Hakurei",
			"The Wonderful Shrine Maiden of Paradise",
			new List<string>() {
				"Reimu",
				"Human",
				"Border Manipulator"
			},
			19, 3, 3,
			"<color=blue>[Battle] 2 SP</color>\n"+
			"<color=red>One of your Spells</red> gains <color=green>Focused Movement (1)</color> until end of phase. (Once per phase)",
			"Anyways, I have to punish you a little."
		)));
		print(SaveEntry(GameManager.Instance.CreateSpellCard(
			"0101",
			"Dream Sign \"Duplex Barrier\"",
			new List<string>() {
				"Reimu",
				"Spread",
			},
			new List<Dictionary<string, int>>() {
				new Dictionary<string, int>() {
					{"Reimu", 1}
				}
			},
			1, 1, 4, 1,
			"<color=blue>[Battle/Intercept] Passive</color>\n"+
			"<color=red>This Spell</red> gains <color=green>Protection (1)</color>.",
			""
		)));
		// End Reimu cards

	}

	public IDictionary<string,object> SaveEntry(Dictionary<string, object> dic) {
		Document d = db.CreateDocument();
		var properties = dic;
		var rev = d.PutProperties(properties);
		if (rev != null) {
			print ("Entry saved!");
			return rev.Properties;
		}
		return null;
	}

	public IDictionary<string, object> LoadPlayer(string name) {
		var query = db.GetView (Constants.DB_TYPE_ACCOUNT).CreateQuery();
		var rows = query.Run ();
		foreach(var row in rows) {
			if(row.Key.ToString() == name || row.DocumentId == name) {
				print ("player found!");
				return db.GetDocument (row.DocumentId).Properties;
			}
		}
		return null;
	}

	public IDictionary<string, object> LoadPlayer(string name, string password) {
		var query = db.GetView (Constants.DB_TYPE_ACCOUNT).CreateQuery();
		var rows = query.Run ();
		foreach(var row in rows) {
			if(row.Key.ToString() == name && row.Value.ToString() == password) {
				print ("player found!");
				return db.GetDocument (row.DocumentId).Properties;
			}
		}
		return null;
	}

	public void SetPlayer(string id) {
		PlayerManager.Instance.player = db.GetDocument (id).Properties;
	}

	public void EditChicken(IDictionary<string, object> dic) {
		Document d = db.GetDocument(dic[Constants.DB_COUCHBASE_ID].ToString());
		d.Update((UnsavedRevision newRevision) => {
			var properties = newRevision.Properties;
			properties[Constants.DB_KEYWORD_NAME] = dic[Constants.DB_KEYWORD_NAME].ToString();
			return true;
		});
	}
}
