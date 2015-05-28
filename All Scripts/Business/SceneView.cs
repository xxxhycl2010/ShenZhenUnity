

using UnityEngine;
using System.Collections;

public class SceneView : MonoBehaviour
{
	public Transform target;
	public float rotateConstDistance = 200f;
	float rotate_x;
	float rotate_y;

	public float yMinRotate  		  = 0;
	public float yMaxRotate 		  = 90;
	public float xSpeed 			  = 250;
	public float ySpeed				  = 125;
	public Vector3 initCameraPosition = new Vector3(56.04659f , 89.59579f , -292.2717f);
	public Vector3 initEulerAngles 	  = new Vector3(12.03219f , 0 , 0);
	public bool isScrollWheel = true;
	// Use this for initialization
	void Start()
	{
		InitReference();
		InitEulerAndPosition();
		isScrollWheel = true;
		Vector2 angles = transform.eulerAngles;
		rotate_x = angles.y;
		rotate_y = angles.x;
		if (rigidbody)
			rigidbody.freezeRotation = true;



	}

	GameObject hitGameObj;
	Transform  controlObj;
	public float moveSpeed_mouse = 250;
	public float moveSpeed_key = 250;
	public float minDistance = 0;
	public float maxDistance = 1000;
	Vector3 lookPosition;
	public const float rotateConst  = 0.01f; 
	public const float rotateXiShu = 0.02f;
	// Update is called once per frame

    private float currentDistance;
	void Update()
	{
     
        ControlRotate();
        ControlMove_mouse();
        ControlMove_key();

		zoomReference.transform.localPosition = Camera.main.transform.position;
		zoomReference.transform.eulerAngles = Camera.main.transform.eulerAngles;
	}

    void ControlMove_mouse()
    {
        if (target)
        {
            controlObj = Camera.main.transform;
            if (Input.GetMouseButton(0))
            {

                float xValue = Input.GetAxis("Mouse X");
                float yValue = Input.GetAxis("Mouse Y");

                if (xValue != 0)
                {
                    controlObj.Translate(-xValue * Time.deltaTime * moveSpeed_mouse, 0, 0, moveReference.transform);
                }

                if (yValue != 0)
                {
                    controlObj.Translate(0, 0, -yValue * Time.deltaTime * moveSpeed_mouse, moveReference.transform);
                }

            }
        }
    }

    void ControlMove_key()
    {
        if (target)
        {
            controlObj = Camera.main.transform;

            float xValue = Input.GetAxis("Horizontal");
            float yValue = Input.GetAxis("Vertical");

            if (xValue != 0)
            {
                controlObj.Translate(xValue * Time.deltaTime * moveSpeed_key, 0, 0, moveReference.transform);
            }

            if (yValue != 0)
            {
                controlObj.Translate(0, 0, yValue * Time.deltaTime * moveSpeed_key, moveReference.transform);
            }


        }
    }

