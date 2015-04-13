using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * 主摄像机初始化正对xoy平面
 * x轴以右方向为正方形，y轴以上方向为正方形
 * */

public class SenceBrowse : MonoBehaviour
{

	public Vector3 initPosition		= new Vector3(56.04659f , 89.59579f , -292.2717f);			//初始化摄像机位置
	public Vector3 initEulerAngles	= new Vector3(12.03219f , 0 , 0);								//初始化摄像机欧拉角
	public float yMinRotate			= 0;
	public float yMaxRotate			= 60;
	public  float  moveSpeed_KEY	= 250;
	public  float  moveSpeed_MOUSE  = 205;
	public float minDistance		= 0;
	public float maxDistance		= 1900;
	public bool isScrollWheel		= true;

	Transform mainCamera;
	GameObject rotateReference;								//旋转参考物体
	GameObject translateReference;							//平移参考物体
	public Vector3 modelCenterPosition = Vector3.zero;		//模型的中心点	
	public GameObject target;								//观察目标物体
    //GameObject rotateGameObj;
	// Use this for initialization
	void Start()
	{
		rotateReference = new GameObject("rotateReference");
		Camera.main.transform.parent = rotateReference.transform;
		InitCameraPosition();
		mainCamera = Camera.main.transform;
		translateReference = new GameObject("translateReference");
		isScrollWheel = true;
	
	}

	// Update is called once per frame
	void Update()
	{
		KeyOperate();
		MouseOperate();
	}

	void InitCameraPosition()
	{
		Camera.main.transform.localPosition = initPosition;
		Camera.main.transform.localRotation = Quaternion.Euler(initEulerAngles);
		//rotateReference.transform.rotation = Quaternion.Euler(initEulerAngles);
		//translateReference.transform.rotation = Quaternion.Euler(new Vector3(0 , initEulerAngles.y , 0));

	}

	float distance_const = 1;			//距离常量

	float angle_x;
	float angle_y;
	public float xSpeed = 250;
	public	float ySpeed = 150;
	public float rotateXiShu =0.02f;

	Vector3 tempPosition;
	GameObject temp;
	//GameObject worldpointObj;
	void MouseOperate()
	{
		//鼠标左键点击按下移动
		if (Input.GetMouseButton(0))
		{
			float xValue = Input.GetAxis("Mouse X");
			float yValue = Input.GetAxis("Mouse Y");
			Transform controlObj = mainCamera;
			if (xValue != 0)
			{
				controlObj.Translate(-xValue * Time.deltaTime * moveSpeed_MOUSE , 0 , 0 , translateReference.transform);
			}
			if (yValue != 0)
			{
				controlObj.Translate(0 , 0 , -yValue * Time.deltaTime * moveSpeed_MOUSE , translateReference.transform);
			}

		}

		if (Input.GetMouseButtonDown(2))
		{
			#region test code
			/*
			Vector3 screenCenterPosition = new Vector3(Screen.width / 2 , Screen.height / 2 , 0);
			Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenCenterPosition);
			worldpointObj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
			worldpointObj.transform.position = new Vector3(worldPosition.x , worldPosition.y - 50 , worldPosition.z);
			*/
			  #endregion

			#region original code
			
			 Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);
			 RaycastHit hit;
			 if (Physics.Raycast(ray , out hit))
			 {
				 tempPosition = hit.point;
				 Debug.DrawLine(Camera.main.transform.position , hit.point , Color.red , 2);
				 temp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				 temp.transform.position = tempPosition;
				 //temp.transform.position = new Vector3(tempPosition.x , tempPosition.y + 50 , tempPosition.z);
				// Debug.Log("tempposition:" + tempPosition);
			 }
			 
			 isScrollWheel = false;
			/*
			 * 
			 Vector3 relativePos = temp.transform.position - rotateReference.transform.position;
			 Quaternion rotation = Quaternion.LookRotation(relativePos);
			 rotateReference.transform.rotation = rotation;
			 rotateReference.transform.LookAt(Vector3.Lerp(rotateReference.transform.position ,
				new Vector3(temp.transform.position.x , temp.transform.position.y + 50 , temp.transform.position.z) , Time.deltaTime));
			*/
			 #endregion
		}



