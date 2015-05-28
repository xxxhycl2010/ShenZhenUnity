using UnityEngine;
using System.Collections;

namespace ShenZhen.Monitor
{
    public class PickMonitorPoint : MonoBehaviour
    {
        private const string MODULEVALUE = "MonitorPnt_Info";
        private int layerNum_monitor;
        void OnClickLabel(GameObject go)
        {
            Debug.Log("click " + go.name.ToString());
            Application.ExternalCall(MODULEVALUE, go.name);
        }

        // Use this for initialization
        void Start()
        {
            layerNum_monitor = LayerMask.NameToLayer("Monitor");
            mask = 1 << layerNum_monitor;
        }

        Ray ray;
        RaycastHit hit;
        LayerMask mask;

        // Update is called once per frame
        void Update()
        {
           
            if (Input.GetMouseButtonDown(0))
            { 
                 ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                 if (Physics.Raycast(ray, out hit, 500, mask.value))
                 {
                     if (hit.collider.gameObject.layer == layerNum_monitor && hit.collider.gameObject != null)
                     {
                         Application.ExternalCall(MODULEVALUE, hit.collider.gameObject.name);
                     }
                 }
            }

        }
    }
    
}












