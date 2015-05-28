#define debug
#undef trace

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ShenZhen.Monitor;

namespace ShenZhenTest.Monitor
{

    public class MonitorTest : MonoBehaviour
    {
        public MonitorControl monitorControl;

        //public MonitorData monitorData = new MonitorData();
        // Use this for initialization
        void Start()
        {

            #region test monitor data ,it is for test
            /*
            MonitorPointData point1 = new MonitorPointData("001", "ce1", "red", new Vector3(-510.5763f, -9.872375f, -237.8817f));
            MonitorPointData point2 = new MonitorPointData("002", "ce2", "red", new Vector3(-484.5013f, -9.872375f, -237.8817f));
            MonitorPointData point3 = new MonitorPointData("003", "ce3", "red", new Vector3(-472.0671f, -9.872375f, -254.3741f));
            List<MonitorPointData> list1 = new List<MonitorPointData>();
            list1.Add(point1);
            list1.Add(point2);
            list1.Add(point3);
            MonitorTypeData type1 = new MonitorTypeData("red", list1);


            MonitorPointData point4 = new MonitorPointData("004", "ce4", "green", new Vector3(-462.0305f, -9.872375f, -267.7462f));
            MonitorPointData point5 = new MonitorPointData("005", "ce5", "green", new Vector3(-426.1282f, -9.872375f, -285.1335f));
            MonitorPointData point6 = new MonitorPointData("006", "ce6", "green", new Vector3(-378.0294f, -9.872375f, -278.0111f));
            MonitorPointData point7 = new MonitorPointData("007", "ce7", "green", new Vector3(-330.2068f, -9.872375f, -297.7874f));
            List<MonitorPointData> list2 = new List<MonitorPointData>();
            list2.Add(point4);
            list2.Add(point5);
            list2.Add(point6);
            list2.Add(point7);
            MonitorTypeData type2 = new MonitorTypeData("green", list2);


            MonitorPointData point8 = new MonitorPointData("008", "ce8", "blue", new Vector3(-362.2035f, -9.872375f, -307.9692f));
            MonitorPointData point9 = new MonitorPointData("009", "ce9", "blue", new Vector3(-393.5931f, -9.872375f, -330.7943f));
            MonitorPointData point10 = new MonitorPointData("010", "ce10", "blue", new Vector3(-425.279f, -9.872375f, -330.7943f));
            List<MonitorPointData> list3 = new List<MonitorPointData>();
            list3.Add(point8);
            list3.Add(point9);
            list3.Add(point10);
            MonitorTypeData type3 = new MonitorTypeData("blue", list3);

            monitorData.monitorData.Add(type1);
            monitorData.monitorData.Add(type2);
            monitorData.monitorData.Add(type3);


            */
            #endregion



        }

        // Update is called once per frame
        void Update()
        {



        }

#if debug
        bool isred = true;
        bool isopen = true;
        void OnGUI()
        {
            if (GUILayout.Button("create monitor tree"))
            {
                /*
                List<string> typelist = new List<string>() { "red", "green", "blue" };
                monitorControl.typeList_data = typelist;
                monitorControl.monitorData = this.monitorData;
                 * */
                monitorControl.CreateMonitorPointTree("");
            }

            if (GUILayout.Button("destroy monitor tree"))
            {
                monitorControl.DestroyMonitorPointTree();
            }

            /*
            if (GUILayout.Button("test split"))
            {
                TestSplit(); 
            }
             */

            if (GUILayout.Button("close red type"))
            {
                isred = !isred;
                string newStr = null;
                if (isred)
                {
                    newStr = "red,1";
                }
                else
                {
                    newStr = "red,0";
                }

                monitorControl.SetSingleMonitorTypeNodeState(newStr);

            }

            if (GUILayout.Button("close all point"))
            {
                isopen = !isopen;
                string str = null;
                if (isopen)
                {
                    str = "1";
                }
                else
                {
                    str = "0";
                }
                monitorControl.SetAllMonitorTypeNodeState(str);
            }

            if (GUILayout.Button("reset all point"))
            {
                monitorControl.ResetAllMonitorPoint();
            }

            if (GUILayout.Button("add single monitor type node"))
            {
                monitorControl.AddSingleMonitorType("yellow");
            }

            if (GUILayout.Button("add monitor point"))
            {
                monitorControl.AddMonitorPoint("");
            }

            if (GUILayout.Button("remove monitor point"))
            {
                monitorControl.RemoveMonitorPoint("");
            }
        }
#endif
        void TestSplit()
        {
            string str = "hello,world";
            string[] newstr = str.Split(',');
            Debug.Log("cout :" + newstr.Length);
            Debug.Log("one:" + newstr[0].ToString());
            Debug.Log("tow:" + newstr[1].ToString());
        }
    }

}
