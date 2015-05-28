using UnityEngine;
using System.Collections;

public class ReceiveMessageFormUnity : MonoBehaviour {

    public GameObject[] secondItemButton_monitor;
    
	
    // Use this for initialization
	void Start () {
        
        UIEventListener.Get(secondItemButton_monitor[0]).onClick = OnClickMonitorButton;
        UIEventListener.Get(secondItemButton_monitor[1]).onClick = OnClickMonitorButton;
        UIEventListener.Get(secondItemButton_monitor[2]).onClick = OnClickMonitorButton;
       
	}

 
    void OnClickMonitorButton(GameObject go)
    {
        string name = go.name;
        switch (name)
        { 
            case "JianCeDataManager":
                Application.ExternalCall("Monitor_DataMgr");
                break;
            case "JianCePointManager":
                Application.ExternalCall("Monitor_PointMgr");
                break;
            case "JianCeProjectManager":
                Application.ExternalCall("Monitor_ItemMgr");
                break;
        }
    }
	public void SendMessageToForm(string id)
	{
		Application.ExternalCall(id);
	}


}
