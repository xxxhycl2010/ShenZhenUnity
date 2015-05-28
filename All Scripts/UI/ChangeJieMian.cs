using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using ShenZhen.Monitor;

public class ChangeJieMian : MonoBehaviour {

    public GameObject[] firstItems;
    public GameObject[] secondItems;
    public GameObject[] secondItems_backup;

    public string[] oldSprites;
    public string[] newSprites;


	// Use this for initialization
	void Start () {

        int length1 = firstItems.Length;
        for (int i = 0; i < length1; i++)
        {
            UIEventListener.Get(firstItems[i]).onClick = OnClickButton;
            UIEventListener.Get(firstItems[i]).onHover = OnHoverSprite;
            
        }
        int lenght2 = secondItems_backup.Length;
        for (int i = 0; i < lenght2; i++)
        {
            UIEventListener.Get(secondItems_backup[i]).onClick = OnClickBackButton;
        }

	
	}

    void ResetFirstItemSprite()
    { 
        int length = oldSprites.Length;
        for (int i = 0; i < length; i++)
        {
            firstItems[i].GetComponent<UISprite>().spriteName = oldSprites[i];
        }
    }


    void OnClickButton(GameObject go)
    {
        go.transform.parent.gameObject.SetActive(false);
        //firstJieMian.SetActive(false);
        string name = go.name;

        int length = secondItems.Length;
        for (int i = 0; i < length; i++)
        {
            if (firstItems[i].name.Equals(name))
            {
                secondItems[i].SetActive(true);
                if (i == 2)
                    Application.ExternalCall("Monitor_Mgr");
                break;
            }
        }

     
    }

    public MonitorControl monitorControl;
    public CeGongMiaoModelControl ceGongMiaoModelControl;
    void OnClickBackButton(GameObject go)
    {
        go.transform.parent.gameObject.SetActive(false);
        firstItems[0].transform.parent.gameObject.SetActive(true);
        ResetFirstItemSprite();
        if (go.transform.parent.name.Equals("SafetyJianCe"))
        {
            monitorControl.DestroyMonitorPointTree();
            ceGongMiaoModelControl.SetJingGaiState(true);
        }
    }

    void OnHoverSprite(GameObject go,bool isHover)
    {
        string oldSpriteName = null; ;
        string newSpriteName = null;

        GetCorrespondSpriteName(go.name,ref oldSpriteName, ref newSpriteName);


        if (isHover)
            go.GetComponent<UISprite>().spriteName = newSpriteName;
        else
            go.GetComponent<UISprite>().spriteName = oldSpriteName;
    }
	// Update is called once per frame
	void Update () {
	
	}

    void GetCorrespondSpriteName(string objName,ref string oldName, ref string newName)
    {
        int length = firstItems.Length;
        for (int i = 0; i < length; i++)
        {
            if (firstItems[i].name.Equals(objName))
            {
                oldName = oldSprites[i];
                newName = newSprites[i];
                break;
            }
        }

      
    }
}
