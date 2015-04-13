using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SevenRightLine : BaseLine
{
	public SevenRightLine():base()
	{}

	public SevenRightLine(string _beginDate,string _endDate):base(_beginDate,_endDate)
	{}

	public override void ReinforceProcess ()
	{
		Debug.Log("seven right lien reinforce process");
	}
	
	public override void RaiseProcess ()
	{
		Debug.Log("seven right line raise process");
	}
	
	public override void AdvanceProcess ()
	{
		Debug.Log("seven right line advance process");
	}
	
	public override void RemoveProcess ()
	{
		Debug.Log("seven right line remove process");
	}
	
	public override void SealProcess ()
	{
		Debug.Log("seven right line seal process");
	}

	public void StartExecuteProcess(EveryProcessOperateName processName)
	{
	
		CommonOperateOfEachLine.StartExecuteProcess_common(processName,this);
	}
	
	public List<int> processIndex_seven = new List<int>();
	
	
	public void ClearProcessIndexOfSeven()
	{
		processIndex_seven.Clear();
	}
	
	public List<int> GetProcessIndexOfSeven()
	{
		return processIndex_seven;
	}
	
	public void StartShowSevenExecute(List<int> tempList)
	{
		ProcessOperate_common operate = this.StartExecuteProcess;
		CommonOperateOfEachLine.StartShowElevenExecute_common(tempList,operate);
	}
	
	

}
