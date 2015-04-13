using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ElevenLeftLine : BaseLine
{
	
	public ElevenLeftLine():base()
	{

	}

	public ElevenLeftLine(string _beginData,string _endDate):base(_beginData,_endDate)
	{
	}

	public override void ReinforceProcess ()
	{
		Debug.Log("eleven left lien reinforce process");
	}

	public override void RaiseProcess ()
	{
		Debug.Log("eleven left line raise process");
	}

	public override void AdvanceProcess ()
	{
		Debug.Log("eleven left line advance process");
	}

	public override void RemoveProcess ()
	{
		Debug.Log("eleven left line remove process");
	}

	public override void SealProcess ()
	{
		Debug.Log("eleven left line seal process");
	}
#if TRACE
	public delegate void ProcessOperate();
	ProcessOperate executeProcess;
#endif

//	BaseLine iProcessOperate = this;
	public void StartExecuteProcess(EveryProcessOperateName processName)
	{
#if TRACE
		switch(processName)
		{
		case EveryProcessOperateName.Reinforce:
			executeProcess = this.ReinforceProcess;
			break;
		case EveryProcessOperateName.Raise:
			executeProcess = this.RaiseProcess;
			break;
		case EveryProcessOperateName.Advance:
			executeProcess = this.AdvanceProcess;
			break;
		case EveryProcessOperateName.Remove:
			executeProcess = this.RemoveProcess;
			break;
		case EveryProcessOperateName.Seal:
			executeProcess = this.SealProcess;
			break;
		}
		executeProcess();
#endif
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
#if TRACE
		for(int i=0;i<tempList.Count;i++)
		{
			EveryProcessOperateName name = base.IntConvertToEnum(tempList[i]);
			StartExecuteProcess(name);
		}
#endif
		ProcessOperate_common operate = this.StartExecuteProcess;
		CommonOperateOfEachLine.StartShowElevenExecute_common(tempList,operate);
	}







}
