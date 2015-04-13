using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ShenZhen.Monitor;


namespace ShenZhen.Monitor
{
    public class MonitorLabel : MonoBehaviour
    {
        private const string MODULEVALUE = "monitor";
        // Use this for initialization
        void Start()
        {
            UIEventListener.Get(gameObject).onClick += OnClickLabel;
        }

        void OnClickLabel(GameObject go)
        {
            Debug.Log("click " + go.name.ToString());
            Application.ExternalCall(MODULEVALUE, go.name);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

