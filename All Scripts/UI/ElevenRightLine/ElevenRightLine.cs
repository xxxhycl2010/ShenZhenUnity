using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ElevenRightLine : BaseLine {

	public ElevenRightLine():base()
	{}
	
	public ElevenRightLine(string _beginDate,string _endDate):base(_beginDate,_endDate)
	{}
	
	public override void ReinforceProcess ()
	{
		Debug.Log("eleven right lien reinforce process");
	}
	
	public override void RaiseProcess ()
	{
		Debug.Log("eleven right line raise process");
	}
	
	public override void AdvanceProcess ()
	{
		Debug.Log("eleven right line advance process");
	}
	
	public override void RemoveProcess ()
	{
		Debug.Log("eleven right line remove process");
	}
	
	public override void SealProcess ()
	{
		Debug.Log("eleven right line seal process");
	}
	
	public void StartExecuteProcess(EveryProcessOperateName processName)
	{
		
		CommonOperateOfEachLine.StartExecuteProcess_common(processName,this);
	}
	
	public List<int> processIndex_eleven = new List<int>();
	
	
	public void ClearProcessIndexOfEleven()
	{
		processIndex_eleven.Clear();
	}
	
	public List<int> GetProcessIndexOfEleven()
	{
		return processIndex_eleven;
	}
	
	public void StartShowElevenExecute(List<int> tempList)
	{
		ProcessOperate_common operate = this.StartExecuteProcess;
		CommonOperateOfEachLine.StartShowElevenExecute_common(tempList,operate);
	}
	

}
