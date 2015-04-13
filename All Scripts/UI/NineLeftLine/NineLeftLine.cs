using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NineLeftLine : BaseLine {
	public NineLeftLine():base()
	{}
	
	public NineLeftLine(string _beginDate,string _endDate):base(_beginDate,_endDate)
	{}
	
	public override void ReinforceProcess ()
	{
		Debug.Log("nine left lien reinforce process");
	}
	
	public override void RaiseProcess ()
	{
		Debug.Log("nine left line raise process");
	}
	
	public override void AdvanceProcess ()
	{
		Debug.Log("nine left line advance process");
	}
	
	public override void RemoveProcess ()
	{
		Debug.Log("nine left line remove process");
	}
	
	public override void SealProcess ()
	{
		Debug.Log("nine left line seal process");
	}
	
	public void StartExecuteProcess(EveryProcessOperateName processName)
	{
		
		CommonOperateOfEachLine.StartExecuteProcess_common(processName,this);
	}
	
	public List<int> processIndex_nine = new List<int>();
	
	
	public void ClearProcessIndexOfNine()
	{
		processIndex_nine.Clear();
	}
	
	public List<int> GetProcessIndexOfNine()
	{
		return processIndex_nine;
	}
	
	public void StartShowNineExecute(List<int> tempList)
	{
		ProcessOperate_common operate = this.StartExecuteProcess;
		CommonOperateOfEachLine.StartShowElevenExecute_common(tempList,operate);
	}
	
	

}
