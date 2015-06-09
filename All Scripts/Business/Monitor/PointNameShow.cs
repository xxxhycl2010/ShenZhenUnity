using UnityEngine;
using System.Collections;

public class PointNameShow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseEnter()
    {
        Debug.Log(gameObject.name + " mouse is enter");
    }

    void OnMouseExit()
    {
        Debug.Log(gameObject.name + " mouse is exit");
    }

    void OnMouseOver()
    {
        Debug.Log(gameObject.name + " mouse is over");
    }
}
