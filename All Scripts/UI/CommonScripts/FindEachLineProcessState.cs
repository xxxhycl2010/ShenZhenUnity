#define DEBUG
#undef TRACE

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FindEachLineProcessState : MonoBehaviour {
	public ElevenLeftLineDialog  elevenLeftLineDialog;
	public ElevenRightLineDialog elevenRightLineDialog;
	public NineLeftLineDialog nineLeftLineDialog;
	public NineRightLineDialog  nineRightLineDialog;
	public SevenLeftLineDialog sevenLeftLineDialog;
	public SevenRightLineDialog sevenRightLineDialog;
	public UILabel findDateLabel;
	public const int dateMaxIndex 	= 8;
	ElevenLeftLine elevenLeftLine 	= new ElevenLeftLine();
	ElevenRightLine elevenRightLine = new ElevenRightLine();
	NineLeftLine nineLeftLine 		= new NineLeftLine();
	NineRightLine nineRightLine		= new NineRightLine();
	SevenLeftLine sevenLeftLine 	= new SevenLeftLine();
	SevenRightLine sevenRightLine 	= new SevenRightLine();
	// Use this for initialization
	void Start () {

	}

	string LabelTextConvertToStrValue(string newValue)
	{
		if(newValue.Substring(newValue.Length-1,1).Equals("-") == false && newValue.Contains("-"))
		{
			return newValue;
		}
		else
			return string.Empty;
	}




	void OnClick()
	{

		string date = LabelTextConvertToStrValue(findDateLabel.text);
		Debug.Log("date:"+ date);
		if(date.Equals(string.Empty))
			return;
#if DEBUG
		Debug.Log("eleven left line:");
		ElevenLeftLineOperate(date);

		Debug.Log("eleven right line:");
		ElevenRightLineOperate(date);

		Debug.Log("nine left line:");
		NineLeftLineOperate(date);

		Debug.Log("nine right line:");
		NineRightLineOperate(date);

		Debug.Log("seven left line:");
		SevenLeftLineOperate(date);

		Debug.Log("seven right line:");
		SevenRightLineOperate(date);

#endif
	}

	public List<int> GetEachLineCurrentExecuteProcess(List<string> dateList,string findDate)
	{
		List<int> executeProcess = new List<int>();
		for(int i=0;i<=dateMaxIndex;i+=2)
		{
			if(BaseLine.IsBetweenInTwoDate(dateList[i],dateList[i+1],findDate))
			{
				executeProcess.Add(i/2);
			}
		}
		return executeProcess;
	}

	 #region code need refactoring,improving the design of existing code

	void ElevenLeftLineOperate(string date)
	{
		elevenLeftLine.ClearProcessIndexOfEleven();
		if(elevenLeftLineDialog.IsContanisNull())
			return;
#if DEBUG
		if(!elevenLeftLineDialog.IsAllBeginDateLessThanEndDate())
			return;
#endif
		#if DEBUG
		List<string> tempList = elevenLeftLineDialog.GetDateList();
		List<int> tempProcessIndex = GetEachLineCurrentExecuteProcess(tempList,date);
		elevenLeftLine.processIndex_eleven = tempProcessIndex;
		elevenLeftLine.StartShowElevenExecute(elevenLeftLine.GetProcessIndexOfEleven());
		#endif

	}

	void ElevenRightLineOperate(string date)
	{
		elevenRightLine.ClearProcessIndexOfEleven();
		if(elevenRightLineDialog.IsContanisNull())
			return;
		if(!elevenRightLineDialog.IsAllBeginDateLessThanEndDate())
			return;
		List<string> tempList = elevenRightLineDialog.GetDateList();
		List<int> tempProcessIndex = GetEachLineCurrentExecuteProcess(tempList,date);
		elevenRightLine.processIndex_eleven = tempProcessIndex;
		elevenRightLine.StartShowElevenExecute(elevenRightLine.GetProcessIndexOfEleven());

	}

	void NineLeftLineOperate(string date)
	{
		nineLeftLine.ClearProcessIndexOfNine();
		if(nineLeftLineDialog.IsContanisNull())
			return;
		if(!elevenRightLineDialog.IsAllBeginDateLessThanEndDate())
			return;
		List<string> tempList = nineLeftLineDialog.GetDateList();
		List<int> tempProcessIndex  = GetEachLineCurrentExecuteProcess(tempList,date);
		nineLeftLine.processIndex_nine = tempProcessIndex;
		nineLeftLine.StartShowNineExecute(nineLeftLine.GetProcessIndexOfNine());
	}


	void NineRightLineOperate(string date)
	{
		nineRightLine.ClearProcessIndexOfNine();

		if(nineRightLineDialog.IsContanisNull())
			return;
#if DEBUG
		if(!nineRightLineDialog.IsAllBeginDateLessThanEndDate())
			return;
#endif
		#if DEBUG
		List<string> tempList = nineRightLineDialog.GetDateList();
		List<int> tempProcessIndex = GetEachLineCurrentExecuteProcess(tempList,date);
		nineRightLine.processIndex_nine = tempProcessIndex;
		nineRightLine.StartShowNineExecute(nineRightLine.GetProcessIndexOfNine());
		#endif
		
	}

	void SevenLeftLineOperate(string date)
	{
		sevenLeftLine.ClearProcessIndexOfSeven();
		if(sevenLeftLineDialog.IsContanisNull())
		{
			return;
		}
		if(!sevenLeftLineDialog.IsAllBeginDateLessThanEndDate())
			return;
		List<string> tempList = sevenLeftLineDialog.GetDateList();
		List<int> tempProcessIndex = GetEachLineCurrentExecuteProcess(tempList,date);
		sevenLeftLine.processIndex_seven = tempProcessIndex;
		sevenLeftLine.StartShowSevenExecute(sevenLeftLine.GetProcessIndexOfSeven());
	}

	void SevenRightLineOperate(string date)
	{
		sevenRightLine.ClearProcessIndexOfSeven();
		if(sevenRightLineDialog.IsContanisNull())
			return;
		if(!sevenRightLineDialog.IsAllBeginDateLessThanEndDate())
			return;
		List<string> tempList = sevenRightLineDialog.GetDateList();
		List<int> tempProcessIndex = GetEachLineCurrentExecuteProcess(tempList,date);
		sevenRightLine.processIndex_seven = tempProcessIndex;
		sevenRightLine.StartShowSevenExecute(sevenRightLine.GetProcessIndexOfSeven());
	}

	#endregion



}
