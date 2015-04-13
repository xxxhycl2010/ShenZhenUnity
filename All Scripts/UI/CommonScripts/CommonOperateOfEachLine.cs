using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void ProcessOperate_common(EveryProcessOperateName processName);

public class CommonOperateOfEachLine
{


	public static void StartExecuteProcess_common(EveryProcessOperateName processName,BaseLine operate)
	{
		switch(processName)
		{
		case EveryProcessOperateName.Reinforce:
			operate.ReinforceProcess();
			break;
		case EveryProcessOperateName.Raise:
			operate.RaiseProcess();
			break;
		case EveryProcessOperateName.Advance:
			operate.AdvanceProcess();
			break;
		case EveryProcessOperateName.Remove:
			operate.RemoveProcess();
			break;
		case EveryProcessOperateName.Seal:
			operate.SealProcess();
			break;
		}

	}

	public static void StartShowElevenExecute_common(List<int> tempList,ProcessOperate_common operate)
	{
		BaseLine baseLine = new BaseLine();
		for(int i=0;i<tempList.Count;i++)
		{
			EveryProcessOperateName name = baseLine.IntConvertToEnum(tempList[i]);
			operate(name);
		}
	}



}
