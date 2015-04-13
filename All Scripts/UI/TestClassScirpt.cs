#define DEBUG
#undef UNDEBUG
using UnityEngine;
using System.Collections;


public class TestClassScirpt : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
#if TRACE
		if(GUILayout.Button("show date"))
		{
			ElevenLeftLine obj = new ElevenLeftLine("2015-01-01","2015-02-26");
			Debug.Log("eleven begin date:"+obj.BeginDate);
			Debug.Log("eleven end date:"+ obj.EndDate);
		}
		if(GUILayout.Button("compare date"))
		{
			TestDateTimeCompare();
		}
		if(GUILayout.Button("execute process"))
		{
			EveryProcessOperateName name = EveryProcessOperateName.Advance;
			ElevenLeftLine eleven = new ElevenLeftLine();
			eleven.StartExecuteProcess(name);
		}
#endif
	}

	void TestDateTimeCompare()
	{
		System.DateTime date1 = new System.DateTime();
		System.DateTime date2 = new System.DateTime();
		date1 = System.DateTime.Parse("2014-1-1");
		date2 = System.DateTime.Parse("2014-01-01");
		Debug.Log(date1==date2);
	}



}
