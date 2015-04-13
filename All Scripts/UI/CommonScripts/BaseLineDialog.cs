#define DEBUG
#undef TRACE

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseLineDialog : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public string FormatDateValue(string newValue)
	{
		if(newValue.Substring(newValue.Length-1,1).Equals("-")==false && newValue.Contains("-"))
		{
			return newValue;
		}
		else
			return string.Empty;
	}

	public void ConvertAllDateLabels_base(ref List<string> dateStringValues,List<UILabel> dateLabels)
	{
		dateStringValues.Clear();
		int length = dateLabels.Count;
		for(int i=0;i<length;i++)
		{
			string temp = this.FormatDateValue(dateLabels[i].text);
			dateStringValues.Add(temp);
		}
	}

	public bool IsContanisNull_base(List<string> tempList)
	{
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
	}

	public const int constLength = 8;
	public bool IsAllBeginDateLessThanEndDate_base(List<string> tempList)
	{
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
	}
}
