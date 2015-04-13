using UnityEngine;
using System.Collections;


public class CeGongMiaoModelControl : MonoBehaviour {

    public GameObject jingGai;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetJingGaiState(bool isOpen)
    {
        if (isOpen)
        {
            jingGai.SetActive(true);
        }
        else
        {
            jingGai.SetActive(false);
        }
    }
}
