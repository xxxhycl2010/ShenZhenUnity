#define local


#define tempSave

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ShenZhen.Monitor
{
    /*
    public class PointData_json
    {
        
        public int PntId { set; get; }
        public int CusItemId { set; get; }
        public int SysItemId { set; get; }
        public string Name { set; get; }
        public float pntX { set; get; }
        public float pntY { set; get; }
        public float pntZ { set; get; }
        public float Deep { set; get; }
        public string CreateTime { set; get; }
        public string RemoveTime { set; get; }
        public string Remark { set; get; }

    }

    */
    public class AnalyseMonitorData : MonoBehaviour
    {

        /*
        public MonitorData m_monitorData;
        List<PointData_json> initJsonData = new List<PointData_json>();
        public TestMonitorPoint testMonitorPoint;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        string Strdata = null;
        void StartAnalyseInitData(string strValue)
        {
            m_monitorData = new MonitorData();
            initJsonData.Clear();
#if local

            TextAsset testObj = Resources.Load("json_data") as TextAsset;
            Nii.JSON.JSONArray jsonData = new Nii.JSON.JSONArray(testObj.text);
            
#else

            Nii.JSON.JSONArray jsonData = new Nii.JSON.JSONArray(strValue);
#endif
            Debug.Log("data;" + jsonData);
            Strdata = jsonData.ToString();
            int length = jsonData.Count;
            PointData_json tempData = null;

            for (int i = 0; i < length; i++)
            {
                tempData = new PointData_json();
                tempData.PntId = int.Parse(  jsonData.getJSONObject(i).getString("PntId"));
                tempData.CusItemId =int.Parse( jsonData.getJSONObject(i).getString("CusItemId"));
                tempData.SysItemId = int.Parse( jsonData.getJSONObject(i).getString("SysItemId"));
                tempData.Name = jsonData.getJSONObject(i).getString("Name");
                tempData.pntX = float.Parse( jsonData.getJSONObject(i).getString("pntX"));
                tempData.pntY = float.Parse(jsonData.getJSONObject(i).getString("pntY"));
                tempData.pntZ = float.Parse(jsonData.getJSONObject(i).getString("pntZ"));
                tempData.Deep = float.Parse(jsonData.getJSONObject(i).getString("Deep"));
                tempData.CreateTime = jsonData.getJSONObject(i).getString("CreateTime");
                tempData.RemoveTime = jsonData.getJSONObject(i).getString("RemoveTime");
                tempData.Remark = jsonData.getJSONObject(i).getString("Remark");

                initJsonData.Add(tempData);    
            }
     
        }

        public MonitorData InitMonitorData(string strValue)
        {
            StartAnalyseInitData(strValue);
            int length = initJsonData.Count;

            //添加所有的类型数据
            for (int i = 0; i < length; i++)
            {
                string strType = initJsonData[i].SysItemId.ToString();
                if (!isContainType(strType))
                {
                    MonitorTypeData monitorTypeData = new MonitorTypeData(strType);
                    m_monitorData.monitorData.Add(monitorTypeData);
                }
                
            }

            //添加所有的不同类型对应的监测点数据
            int lengthOne = m_monitorData.monitorData.Count;
            for (int i = 0; i < lengthOne; i++)
            {
                 List<MonitorPointData> monitorPoints = m_monitorData.monitorData[i].monitorPoints;
                for (int j = 0; j < length; j++)
                {
                   
                    if (m_monitorData.monitorData[i].Type.Equals(initJsonData[j].SysItemId.ToString()))
                    { 
                        MonitorPointData newPoint = new MonitorPointData(initJsonData[j].PntId.ToString(),
                            initJsonData[j].Name, initJsonData[j].SysItemId.ToString(), testMonitorPoint.GetCorrespondPosition(j));
                        monitorPoints.Add(newPoint);

                    }
                }
            }

            return m_monitorData;
        }

        private bool isContainType(string strType)
        {
            List<MonitorTypeData> temp = m_monitorData.monitorData;
            int length = temp.Count;
            for (int i = 0; i < length; i++)
            {
                if (temp[i].Type.Equals(strType))
                {
                    return true;
                }
            }
            return false;
        }

        
        PointData_json singleData;
        private void StartAnalyseSingleMonitorPointData(string strValue)
        {
#if local
            TextAsset testObj = Resources.Load("test1") as TextAsset;
            Nii.JSON.JSONObject jsonData = new Nii.JSON.JSONObject(testObj.text);
#else
            Nii.JSON.JSONObject jsonData = new Nii.JSON.JSONObject(strValue);
#endif
           
  


        }

        private  int CONSTINDEX = 39;
        MonitorPointData newPoint;
        public MonitorPointData SinglePointData(string strValue)
        {
            
            //StartAnalyseSingleMonitorPointData(strValue);

            // newPoint = new MonitorPointData(singleData.RowId, singleData.MpName, singleData.MonitorType, testMonitorPoint.GetCorrespondPosition(38));
            //return newPoint;
             
            return null;
        }

        
        //void OnGUI()
        //{
        //    GUI.Label(new Rect(10,Screen.height/2,Screen.width,100), "data:" + Strdata);
        //}
        
        
        */

    }
}






















