using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NineRightLineDialog : MonoBehaviour {
	public List<UILabel> dateLabels = new List<UILabel>();
	List<string> dateStringValues = new List<string>();
	public GameObject nineSureButton;
	public BaseLineDialog baseLineDialog;
	// Use this for initialization
	void Start () {
		
		UIEventListener.Get(nineSureButton).onClick = StartConvert;
	}
	
	void StartConvert(GameObject go)
	{
		ConvertAllDateLabels();
	}

	public void ConvertAllDateLabels()
	{

		baseLineDialog.ConvertAllDateLabels_base(ref dateStringValues,dateLabels);
	}
	
	public List<string> GetDateList()
	{
		return dateStringValues;
	}
	
	public bool IsContanisNull()
	{

		bool tempflag = baseLineDialog.IsContanisNull_base(GetDateList());
		return tempflag;
	}

	public bool IsAllBeginDateLessThanEndDate()
	{
		bool tempflag = baseLineDialog.IsAllBeginDateLessThanEndDate_base(GetDateList());
		return tempflag;
	}

}
