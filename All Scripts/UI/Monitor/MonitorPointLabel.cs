using UnityEngine;
using System.Collections;

namespace ShenZhen.Monitor
{
    public class MonitorPointLabel : MonoBehaviour
    {
        //public Transform cube;
        public Transform headLabel;
        private float fomat;
        private Transform head;


        // Use this for initialization
        void Start()
        {
            head = gameObject.transform.Find("Head");
            fomat = Vector3.Distance(head.position, Camera.main.transform.position);
        }

        // Update is called once per frame
        void Update()
        {
            if (gameObject.renderer.isVisible == true)
            {
                float newFomat = fomat / Vector3.Distance(head.position, Camera.main.transform.position);
                headLabel.position = WorldToUI(head.position);
                headLabel.localScale = Vector3.one * newFomat;
            }
         

        }

        private static Vector3 WorldToUI(Vector3 point)
        {
            Vector3 pt = Camera.main.WorldToScreenPoint(point);
            Vector3 ff = UICamera.currentCamera.ScreenToWorldPoint(pt);
            ff.z = 0;
            return ff;
        }
    }
    
}


