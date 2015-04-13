using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateJianCeDian : MonoBehaviour
{
	public ReceiveMessageFormWinForm receiveMessageFormWinForm;
	public Transform pointsParent;
	Ray ray;
	RaycastHit hit;
	GameObject typeOneParent;		//red
	GameObject typeTwoParent;		//green
	GameObject typeThreeParent;		//blue
	GameObject typeFourParent;		//white
	GameObject typeFiveParent;		//Yellow

	List<GameObject> typeOneObjsList = new List<GameObject>();
	List<GameObject> typeTwoObjsList = new List<GameObject>();
	List<GameObject> typeThreeObjsList = new List<GameObject>();
	List<GameObject> typeFourObjsList = new List<GameObject>();
	List<GameObject> typeFiveObjsList = new List<GameObject>();

	//List<JianCeDian> AllJianCeDianInfo = new List<JianCeDian>();

	List<GameObject> typeParentsList = new List<GameObject>();
	// Use this for initialization
	void Start()
	{
		typeOneParent = new GameObject("typeOneParent");
		typeTwoParent = new GameObject("typeTwoParent");
		typeThreeParent = new GameObject("typeThreeParent");
		typeFourParent = new GameObject("typeFourParent");
		typeFiveParent = new GameObject("typeFiveParent");

		typeOneParent.transform.parent = pointsParent;
		typeTwoParent.transform.parent = pointsParent;
		typeThreeParent.transform.parent = pointsParent;
		typeFourParent.transform.parent = pointsParent;
		typeFiveParent.transform.parent = pointsParent;

		typeParentsList.Add(typeOneParent);
		typeParentsList.Add(typeTwoParent);
		typeParentsList.Add(typeThreeParent);
		typeParentsList.Add(typeFourParent);
		typeParentsList.Add(typeFiveParent);

	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray , out hit))
			{
				if (hit.collider.gameObject.transform.tag == "point")
				{
					Application.ExternalCall("" , hit.collider.gameObject.name);
					Debug.Log(hit.collider.gameObject.name);
				}
			}
		}

		if(Input.GetMouseButtonDown(1))
		{
			/*
			Application.ExternalCall("","it is mouse right form unity");
			Debug.Log(hit.collider.gameObject.name);
			*/


			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray , out hit))
			{
				if (hit.collider.gameObject.transform.tag == "point")
				{
					Application.ExternalCall("","it is mouse right form unity");
					Debug.Log(hit.collider.gameObject.name);
				}
			}




		}

	}

	public List<GameObject> GetTypeOneObjsList()
	{
		return typeOneObjsList;
	}

	public List<GameObject> GetTypeTwoObjsList()
	{
		return typeTwoObjsList;
	}

	public List<GameObject> GetTypeThreeObjsList()
	{
		return typeThreeObjsList;
	}

	public List<GameObject> GetTypeFourObjsList()
	{
		return typeFourObjsList;
	}

	public List<GameObject> GetTypeFiveObjsList()
	{
		return typeFiveObjsList;
	}

	public List<GameObject> GetTypeParentsList()
	{
		return typeParentsList;
	}

	public void CreatJianCePoint()
	{
		PointColor pointColor;
		GameObject tempObj = GameObject.CreatePrimitive(PrimitiveType.Cube);

		int type = receiveMessageFormWinForm.GetPointType();
		Vector3 point = receiveMessageFormWinForm.GetPosition();
		string id = receiveMessageFormWinForm.GetNewId();

		#region test code
		/*
		int type = Random.Range(0 , 4);
		Vector3 point = new Vector3(Random.Range(2.0f , 5.0f) , Random.Range(4.0f , 9.0f) , Random.Range(12.0f , 15.0f));
		string id = "qwrwqer-1234-4w5" + Random.Range(0 , 100).ToString();
		*/
		#endregion

		Material tempMaterial = tempObj.GetComponent<Renderer>().material;
		pointColor = (PointColor)type;
		switch (pointColor)
		{
			case PointColor.Red:
				SetMaterialAndPosition(ref tempMaterial , Color.red , ref tempObj , typeOneParent , typeOneObjsList);
				break;
			case PointColor.Green:
				SetMaterialAndPosition(ref tempMaterial , Color.green , ref tempObj , typeTwoParent , typeTwoObjsList);
				break;
			case PointColor.Blue:
				SetMaterialAndPosition(ref tempMaterial , Color.blue , ref tempObj , typeThreeParent , typeThreeObjsList);
				break;
			case PointColor.White:
				SetMaterialAndPosition(ref tempMaterial , Color.white , ref tempObj , typeFourParent , typeFourObjsList);
				break;
			case PointColor.Yellow:
				SetMaterialAndPosition(ref tempMaterial , Color.yellow , ref tempObj , typeFiveParent , typeFiveObjsList);
				break;
		}

		tempObj.transform.localScale = Vector3.one * 10;
		tempObj.transform.localPosition = point;
		tempObj.name = id;
		tempObj.transform.tag = "point";
	}

	void SetMaterialAndPosition(ref Material mat , Color tempColor , ref  GameObject clone , GameObject typeParent , List<GameObject> typeList)
	{
		mat.color = tempColor;
		clone.transform.parent = typeParent.transform;
		typeList.Add(clone);
	}

	public void ControlTypeOpenAndClose()
	{
		#region original code

		bool isOpen = FormatBoolValue(receiveMessageFormWinForm.GetTypeIsOpen());
		int type = receiveMessageFormWinForm.GetPointType();

		#endregion

		#region test code
		/*
		bool isOpen = false;

		int type = 0;
		 */
		#endregion

		SetTypeOpenAndClose(isOpen , type);
	}


	public void SetTypeOpenAndClose(bool tempIsOpen , int type)
	{
		GameObject tempParent = GetDifferentTypeParent(type);
		tempParent.SetActive(tempIsOpen);
	}

	public void SetRootTypeOpenAndClose(bool isOpen)
	{
		pointsParent.gameObject.SetActive(isOpen);
	}

	GameObject GetDifferentTypeParent(int type)
	{
		List<GameObject> parentsList = GetTypeParentsList();
		GameObject tempObj;
		tempObj = parentsList[type];
		return tempObj;

	}

	public void ClearAllJianCeDianObj()
	{
		ClearSingleTypeObjList(GetTypeOneObjsList());
		ClearSingleTypeObjList(GetTypeTwoObjsList());
		ClearSingleTypeObjList(GetTypeThreeObjsList());
		ClearSingleTypeObjList(GetTypeFourObjsList());
		ClearSingleTypeObjList(GetTypeFiveObjsList());

		foreach (Transform child in pointsParent)
		{
			child.gameObject.SetActive(true);
		}
	}

	void ClearSingleTypeObjList(List<GameObject> singleTypeList)
	{
		int count = singleTypeList.Count;
		for (int i=0 ; i < count ; i++)
		{
			Destroy(singleTypeList[i]);
		}
		singleTypeList.Clear();
	}



	bool FormatBoolValue(int iValue)
	{
		bool bValue = true;
		if (iValue == 0)
		{
			bValue = false;
		}
		return bValue;
	}

	List<GameObject> GetDifferentTypeObjList(int type)
	{
		List<GameObject> tempList = new List<GameObject>();
		PointColor tempPointColor = (PointColor)type;
		switch (tempPointColor)
		{
			case PointColor.Red:
				tempList = GetTypeOneObjsList();
				break;
			case PointColor.Green:
				tempList = GetTypeTwoObjsList();
				break;
			case PointColor.Blue:
				tempList = GetTypeThreeObjsList();
				break;
			case PointColor.White:
				tempList = GetTypeFourObjsList();
				break;
			case PointColor.Yellow:
				tempList = GetTypeFiveObjsList();
				break;
		}
		return tempList;
	}


	#region test code
	/*
	bool isOpen  = true;
	void OnGUI()
	{
		if (GUI.Button(new Rect(10 , 50 , 100 , 50) , "ADD POINT"))
		{
			CreatJianCePoint();
		}

		if (GUI.Button(new Rect(10 , 100 , 100 , 50) , "close type one"))
		{
			isOpen = !isOpen;
			SetTypeOpenAndClose(isOpen , 0);
			//ControlTypeOpenAndClose();
		}

		if (GUI.Button(new Rect(10 , 200 , 100 , 50) , "clear all type"))
		{
			ClearAllJianCeDianObj();
		}
	}
	 */
	#endregion
}


public enum PointColor
{
	Red = 0 ,
	Green ,
	Blue ,
	White ,
	Yellow
}

//一条数据项，包含三个类型的数据元素
public struct JianCeDian
{
	public PointColor pointColor;
	public GameObject typeParent;
	public List<GameObject> EveryTypeList;
}







