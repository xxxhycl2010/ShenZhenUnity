//#define test
#define debug


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


public class DengLu : MonoBehaviour {

    public UIInput user;
    public UIInput password;
    Regex reg = new Regex("^[A-Za-z0-9]+$");
    public GameObject dengLuButton;
    public string user_text = "tygeo";
    public string pwd_text = "123456";
   
    public UILabel errorLabel;
    public GameObject buttonUI;
	// Use this for initialization
	void Start () {
        UIEventListener.Get(dengLuButton).onClick = ClickDengLuButton;
        errorLabel.text = null;
	
	}

    void ClickDengLuButton(GameObject go)
    {
        bool isOk = false;
        string tiShiMessage = null;
        isOk = IsMatch(user_text, pwd_text, ref tiShiMessage);

        if (isOk)
        {
            gameObject.GetComponent<UIWidget>().alpha = 0;
            buttonUI.GetComponent<UIWidget>().alpha = 1;
        }
        else
        {
			Debug.Log("message:" + tiShiMessage);
			errorLabel.text = tiShiMessage;
        }
    }

    bool IsMatch(string strUser, string Strpwd,ref string errorMessage)
    {
        bool isOk = false;
        if (user.value.Equals(strUser) && password.value.Equals(Strpwd))
            isOk = true;
        else
        {
            errorMessage = "提示：用户名或者密码错误，请重新输入";
        }

        return isOk;


    }
	
    void OnGUI()
    {
        #region test use regex
#if test
        if (GUI.Button(new Rect(100, 100, 100, 50), "match"))
        {
            string str = user.GetComponent<UILabel>().text;
            Debug.Log("str:" + str);
            Match m = reg.Match(str);
            if (m.Success)
            {
                Debug.Log("it is match");
            }
        }
#endif 
        #endregion

    }
}
