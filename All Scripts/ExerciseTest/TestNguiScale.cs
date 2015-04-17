using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TestNguiScale : MonoBehaviour {

    public string oldSpriteName;
    public string newSpriteName;

	// Use this for initialization
	void Start () {
        //Debug.Log("hello world");
        UIEventListener.Get(gameObject).onHover = OnHoverSprite;
	
	}

    void OnHoverSprite(GameObject go,bool isHover)
    {
        if (isHover)
            go.GetComponent<UISprite>().spriteName = newSpriteName;           // "工程简介2";
        else
            go.GetComponent<UISprite>().spriteName = oldSpriteName;                          //"工程简介";
    }
	
	
}
