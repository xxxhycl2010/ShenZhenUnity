//#define local

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ShenZhen.Monitor
{
    public class PointData_json
    {
        public int PntId;
        public string Name;
        public int ItemType;
        public float pntX;
        public float pntY;
        public float pntZ;
        public float Deep;
        public string rgba;
        public string bIsVisible;

        public override string ToString()
        {
            return string.Format("PntId:{0},Name:{1},ItemType:{2},pntX:{3},pntY:{4},pntZ:{5},Deep:{6},rgba:{7},bIsVisible:{8}",
                PntId, Name, ItemType, pntX, pntY, pntZ, Deep, rgba, bIsVisible);
        }

    }

    public class AnalyseMonitorPointData : MonoBehaviour
    {
        string Strdata = null;
        public List<PointData_json> pointList = new List<PointData_json>();

        void Start()
        {
            StartAnalyseInitData("");
        
        }
       public  void StartAnalyseInitData(string strValue)
        {
            pointList.Clear();
         
#if local

            TextAsset testObj = Resources.Load("json_3") as TextAsset;
            Nii.JSON.JSONArray jsonData = new Nii.JSON.JSONArray(testObj.text);
            
#else

            Nii.JSON.JSONArray jsonData = new Nii.JSON.JSONArray(strValue);
#endif
         //   Debug.Log("data;" + jsonData);
            Strdata = jsonData.ToString();
            int length = jsonData.Count;
            PointData_json tempData = null;

            for (int i = 0; i < length; i++)
            {
                tempData = new PointData_json();
                tempData.PntId = int.Parse(jsonData.getJSONObject(i).getString("PntId"));
                tempData.Name = jsonData.getJSONObject(i).getString("Name");
                tempData.ItemType = int.Parse(jsonData.getJSONObject(i).getString("ItemType"));
                tempData.pntX = float.Parse(jsonData.getJSONObject(i).getString("pntX"));
                tempData.pntY = float.Parse(jsonData.getJSONObject(i).getString("pntY"));
                tempData.pntZ = float.Parse(jsonData.getJSONObject(i).getString("pntZ"));
                tempData.Deep = float.Parse(jsonData.getJSONObject(i).getString("Deep"));
                tempData.rgba = jsonData.getJSONObject(i).getString("rgba");
                tempData.bIsVisible = jsonData.getJSONObject(i).getString("bIsVisible");

                pointList.Add(tempData);
            }

        }

        /*
        void OnGUI()
        {
            if (GUILayout.Button("start analyse"))
            {
                StartAnalyseInitData("");
                foreach (var item in pointList)
                    Debug.Log(item.ToString());
            }
        }
        */

      
    }

}
