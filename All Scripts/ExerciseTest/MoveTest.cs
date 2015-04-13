using UnityEngine;
using System.Collections;

public class MoveTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetAxis("Horizontal") != 0)
        {
            //Debug.Log(Input.GetAxis("Horizontal"));
            gameObject.transform.Rotate(new Vector3 (0,Input.GetAxis("Horizontal")));
        }

        if(Input.GetAxis("Vertical") != 0)
        {
            gameObject.transform.Translate(new Vector3(0,0,Input.GetAxis("Vertical")));
        }
	
	}
}
