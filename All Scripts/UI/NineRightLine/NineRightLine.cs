using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NineRightLine : BaseLine {
	public NineRightLine():base()
	{
		
	}
	
	public NineRightLine(string _beginData,string _endDate):base(_beginData,_endDate)
	{
	}
	
	public override void ReinforceProcess ()
	{
		Debug.Log("nine right lien reinforce process");
	}
	
	public override void RaiseProcess ()
	{
		Debug.Log("nine right line raise process");
	}
	
	public override void AdvanceProcess ()
	{
		Debug.Log("nine right line advance process");
	}
	
	public override void RemoveProcess ()
	{
		Debug.Log("nine right line remove process");
	}
	
	public override void SealProcess ()
	{
		Debug.Log("nine right line seal process");
	}
	
//	public delegate void ProcessOperate();
//	ProcessOperate executeProcess;

	public void StartExecuteProcess(EveryProcessOperateName processName)
	{
		
//		switch(processName)
//		{
//		case EveryProcessOperateName.Reinforce:
//			executeProcess = this.ReinforceProcess;
//			break;
//		case EveryProcessOperateName.Raise:
//			executeProcess = this.RaiseProcess;
//			break;
//		case EveryProcessOperateName.Advance:
//			executeProcess = this.AdvanceProcess;
//			break;
//		case EveryProcessOperateName.Remove:
//			executeProcess = this.RemoveProcess;
//			break;
//		case EveryProcessOperateName.Seal:
//			executeProcess = this.SealProcess;
//			break;
//		}
//		executeProcess();

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
//		for(int i=0;i<tempList.Count;i++)
//		{
//			EveryProcessOperateName name = base.IntConvertToEnum(tempList[i]);
//			StartExecuteProcess(name);
//		}

		ProcessOperate_common operate = this.StartExecuteProcess;
		CommonOperateOfEachLine.StartShowElevenExecute_common(tempList,operate);
	}
	
	
	


}
