#define DEBUG
#undef TRACE
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Nii.JSON;

public class TestJsonNet : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()
	{
		if (GUILayout.Button("show json"))
		{
			//InitProject();
		}
	}
#if TRACE
	void InitProject()
	{
		Project project = new Project();
		{
			project.Name = "andriod";
			project.Date = System.DateTime.Now.ToString();
			project.Price = 1234.324;
			project.Sizes = new string[] { "1.2" , "2.3" , "3.5" , "4.8" };
		}
		string josnData = JsonConvert.SerializeObject(project);
		Debug.Log("json:"+josnData);
	}
#endif
}

public class Project
{
	public string Name
	{
		set;
		get;
	}
	
	public string Date
	{
		set;
		get;
	}
	
	public double Price
	{
		set;
		get;
	}
	
	public string[] Sizes
	{
		set;
		get;
	}

}