    void ControlRotate()
    {
        if (target)
        {
            if (Input.GetMouseButtonDown(2))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    hitGameObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    hitGameObj.transform.localScale = Vector3.one;
                    hitGameObj.transform.position = hit.point;
                    currentDistance = Vector3.Distance(Camera.main.transform.position, hitGameObj.transform.position);
                    currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);
                }
            }


            if (Input.GetMouseButton(2))
            {
                isScrollWheel = false;
                float xValue = Input.GetAxis("Mouse X");
                float yValue = Input.GetAxis("Mouse Y");
                if (Mathf.Abs(xValue) < rotateConst && Mathf.Abs(yValue) < rotateConst)
                {
                    return;
                }

                rotate_x += xValue * xSpeed * rotateXiShu;
                rotate_y -= yValue * ySpeed * rotateXiShu;
                rotate_y = Mathf.Clamp(rotate_y, yMinRotate, yMaxRotate);
                Debug.Log("rotate_x:" + Input.GetAxis("Mouse X").ToString());
                Debug.Log("rotate_y:" + Input.GetAxis("Mouse Y").ToString());

                Quaternion rotation = Quaternion.Euler(rotate_y, rotate_x, 0);
                Vector3 position = rotation * new Vector3(0, 0, -currentDistance) + hitGameObj.transform.position;
                transform.rotation = rotation;
                transform.position = position;
                moveReference.transform.rotation = Quaternion.Euler(new Vector3(0, transform.eulerAngles.y, 0));
            }


            if (Input.GetMouseButtonUp(2))
            {
                Destroy(hitGameObj);
                isScrollWheel = true;
            }
        }

    
    }

    #region this is the another way ,but it is exist the bug, it need to modify
    void CameraRotate()
    {
        if (Input.GetMouseButtonDown(2))
        {
            CameraDistance();
            Debug.Log(m_distance);
        }

        if (Input.GetMouseButton(2))
        {
            CameraRotateAxis();
            gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, 0);
            if (Input.GetAxis("Mouse X") != 0)
                gameObject.transform.RotateAround(m_point, Vector3.up, Input.GetAxis("Mouse X"));
            if (Input.GetAxis("Mouse Y") != 0)
                gameObject.transform.RotateAround(m_point, m_rotateAxis, -Input.GetAxis("Mouse Y"));
        }
    }

    float m_distance;
    void CameraDistance()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red, 2);
            m_point = hit.point;
            //Debug.Log(hit.point);
        }
        else
            m_point = this.transform.position + new Vector3(0, 100, 100);

        m_distance = Vector3.Distance(Camera.main.transform.position, m_point);

    }

    Vector3 m_point;
    Vector3 m_rotateAxis;
    void CameraRotateAxis()
    {
        Vector3 v1 = Camera.main.transform.position - m_point;
        Vector3 v2 = (new Vector3(Camera.main.transform.position.x, m_point.y, Camera.main.transform.position.z)) - m_point;
        m_rotateAxis = Vector3.Cross(v2, v1);
        Debug.Log(m_rotateAxis);
    }
    #endregion

    public float scrollConstValue = 100;


    void ControlZoom()
    {
      
        if (target)
        {
            controlObj = zoomReference.transform;
            if (Event.current.type == EventType.ScrollWheel)
            {

                if (isScrollWheel)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        lookPosition = hit.point;

                    }

                    float distance = Vector3.Distance(controlObj.position, lookPosition);
                    Debug.Log("distance:" + distance);
                    float xiShu = distance * 0.02f;
                    float scrollValue = Input.GetAxis("Mouse ScrollWheel") * xiShu * Time.deltaTime * scrollConstValue;
                    controlObj.Translate(0, 0, scrollValue, transform);
                    if (controlObj.transform.position.y >= minDistance && controlObj.transform.position.y <= maxDistance)
                    {
                        Camera.main.transform.position = controlObj.position;
                    }
                }

            }

        }
    }

	void OnGUI()
	{
        ControlZoom();

        /*
        if (GUI.Button(new Rect(Screen.width - 120, 100, 120, 30), "resetMainCamera"))
		{
			InitEulerAndPosition();
		}
        */
	}

	void InitEulerAndPosition()
	{
		Transform tempCamera = Camera.main.transform;
		tempCamera.position = initCameraPosition;
		//tempCamera.eulerAngles = initEulerAngles;		//note:there is different between curren way and next way,but the two way has some associate
		tempCamera.rotation = Quaternion.Euler(initEulerAngles);

        ResetGameObject(moveReference);
        ResetGameObject(rotateReference);
        ResetGameObject(zoomReference);
	}

    void ResetGameObject(GameObject obj)
    {
        obj.transform.localPosition = Vector3.zero;
        obj.transform.rotation = Quaternion.Euler(Vector3.zero);
    }


	GameObject moveReference;
	GameObject rotateReference;
	GameObject referenceParent;
	GameObject zoomReference;
	void InitReference()
	{
		referenceParent = new GameObject("referenceParent");
		moveReference = new GameObject("moveReference");
		rotateReference = new GameObject("rotateReference");
		zoomReference = new GameObject("zoomReference");
		moveReference.transform.parent = referenceParent.transform;
		rotateReference.transform.parent = referenceParent.transform;
		zoomReference.transform.parent = referenceParent.transform;
		zoomReference.transform.localPosition = initCameraPosition;
		moveReference.transform.rotation = Quaternion.Euler(new Vector3(0 , controlObj.eulerAngles.y , 0));


	}



}
