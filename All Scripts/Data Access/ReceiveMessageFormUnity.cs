using UnityEngine;
using System.Collections;

public class ReceiveMessageFormUnity : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}

	public void SendMessageToForm(string id)
	{
		Application.ExternalCall(id);
	}
}
