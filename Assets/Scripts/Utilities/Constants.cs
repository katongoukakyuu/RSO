using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Constants : MonoBehaviour {

	public const string DB_NAME = "RSO";

	public const string SCENE_MAIN = "Main";

	public const int USERNAME_MIN_LENGTH = 3;
	public const int USERNAME_MAX_LENGTH = 16;
	public const int PASSWORD_MIN_LENGTH = 4;
	public const int PASSWORD_MAX_LENGTH = 16;

	public const string DB_TYPE_ACCOUNT = "account";

	public const string DB_COUCHBASE_ID = "_id";

	public const string DB_KEYWORD_TYPE = "type";
	public const string DB_KEYWORD_SUBTYPE = "subtype";
	public const string DB_KEYWORD_NAME = "name";
	public const string DB_KEYWORD_DESCRIPTION = "description";
	public const string DB_KEYWORD_CREATED_AT = "created at";

	// player document keywords
	public const string DB_KEYWORD_USERNAME = "username";
	public const string DB_KEYWORD_PASSWORD = "password";
	public const string DB_KEYWORD_EMAIL = "email";
	// end player document keywords
}
