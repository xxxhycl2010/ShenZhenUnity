using UnityEngine;
using System.Collections;

public class ReceiveMessageFormWinForm : MonoBehaviour {
	public int Type;
	public Vector3 point;
	public string newId;
	public float vector3_x;
	public float vector3_y;
	public float vector3_z;
	public int isOpen;			// 1----is open ,0---is close
	// Use this for initialization
	
	void Awake()
	{
		
	}
	
	void Start () {
		
	}
	
	// Update is called once per frame
	public void SetPointType(int type)
	{
		Type = type;
	}
	
	public int GetPointType()
	{
		return Type;
	}
	
	public void SetPosition(Vector3 point)
	{
		this.point = point;
	}
	
	public void SetPointX(float x)
	{
		vector3_x = x;
	}
	
	public void SetPointY(float y)
	{
		vector3_y = y;
	}
	
	public void SetPointZ(float z)
	{
		vector3_z = z;
	}
	
	public void SetTypeIsOpen(int isOpen)
	{
		this.isOpen = isOpen;
	}
	
	public int GetTypeIsOpen()
	{
		return isOpen;
	}
	public float GetPointX()
	{
		return vector3_x;
	}
	
	public float GetPointY()
	{
		return vector3_y;
	}
	
	public float GetPointZ()
	{
		return vector3_z;
	}
	
	
	public Vector3 GetPosition()
	{
		this.point = new Vector3(GetPointX() , GetPointY() , GetPointZ());
		return this.point;
	}
	
	public void SetNewId(string id)
	{
		newId = id;
	}
	
	public string GetNewId()
	{
		return newId;
	}
	
	
}


