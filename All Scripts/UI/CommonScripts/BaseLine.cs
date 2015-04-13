using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BaseLine :IProcessOperate
{
	private string beginDate;
	private string endDate;
	public string BeginDate
	{
		set
		{
			beginDate = value;
		}
		get
		{
			return beginDate;
		}
	}

	public string EndDate
	{
		set
		{
			endDate = value;
		}
		get
		{
			return endDate;
		}
	}

	public BaseLine()
	{
		BeginDate = string.Empty;
		EndDate = string.Empty;
	}

	public BaseLine(string beginDate , string endDate)
	{
		BeginDate = beginDate;
		EndDate = endDate;
	}

	public virtual void ReinforceProcess()
	{
	}
	public virtual void RaiseProcess()
	{
	}
	public virtual void AdvanceProcess()
	{
	}
	public virtual void RemoveProcess()
	{
	}
	public virtual void SealProcess()
	{
	}

	public static System.DateTime FormStringToDateTime(string date)
	{
		System.DateTime tempDate = new System.DateTime();
		tempDate = System.DateTime.Parse(date);
		return tempDate;
	}

	public static bool IsBetweenInTwoDate(string _beginDate,string _endDate,string tempDate)
	{
		System.DateTime date_begin = FormStringToDateTime(_beginDate);
		System.DateTime date_end = FormStringToDateTime(_endDate);
		System.DateTime date_temp = FormStringToDateTime(tempDate);
		if((date_begin <= date_temp) && (date_temp<= date_end))
		{
			return true;
		}
		else
			return false;
	}

	public static bool IsBeginDateLessThanEndDate(string _beginDate,string _endDate)
	{
		System.DateTime date_begin = FormStringToDateTime(_beginDate);
		System.DateTime date_end = FormStringToDateTime(_endDate);
		if(date_begin<=date_end)
			return true;
		else
			return false;
	}

	public  EveryProcessOperateName IntConvertToEnum(int iValue)
	{
		
		if(iValue <0 && iValue>=5)
			return EveryProcessOperateName.Reinforce;
		EveryProcessOperateName name = (EveryProcessOperateName)iValue;
		return name;
	}


}

public interface IProcessOperate
{
	void ReinforceProcess();
	void RaiseProcess();
	void AdvanceProcess();
	void RemoveProcess();
	void SealProcess();
}


public enum EveryProcessOperateName
{
	Reinforce,
	Raise,
	Advance,
	Remove,
	Seal
}


