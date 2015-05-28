using UnityEngine;
using System.Collections;

public class QieHuanPicture : MonoBehaviour {

    public GameObject[] MenuObjs;

    public string[] normalSprits;
    public string[] hoverSprits;

    public string[] messages;


	// Use this for initialization
	void Start () {
        int length1 = MenuObjs.Length;
        for (int i = 0; i < length1; i++)
        {
            if (i < length1 - 1)
            {
                UIEventListener.Get(MenuObjs[i]).onClick = OnClickButton;
            }
           
            UIEventListener.Get(MenuObjs[i]).onHover = OnHoverSprite;

        }
	
	}

    void OnClickButton(GameObject go)
    {
        for (int i = 0; i < MenuObjs.Length-1; i++)
        {
            if (go.name == MenuObjs[i].name)
            {
                Application.ExternalCall(messages[i]);
                break;
            }
        }
    }

    void OnHoverSprite(GameObject go, bool isHover)
    {
        string oldSpriteName = null; ;
        string newSpriteName = null;

        GetCorrespondSpriteName(go.name, ref oldSpriteName, ref newSpriteName);


        if (isHover)
            go.GetComponent<UISprite>().spriteName = newSpriteName;
        else
            go.GetComponent<UISprite>().spriteName = oldSpriteName;
    }

    void GetCorrespondSpriteName(string objName, ref string oldName, ref string newName)
    {
        int length = MenuObjs.Length;
        for (int i = 0; i < length; i++)
        {
            if (MenuObjs[i].name.Equals(objName))
            {
                oldName = normalSprits[i];
                newName = hoverSprits[i];
                break;
            }
        }


    }
	
	
}
