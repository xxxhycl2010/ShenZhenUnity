using UnityEngine;
using System.Collections;

public class CamAround : MonoBehaviour {

    GameObject m_cube;

	// Use this for initialization
	void Start () {

        m_cube = GameObject.Find("Cube");
	
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.RotateAround(m_cube.transform.position, Vector3.up,0.1f);
	
	}
}
