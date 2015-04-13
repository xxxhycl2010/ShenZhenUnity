using UnityEngine;
using System.Collections;
using System;

public class DateSelectedDay : MonoBehaviour {

	public DateClickFunction c_dateClickFunction;

	// Use this for initialization
	void Start () {
		if((c_dateClickFunction.m_yearText + "-" + c_dateClickFunction.m_monthText+ "-" + gameObject.name) == c_dateClickFunction.m_sureButtonLabel.text)
		{
			//			print("Toggle");
			gameObject.GetComponent<UIToggle>().value = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick ()
	{
		//Debug.Log(gameObject.name);
		c_dateClickFunction.m_dayText = gameObject.name;
		c_dateClickFunction.m_weekText = Convert.ToDateTime(c_dateClickFunction.m_yearText + "-" + c_dateClickFunction.m_monthText + "-" + c_dateClickFunction.m_dayText).DayOfWeek.ToString();
	}
}
