﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SevenLeftLineDialog : MonoBehaviour {
	public List<UILabel> dateLabels = new List<UILabel>();
	List<string> dateStringValues = new List<string>();
	public GameObject sevenLeftSureButton;
	public BaseLineDialog baseLineDialog;
	// Use this for initialization
	void Start () {
		
		UIEventListener.Get(sevenLeftSureButton).onClick = StartConvert;
		
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
		
		bool flag = baseLineDialog.IsContanisNull_base(GetDateList());
		return flag;
	}
	
	public bool IsAllBeginDateLessThanEndDate()
	{
		bool flag = baseLineDialog.IsAllBeginDateLessThanEndDate_base(GetDateList());
		return flag;
	}
}
