using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Constants : MonoBehaviour {

	public const string VERSION = "0.1";

	public const string DB_NAME = "RSO";

	public const string SCENE_MAIN = "Main";

	public const int USERNAME_MIN_LENGTH = 3;
	public const int USERNAME_MAX_LENGTH = 16;
	public const int PASSWORD_MIN_LENGTH = 4;
	public const int PASSWORD_MAX_LENGTH = 16;

	public const string DB_TYPE_ACCOUNT = "account";
	public const string DB_TYPE_CARD = "card";
	public const string DB_TYPE_CARD_CHARACTER = "character card";
	public const string DB_TYPE_CARD_SPELL = "spell card";
	public const string DB_TYPE_CARD_SUPPORT = "support card";
	public const string DB_TYPE_CARD_EVENT = "event card";

	public const string DB_COUCHBASE_ID = "_id";

	public const string DB_KEYWORD_ID = "id";
	public const string DB_KEYWORD_TYPE = "type";
	public const string DB_KEYWORD_SUBTYPE = "subtype";
	public const string DB_KEYWORD_NAME = "name";
	public const string DB_KEYWORD_DESCRIPTION = "description";
	public const string DB_KEYWORD_CREATED_AT = "created at";
	public const string DB_KEYWORD_VERSION = "version";

	// player document keywords
	public const string DB_KEYWORD_USERNAME = "username";
	public const string DB_KEYWORD_PASSWORD = "password";
	public const string DB_KEYWORD_EMAIL = "email";
	// end player document keywords

	// card document keywords
	public const string DB_KEYWORD_DESIGNATIONS = "designations";
	public const string DB_KEYWORD_REQUIREMENTS = "requirements";
	public const string DB_KEYWORD_TEXT = "text";
	public const string DB_KEYWORD_FLAVOR = "flavor";
	public const string DB_KEYWORD_SP = "sp";
	public const string DB_KEYWORD_LEVEL = "level";
	// end card document keywords

	// character card document keywords
	public const string DB_KEYWORD_TITLE = "title";
	public const string DB_KEYWORD_HP = "hp";
	public const string DB_KEYWORD_EV = "ev";
	public const string DB_KEYWORD_BV = "bv";
	// character end card document keywords

	// spell card document keywords
	public const string DB_KEYWORD_AV = "av";
	public const string DB_KEYWORD_IV = "iv";
	public const string DB_KEYWORD_HV = "hv";
	public const string DB_KEYWORD_SPELL_TYPE = "spell type";
	// spell end card document keywords
}
