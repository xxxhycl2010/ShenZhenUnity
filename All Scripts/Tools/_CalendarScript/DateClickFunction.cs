using UnityEngine;
using System.Collections;
using System;

public class DateClickFunction : MonoBehaviour {

	public GameObject m_lastMonth;
	public GameObject m_nextMonth;
	public UILabel m_monthLabel;

	public GameObject m_lastYear;
	public GameObject m_nextYear;
	public UILabel m_yearLabel;

	public GameObject m_sureButton;

	int m_dtYear,m_dtMonth;

	public string m_yearText,m_monthText,m_dayText,m_weekText;

	bool b_changed = false;

	public GameObject m_dayObj;
	public GameObject m_dayParent;

	public UILabel m_sureButtonLabel;

	public string m_sureButtonLabelChanged;

	System.String str;
	DateTime dt;

	void Awake ()
	{
		#region NGUI Button Listerer Funnction
		UIEventListener.Get(m_nextMonth).onClick = ButtonNextMonth;
		UIEventListener.Get(m_lastMonth).onClick = ButtonLastMonth;

		UIEventListener.Get(m_lastYear).onClick = ButtonLastYear;
		UIEventListener.Get(m_nextYear).onClick = ButtonNextYear;

		UIEventListener.Get(m_sureButton).onClick = ButtonSureButton;
		#endregion


	}
	// Use this for initialization
	void Start () {
		m_dtYear = DateTime.Now.Year;
		m_dtMonth = DateTime.Now.Month;
		m_yearLabel.text = m_dtYear.ToString();
		m_monthLabel.text = m_dtMonth.ToString();
		DateDestroy();
		DateRefresh();
//		print(m_dtMonth.ToString() + m_dtYear.ToString());
	
	}
	
	// Update is called once per frame
	void Update () {

		if(b_changed == true)
		{
			//Chnage DateLabel
			m_yearLabel.text = m_dtYear.ToString();
			m_monthLabel.text = m_dtMonth.ToString();
//			print("changed");
			DateDestroy();
			DateRefresh();

			b_changed = false; 
		}


	
	}

	#region NGUI Button Click Function
	void ButtonNextMonth (GameObject button)
	{
//		Debug.Log("GameObject is "+button.name);
		m_dtMonth++;
		if(m_dtMonth > 12)
		{
			m_dtYear++;
			m_dtMonth = 1;
		}
		b_changed = true;
	}

	void ButtonLastMonth (GameObject button)
	{
//		Debug.Log("Gameobject is" +button.name);
		m_dtMonth--;
		if(m_dtMonth <1)
		{
			m_dtYear--;
			m_dtMonth = 12;
		}
		b_changed = true;
	}

	void ButtonNextYear (GameObject button)
	{
//		Debug.Log("Gameobject is"+ button.name);
		m_dtYear++;
		b_changed = true;
	}

	void ButtonLastYear (GameObject button)
	{
//		Debug.Log("Gameobject is "+ button.name);
		m_dtYear--;
		b_changed = true;
	}

	void ButtonSureButton (GameObject button)
	{
//		Debug.Log("Gameobject is "+ button.name);
		m_sureButtonLabel.text = m_yearText + "-" + m_monthText + "-" + m_dayText;
		m_sureButtonLabelChanged = changeDateFormat(m_sureButtonLabel.text);

	}
	
	#endregion

