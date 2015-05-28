#define debug

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ShenZhen.Monitor
{
    public class PointData_json
    {
        public string RowId { set; get; }
        public string MpName { set; get; }
        public string MpDeep { set; get; }
        public string MRowId { set; get; }
        public string MpSort { set; get; }
        public float MpX { set; get; }
        public float MpY { set; get; }
        public float MpZ { set; get; }
        public string PRowId { set; get; }
        public string MonitorState { set; get; }
        public string MonitorType { set; get; }

    }


    public class AnalyseMonitorData : MonoBehaviour
    {

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

        void StartAnalyseInitData(string strValue)
        {
            m_monitorData = new MonitorData();
            initJsonData.Clear();
#if debug
  
            TextAsset testObj = Resources.Load("Noname1") as TextAsset;
            Nii.JSON.JSONArray jsonData = new Nii.JSON.JSONArray(testObj.text);
            
#else

            Nii.JSON.JSONArray jsonData = new Nii.JSON.JSONArray(strValue);
#endif
            //Debug.Log("data;" + jsonData);
            int length = jsonData.Count;
            for (int i = 0; i < length; i++)
            {
                PointData_json tempData = new PointData_json();
                tempData.RowId = jsonData.getJSONObject(i).getString("RowId");
                tempData.MpName = jsonData.getJSONObject(i).getString("MpName");
                tempData.MpDeep = jsonData.getJSONObject(i).getString("MpDeep");
                tempData.MRowId = jsonData.getJSONObject(i).getString("MRowId");
                tempData.MpSort = jsonData.getJSONObject(i).getString("MpSort");
                tempData.MpX = float.Parse(jsonData.getJSONObject(i).getString("MpX"));
                tempData.MpY = float.Parse(jsonData.getJSONObject(i).getString("MpY"));
                tempData.MpZ = float.Parse(jsonData.getJSONObject(i).getString("MpZ"));
                tempData.PRowId = jsonData.getJSONObject(i).getString("PRowId");
                tempData.MonitorState = jsonData.getJSONObject(i).getString("MonitorState");
                tempData.MonitorType = jsonData.getJSONObject(i).getString("MonitorType");

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
                string strType = initJsonData[i].MonitorType;
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
                   
                    if (m_monitorData.monitorData[i].Type.Equals(initJsonData[j].MonitorType))
                    { 
                        MonitorPointData newPoint = new MonitorPointData(initJsonData[j].RowId,
                            initJsonData[j].MpName,initJsonData[j].MonitorType,testMonitorPoint.GetCorrespondPosition(j));
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
#if debug
            TextAsset testObj = Resources.Load("test1") as TextAsset;
            Nii.JSON.JSONObject jsonData = new Nii.JSON.JSONObject(testObj.text);
#else
            Nii.JSON.JSONObject jsonData = new Nii.JSON.JSONObject(strValue);
#endif

            singleData = new PointData_json();
            singleData.RowId = jsonData.getString("RowId");
            singleData.MpName = jsonData.getString("MpName");
            singleData.MpDeep = jsonData.getString("MpDeep");
            singleData.MRowId = jsonData.getString("MRowId");
            singleData.MpSort = jsonData.getString("MpSort");
            singleData.MpX = float.Parse( jsonData.getString("MpX"));
            singleData.MpY = float.Parse( jsonData.getString("MpY"));
            singleData.MpZ = float.Parse( jsonData.getString("MpZ"));
            singleData.PRowId = jsonData.getString("PRowId");
            singleData.MonitorState = jsonData.getString("MonitorState");
            singleData.MonitorType = jsonData.getString("MonitorType");

  


        }

        private  int CONSTINDEX = 39;
        MonitorPointData newPoint;
        public MonitorPointData SinglePointData(string strValue)
        {
            StartAnalyseSingleMonitorPointData(strValue);

             newPoint = new MonitorPointData(singleData.RowId, singleData.MpName, singleData.MonitorType, testMonitorPoint.GetCorrespondPosition(38));
            return newPoint;
        }


    }

}






















