using UnityEngine;
using System.Collections;

public class Blood_Bar : MonoBehaviour {

    public GameObject m_bloodBar;
    public GameObject m_camera;
	// Use this for initialization
	void Start () {
        m_camera = GameObject.Find("Camera");
        m_bloodBar = GameObject.Find("BloodBar");
	
	}
	
	// Update is called once per frame
	void Update () {
        m_bloodBar.transform.position = gameObject.transform.position; 
        Vector3 v = transform.position - m_camera.transform.position;
        Quaternion rotation;
        rotation = Quaternion.LookRotation(v);
        m_bloodBar.transform.rotation = rotation;
	
	}
}
