using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GameManager : MonoBehaviour {

	public bool initializeDatabase = false;

	private static GameManager instance;
	private GameManager() {}

	public static GameManager Instance {
		get {
			if(instance == null) {
				instance = (GameManager)GameObject.FindObjectOfType(typeof(GameManager));
			}
			return instance;
		}
	}

	void Start() {
		DontDestroyOnLoad(this);
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
			return;
		}
	}

	public Dictionary<string, object> CreateAccount(string username, string email) {
		Dictionary<string, object> d = new Dictionary<string, object> () {
			{Constants.DB_KEYWORD_TYPE, Constants.DB_TYPE_ACCOUNT},
			{Constants.DB_KEYWORD_USERNAME, username},
			{Constants.DB_KEYWORD_PASSWORD, "test"},
			{Constants.DB_KEYWORD_EMAIL, email},
			{Constants.DB_KEYWORD_CREATED_AT, System.DateTime.Now.ToUniversalTime().ToString ()}
		};
		return d;
	}

	public Dictionary<string, object> CreateCharacterCard(string name, string title,
	                                                      List<string> designations,
	                                                      int hp, int ev, int bv,
	                                                      string text, string flavor) {
		Dictionary<string, object> d = new Dictionary<string, object> () {
			{Constants.DB_KEYWORD_TYPE, Constants.DB_TYPE_CARD},
			{Constants.DB_KEYWORD_SUBTYPE, Constants.DB_TYPE_CARD_CHARACTER},
			{Constants.DB_KEYWORD_NAME, name},
			{Constants.DB_KEYWORD_TITLE, title},
			{Constants.DB_KEYWORD_DESIGNATIONS, designations},
			{Constants.DB_KEYWORD_HP, hp},
			{Constants.DB_KEYWORD_EV, ev},
			{Constants.DB_KEYWORD_BV, bv},
			{Constants.DB_KEYWORD_TEXT, text},
			{Constants.DB_KEYWORD_FLAVOR, flavor},
			{Constants.VERSION, Constants.VERSION},
			{Constants.DB_KEYWORD_CREATED_AT, System.DateTime.Now.ToUniversalTime().ToString ()}
		};
		return d;
	}
}
