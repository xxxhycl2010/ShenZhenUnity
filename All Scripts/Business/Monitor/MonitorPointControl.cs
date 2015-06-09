//#define test

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ShenZhen.Monitor
{

    public class CPoint
    {
        public GameObject pointObj;
        public GameObject labelObj;

        public CPoint()
        {
            pointObj = null;
            labelObj = null;
        }

        public CPoint(GameObject point, GameObject label)
        {
            this.pointObj = point;
            this.labelObj = label;
        }

    }

    public class MonitorPointControl : MonoBehaviour
    {

        GameObject RootOfPoints = null;
        public GameObject pointPrefab;
        public GameObject LabelPrefab;
        private int layerNum_monitor;

        public GameObject RootOfLabels;

        List<CPoint> pointsList = new List<CPoint>();
        public List<PointData_json> myPointsData = new List<PointData_json>();

        public AnalyseMonitorPointData myAnalyseMonitorPointData;

        // Use this for initialization
        void Start()
        {
            layerNum_monitor = LayerMask.NameToLayer("Monitor");
        }

    

        public void CreatePointTree(string strValue)
        {
#if test
            myAnalyseMonitorPointData.StartAnalyseInitData("");
#else
              myAnalyseMonitorPointData.StartAnalyseInitData(strValue);
#endif

            pointsList.Clear();
            myPointsData.Clear();

            myPointsData = myAnalyseMonitorPointData.pointList;

            RootOfPoints = new GameObject("RootOfPoints");
            RootOfPoints.transform.position = Vector3.zero;
            RootOfPoints.transform.localScale = Vector3.one;

            int length = myPointsData.Count;
            for (int i = 0; i < length; i++)
            {

              //  InstantiateSinglePoint(myPointsData[i]);

                InstantiateSinglePoint(myPointsData[i],i);


            }

        }

        private void InstantiateSinglePoint(PointData_json data)
        {
            if (RootOfPoints == null)
                return;
            GameObject myPoint = InstantiatePoint(data);
            GameObject myLabel = InstantiateLabel(data);
            myPoint.GetComponent<MonitorPointLabel>().headLabel = myLabel.transform;
            CPoint Point = new CPoint(myPoint, myLabel);
            pointsList.Add(Point);

        }

        public TestMonitorPoint myMonitorPoint;
        private void InstantiateSinglePoint(PointData_json data,int sort_id)
        {
            if (RootOfPoints == null)
                return;
            GameObject myPoint = InstantiatePoint(data);
            myPoint.transform.localPosition = myMonitorPoint.GetCorrespondPosition(sort_id);
            GameObject myLabel = InstantiateLabel(data);
            myPoint.GetComponent<MonitorPointLabel>().headLabel = myLabel.transform;
            CPoint Point = new CPoint(myPoint, myLabel);
            pointsList.Add(Point);




        }



        //实例化监测标签
        private GameObject InstantiateLabel(PointData_json data)
        {
            GameObject newObj = Instantiate(LabelPrefab) as GameObject;
            if (newObj == null)
                return null;
            newObj.name = data.PntId.ToString();
            newObj.transform.parent = RootOfLabels.transform;
            newObj.GetComponent<UILabel>().text = data.Name;
            newObj.transform.localPosition = Vector3.zero;
            newObj.transform.localScale = Vector3.one;
            newObj.GetComponent<UILabel>().color = SetPointColor(data.rgba);


            return newObj;
        }





        //实例化监测点
        private GameObject InstantiatePoint(PointData_json data)
        {
            GameObject newObj = Instantiate(pointPrefab) as GameObject;
            if (newObj == null)
                return null;
            newObj.transform.parent = RootOfPoints.transform;
            newObj.name = data.PntId.ToString();
            newObj.transform.localScale = Vector3.one;
            newObj.layer = layerNum_monitor;


            newObj.transform.localPosition = localPointPosition(data);
            newObj.renderer.material.color = SetPointColor(data.rgba);

            newObj.AddComponent<MonitorPointLabel>();
            return newObj;

        }


        private Vector3 localPointPosition(PointData_json data)
        {
            //TODO: 需要转化系数和基准点，有待完善
            Vector3 pos = Vector3.zero;
            if (data == null)
                return pos;
            pos.x = data.pntX;
            pos.y = data.pntY;
            pos.z = data.pntZ;
            return pos;
           
        }


        public Color SetPointColor(string strRgba)
        { 
            if(strRgba == null || strRgba == "")
                return Color.green;
            Color color = new Color();
            StringBuilder str = new StringBuilder(strRgba);
            str.Remove(0, 1);
            str.Remove(str.Length - 1, 1);
            Debug.Log(str);
            string[] arr = (str.ToString()).Split(',');
            if (arr.Length == 4)
            {
                 color = new Color(int.Parse(arr[0]), int.Parse(arr[1]), int.Parse(arr[2]), 1);
            }
            return color;

        }


        public void DestroyAllPoints()
        {
            Destroy(RootOfLabels);
            foreach (Transform child in RootOfLabels.transform)
                Destroy(child.gameObject);

               pointsList.Clear();
            myPointsData.Clear();
        }

#if test
        
        void OnGUI()
        {
            if (GUILayout.Button("create tree"))
            {
                CreatePointTree("");
                Debug.Log("create tree");
            }
        }
         
#endif
    }

}
