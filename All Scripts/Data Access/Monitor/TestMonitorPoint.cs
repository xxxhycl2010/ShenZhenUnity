using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TestMonitorPoint : MonoBehaviour {
	public Transform tempMonitorPoint;

	List<Vector3> tempPosition = new List<Vector3>();
	// Use this for initialization

	void Start () {
		GetAllMonitorPosition ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void GetAllMonitorPosition()
	{
		 
		foreach(Transform child in tempMonitorPoint)
		{
			tempPosition.Add(child.localPosition);

		}

	}

	public Vector3 GetCorrespondPosition(int index)
	{
		int length = tempPosition.Count;
		if (index < 0 || index > length - 1)
				return Vector3.one;

		return tempPosition [index];

	}

	/*
	void OnGUI()
	{
			if (GUI.Button (new Rect (100, 100, 100, 50), "show position")) 
			{
			Debug.Log("count:"+tempPosition.Count);
				foreach(var item in tempPosition)
				{

					Debug.Log(item.ToString());
				}
			}

	}
	*/


}
