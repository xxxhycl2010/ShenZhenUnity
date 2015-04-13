#define DEBUG
#undef TRACE

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ElevenLeftLineDialog : MonoBehaviour {
	public List<UILabel> dateLabels = new List<UILabel>();
	List<string> dateStringValues = new List<string>();
	public GameObject elevenSureButton;
	public BaseLineDialog baseLineDialog;
	// Use this for initialization
	void Start () {

		UIEventListener.Get(elevenSureButton).onClick = StartConvert;
	
	}

	void StartConvert(GameObject go)
	{
		ConvertAllDateLabels();
	}

	#region zui chu code
#if TRACE
	string FormatDateValue(string newValue)
	{
		if(newValue.Substring(newValue.Length-1,1).Equals("-")==false && newValue.Contains("-"))
		{
			return newValue;
		}
		else
			return string.Empty;
	}
#endif
	#endregion

	public void ConvertAllDateLabels()
	{
		#region zui chu code
#if TRACE
		dateStringValues.Clear();
		int length = dateLabels.Count;
		for(int i=0;i<length;i++)
		{
			string temp = FormatDateValue(dateLabels[i].text);
			dateStringValues.Add(temp);
		}
#endif 
#endregion

		baseLineDialog.ConvertAllDateLabels_base(ref dateStringValues,dateLabels);
	}

	public List<string> GetDateList()
	{
		return dateStringValues;
	}

	public bool IsContanisNull()
	{
		#region zui chu code
#if TRACE
		List<string> tempList= GetDateList();
		int length = tempList.Count;
		bool flag = false;
		for(int i=0;i<length;i++)
		{
			if(tempList[i] == string.Empty)
			{
				flag = true;
				break;
			}
		}
		return flag;
#endif
		#endregion

		bool flag = baseLineDialog.IsContanisNull_base(GetDateList());
		return flag;
	}
//	public const int constLength = 8;
	public bool IsAllBeginDateLessThanEndDate()
	{
#region zui chu code
#if TRACE
		List<string> tempList = GetDateList();

//		foreach(var item in tempList)
//			Debug.Log(item);

	
		bool flag = true;
		for(int i=0;i<=constLength;i+=2)
		{
			if(!BaseLine.IsBeginDateLessThanEndDate(tempList[i],tempList[i+1]))
			{
				flag = false;
				break;
			}
		}
		return flag;
#endif
#endregion

		bool flag = baseLineDialog.IsAllBeginDateLessThanEndDate_base(GetDateList());
		return flag;
	}

	#region test code

	void OnGUI()
	{
#if tr
		if(GUI.Button(new Rect(100,100,100,50),"show date"))
		{
			List<string> temp = GetDateList();
			foreach(var item in temp)
			{
				Debug.Log(item);
			}
		}
#endif

#if TRACE
		if(GUI.Button(new Rect(100,200,100,50),"test less than"))
		{
			string str1 = "2014-1-3";
			string str2 = "2014-01-05";

			Debug.Log(BaseLine.IsBeginDateLessThanEndDate(str1,str2));
		}

		if(GUI.Button(new Rect(100,300,100,50),"test all less than"))
		{
			Debug.Log(this.IsAllBeginDateLessThanEndDate());
		}
#endif
	}

	#endregion


}