	#region Date Refresh
	void DateRefresh ()
	{
		//the week of first day in one month
		dt = Convert.ToDateTime(m_dtYear.ToString() + "-" + m_dtMonth.ToString() + "-1");
		str = dt.DayOfWeek.ToString();
		//print(str);
		//the days in one month
		int daysInMonth = DateTime.DaysInMonth(m_dtYear,m_dtMonth);
		//print(daysInMonth.ToString());

		//Add Null Date
		switch (str)
		{
		case ("Monday"):
			//print("1");
			break;
		case ("Tuesday"):
			for(int i = 0; i < 1; i++)
			{
				GameObject Clone = (GameObject)Instantiate(m_dayObj);
				Clone.SetActive(true);
				Clone.GetComponent<UILabel>().text = "";
				Clone.name = "0";
				Clone.collider.enabled = false;
				Clone.transform.parent = m_dayParent.transform;
				Clone.transform.localScale = new Vector3(1,1,1);
			}
			break;
		case ("Wednesday"):
			for(int i = 0; i < 2; i++)
			{
				GameObject Clone = (GameObject)Instantiate(m_dayObj);
				Clone.SetActive(true);
				Clone.GetComponent<UILabel>().text = "";
				Clone.name = "0";
				Clone.collider.enabled = false;
				Clone.transform.parent = m_dayParent.transform;
				Clone.transform.localScale = new Vector3(1,1,1);
			}
			break;
		case ("Thursday"):
			for(int i = 0; i < 3; i++)
			{
				GameObject Clone = (GameObject)Instantiate(m_dayObj);
				Clone.SetActive(true);
				Clone.GetComponent<UILabel>().text = "";
				Clone.name = "0";
				Clone.collider.enabled = false;
				Clone.transform.parent = m_dayParent.transform;
				Clone.transform.localScale = new Vector3(1,1,1);
			}
			break;
		case ("Friday"):
			for(int i = 0; i < 4; i++)
			{
				GameObject Clone = (GameObject)Instantiate(m_dayObj);
				Clone.SetActive(true);
				Clone.GetComponent<UILabel>().text = "";
				Clone.name = "0";
				Clone.collider.enabled = false;
				Clone.transform.parent = m_dayParent.transform;
				Clone.transform.localScale = new Vector3(1,1,1);
			}
			break;
		case("Saturday"):
			for(int i = 0; i < 5; i++)
			{
				GameObject Clone = (GameObject)Instantiate(m_dayObj);
				Clone.SetActive(true);
				Clone.GetComponent<UILabel>().text = "";
				Clone.name = "0";
				Clone.collider.enabled = false;
				Clone.transform.parent = m_dayParent.transform;
				Clone.transform.localScale = new Vector3(1,1,1);
			}
			break;
		case("Sunday"):
			for(int i = 0; i < 6; i++)
			{
				GameObject Clone = (GameObject)Instantiate(m_dayObj);
				Clone.SetActive(true);
				Clone.GetComponent<UILabel>().text = "";
				Clone.name = "0";
				Clone.collider.enabled = false;
				Clone.transform.parent = m_dayParent.transform;
				Clone.transform.localScale = new Vector3(1,1,1);
			}
			break;
		}

		for (int i = 0;i < daysInMonth;i++)
		{
			GameObject Clone = (GameObject)Instantiate(m_dayObj);
			Clone.SetActive(true);
			Clone.name = (i+1).ToString();
			Clone.GetComponent<UILabel>().text = (i+1).ToString();
			Clone.transform.parent = m_dayParent.transform;
			Clone.transform.localScale = Vector3.one;
		}

		m_yearText = m_dtYear.ToString();
		m_monthText = m_dtMonth.ToString();

		m_dayParent.GetComponent<UITable>().Reposition();

	

	}
	#endregion

	#region Destroy Date
	public void DateDestroy()
	{
		foreach (Transform child in m_dayParent.transform)
		{
			child.gameObject.SetActive(false);
		}
		
	}
	#endregion

	#region Change Date Format
	string changeDateFormat(string date)
	{
		string[] dayinfo;
		dayinfo = date.Split('-');
		//		foreach(var s in dayinfo)
		//			Debug.Log(s);
		for(int i=1;i<3;i++)
		{
			if(float.Parse(dayinfo[i]) < 10)
			{
				dayinfo[i] = dayinfo[i].Insert(0,"0");
			}
			
		}
		string strv;	
		strv = "";
		foreach(string str in dayinfo)
		{
			strv += str;
		}
		//		Debug.Log(strv);
		return strv;
	}
	#endregion

}
