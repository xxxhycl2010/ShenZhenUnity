using UnityEngine;
using System.Collections;



public class CeGongMiaoModelControl : MonoBehaviour {

    public GameObject jingGai;
	// Use this for initialization
	void Start () {
        jingGai.SetActive(true);
	
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

    public void OpenJingGai()
    {
        jingGai.SetActive(false);
    }

    public void CloseJingGai()
    {
        jingGai.SetActive(true);
    }
}