		//鼠标中键进行旋转
		if (Input.GetMouseButton(2))
		{
			if (target)
			{
				#region original code
				/*
					float xValue = Input.GetAxis("Mouse X");
					float yValue = Input.GetAxis("Mouse Y");
					angle_x += xValue * xSpeed * rotateXiShu;
					angle_y -= yValue * ySpeed * rotateXiShu;
					angle_y = Mathf.Clamp(angle_y , yMinRotate , yMaxRotate);

				
					Quaternion rotation = Quaternion.Euler(angle_y , angle_x , 0);
					//以中心点为旋转点
					Vector3 position = rotation * new Vector3(0 , 0 , -distance_const) + target.transform.position;
					rotateReference.transform.rotation = rotation;
					translateReference.transform.rotation = Quaternion.Euler(new Vector3(0 , angle_x , 0));
					rotateReference.transform.position = position;
					*/
				#endregion


				#region 观察大型模型场景的旋转
				
				float xValue = Input.GetAxis("Mouse X");
				float yValue = Input.GetAxis("Mouse Y");
				angle_x += xValue * xSpeed * rotateXiShu;
				angle_y -= yValue * ySpeed * rotateXiShu;
				angle_y = Mathf.Clamp(angle_y , yMinRotate , yMaxRotate);
				//float tempDistance = Vector3.Distance(rotateReference.transform.position , temp.transform.position)*0.01f;
				Quaternion rotation = Quaternion.Euler(angle_y , angle_x , 0);
				//以选取的点为中心点
				Vector3 position = rotation * new Vector3(0 , 0 , -distance_const)+ temp.transform.position;
				rotateReference.transform.position = Vector3.Lerp(rotateReference.transform.position , position , Time.deltaTime * 2f);
				
				//Vector3 position = rotation * new Vector3(0 , 0 , -distance_const) + worldpointObj.transform.position;
				rotateReference.transform.rotation = Quaternion.Lerp(rotateReference.transform.rotation , rotation , Time.deltaTime * 2);
				translateReference.transform.rotation = Quaternion.Euler(new Vector3(0 , angle_x , 0));
				
			
				#endregion

				#region test code
				/*
					float distance = Vector3.Distance(Camera.main.transform.position , tempPosition);
					float scaleVal = (float)(0.01 * distance);
					float xValue,yValue;
					xValue = Input.GetAxis("Mouse X");
					yValue = Input.GetAxis("Mouse Y");
					//Vector3 angle = rotateGameObj.transform.eulerAngles;
					//if (rotateGameObj.transform.eulerAngles.x < yMinRotate)
					//{
					//	angle.x = yMinRotate;
					//}
					//if (rotateGameObj.transform.eulerAngles.x > yMaxRotate)
					//{
					//	angle.x = yMaxRotate;
					//}
					//rotateGameObj.transform.rotation = Quaternion.Euler(angle);
				
					if (yValue != 0)
					{
						
						//控制上下旋转
						rotateGameObj.transform.RotateAround(tempPosition , Vector3.right , yValue * Time.deltaTime * 50f * scaleVal);
						Vector3 angle = rotateGameObj.transform.eulerAngles;
						//if (rotateGameObj.transform.eulerAngles.x < yMinRotate)
						//{
						//	angle.x = yMinRotate;
						//}
						//if (rotateGameObj.transform.eulerAngles.x > yMaxRotate)
						//{
						//	angle.x = yMaxRotate;
						//}
						angle.x = Mathf.Clamp(angle.x , yMinRotate , yMaxRotate);
						rotateGameObj.transform.rotation = Quaternion.Euler(angle);

						Vector3 euler = rotateGameObj.transform.eulerAngles;
						if (euler.x >= yMinRotate && euler.x <= yMaxRotate)
						{
							rotateReference.transform.rotation = Quaternion.Euler(new Vector3(euler.x ,
							euler.y , 0));
							//rotateReference.transform.rotation = Quaternion.Euler(Vector3.Lerp(rotateReference.transform.eulerAngles ,
							//	new Vector3(euler.x , euler.y , 0) , Time.deltaTime*5));
							translateReference.transform.rotation = Quaternion.Euler(new Vector3(0 , rotateReference.transform.eulerAngles.y , 0));
						}

					}
					
					//控制左右旋转
					rotateGameObj.transform.RotateAround(tempPosition , Vector3.up , xValue * Time.deltaTime * 50f * scaleVal);


					Vector3 tempeuler = rotateGameObj.transform.eulerAngles;
					if (tempeuler.x >= yMinRotate && tempeuler.x <= yMaxRotate)
					{
						rotateReference.transform.rotation = Quaternion.Euler(new Vector3(tempeuler.x ,
						tempeuler.y , 0));
						//rotateReference.transform.rotation = Quaternion.Euler(Vector3.Lerp(rotateReference.transform.eulerAngles ,
						//	new Vector3(euler.x , euler.y , 0) , Time.deltaTime*5));
						translateReference.transform.rotation = Quaternion.Euler(new Vector3(0 , rotateReference.transform.eulerAngles.y , 0));
					}
					*/ 
				#endregion

			}
		}
		if (Input.GetMouseButtonUp(2))
		{
			Destroy(temp);
			isScrollWheel = true;
//			Destroy(worldpointObj);
		}
	}

	//以右方向为x轴的正方向，以上方向为y轴的正方形
	void KeyOperate()
	{
		float xValue = Input.GetAxis("Horizontal");
		float yValue = Input.GetAxis("Vertical");
		Transform controlObj = mainCamera;
		#region original code
		/*
			//way one
			if (xValue != 0)
			{
				controlObj.localPosition += new Vector3(xValue * Time.deltaTime * moveSpeed_KEY , 0 , 0);
				controlObj.localRotation = Quaternion.Euler(initEulerAngles);
				rotateReference.transform.rotation = Quaternion.Euler(Vector3.Lerp(rotateReference.transform.eulerAngles ,
					new Vector3(0 , rotateReference.transform.eulerAngles.y , 0) , Time.deltaTime));

			}
			if (yValue != 0)
			{
				controlObj.localPosition += new Vector3(0 , 0 , yValue * Time.deltaTime * moveSpeed_KEY);
				controlObj.localRotation = Quaternion.Euler(initEulerAngles);
				rotateReference.transform.rotation = Quaternion.Euler(Vector3.Lerp(rotateReference.transform.eulerAngles ,
					new Vector3(0 , rotateReference.transform.eulerAngles.y , 0) , Time.deltaTime));

			}
			 */
		#endregion

		#region modify after code

		if (xValue != 0)
		{
			controlObj.Translate(xValue * Time.deltaTime * moveSpeed_KEY , 0 , 0 , translateReference.transform);
		}
		if (yValue != 0)
		{
			controlObj.Translate(0 , 0 , yValue * Time.deltaTime * moveSpeed_KEY , translateReference.transform);
		}
		#endregion

	}

	Vector3 lookPosition;
    //GameObject scaleChangeReferenceObj;
	void OnGUI()
	{
		if (GUILayout.Button("reset position"))
		{
			ResetPosition();
			//Debug.Log("hello world");
		}

		if (Event.current.type == EventType.ScrollWheel)
		{
			#region original code
			/*
				Vector3 tempPos = mainCamera.localPosition;
				if (tempPos.z > maxDistance)
				{
					tempPos.z = maxDistance - 0.1f;
				}
				if (tempPos.z < minDistance)
				{
					tempPos.z = minDistance + 1f;
				}
				mainCamera.localPosition = tempPos;
				float distance = Vector3.Distance(mainCamera.localPosition , modelCenterPosition);
				float xiShu = distance * 0.02f;
				mainCamera.localPosition += new Vector3(0 , Event.current.delta.x * -2f * xiShu , Event.current.delta.y * -2f * xiShu);

				//Debug.Log("distance:" + distance);
				 * */
			#endregion
			if (isScrollWheel)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				//Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.height / 2 , Screen.width / 2 , -1));
				RaycastHit hit;
				if (Physics.Raycast(ray , out hit))
				{
					lookPosition = hit.point;

				}
				Vector3 tempPos = mainCamera.localPosition;
				if (tempPos.z > maxDistance)
				{
					tempPos.z = maxDistance - 0.1f;
				}
				if (tempPos.z < minDistance)
				{
					tempPos.z = minDistance + 1f;
				}
				mainCamera.localPosition = tempPos;
				float distance = Vector3.Distance(mainCamera.localPosition , lookPosition);
				float xiShu = distance * 0.002f;
				mainCamera.localPosition += new Vector3(0 , Event.current.delta.x * -20f * xiShu , Event.current.delta.y * -20f * xiShu);
			}
		}
	}

	void ResetPosition()
	{
		rotateReference.transform.rotation = Quaternion.identity;
		rotateReference.transform.position = Vector3.zero;
		InitCameraPosition();
		isScrollWheel = true;
	}

	float ClampAngle(float angle)
	{
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return angle;
	}
}
