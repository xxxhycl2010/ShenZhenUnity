using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ShenZhen.Monitor
{
    public enum PointState
    { 
        Close = 0,
        Open = 1
    }


    public class MonitorControl : MonoBehaviour
    {
        public GameObject rootOfMointorPoint;
        public GameObject rootOfMointorLabel;
        public GameObject pointPrefab;
        public GameObject labelPrefab;

        public MonitorPointTree monitorPointTree;
        public MonitorLabelTree monitorLabelTree;
        public List<MonitorLabelTypeNode> monitorLabelTypeNodes;

        public List<string> typeList_data = new List<string>();

        private List<MonitorType> monitorTypeNodes;

        public MonitorData monitorData; 

        // Use this for initialization
        void Start()
        {
         
        }

        // Update is called once per frame
        void Update()
        {

        }


        public State InitMonitorPointData()
        {
            //从winform向unity中传递监测点的数据处理

            #region test data code

            monitorData = new MonitorData();

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
            
            

            #endregion


            return State.OK;
            
        }


        private void InitMonitorTree()
        {
            monitorPointTree = new MonitorPointTree();
            rootOfMointorPoint = monitorPointTree.RootObj;
            monitorTypeNodes = monitorPointTree.typeList;

            monitorLabelTree = new MonitorLabelTree(rootOfMointorLabel);
            monitorLabelTypeNodes = monitorLabelTree.typeLabelNodes;
        }

        public CeGongMiaoModelControl ceGongMiaoModelControl;
        public void CreateMonitorPointTree()
        {
            if (InitMonitorPointData() == State.Error)
                return;

            ceGongMiaoModelControl.SetJingGaiState(false);
            InitMonitorTree();
           
            AddAllMonitorTypeNodes(ref monitorData);
            AddAllMonitorPointNodes();

        }

        private void AddAllMonitorTypeNodes()
        {
            int length = typeList_data.Count;
            for (int i = 0; i < length; i++)
            {
                if (monitorPointTree.AddSingleMonitorTypeNode(ref monitorTypeNodes, typeList_data[i]) == State.OK)
                {

                }
                else
                {
                    Debug.Log("create fail ,type node name:" + typeList_data[i].ToString());
                }
            }
        }

        //添加所有监测类型节点
        private void AddAllMonitorTypeNodes(ref MonitorData monitorData_ref)
        {
            int length = monitorData_ref.monitorData.Count;
            for (int i = 0; i < length; i++)
            {
                //添加监测点实例
                if (monitorPointTree.AddSingleMonitorTypeNode(ref monitorTypeNodes, monitorData_ref.monitorData[i].Type) == State.OK)
                {
                    //添加监测点对应的标签
                    if (monitorLabelTree.AddSingleTypeLabelNode(ref monitorLabelTypeNodes, monitorData_ref.monitorData[i].Type) == State.OK)
                    {
                    }
                    else
                    {
                        Debug.Log("create label type node is fail,type node name" + monitorData_ref.monitorData[i].Type.ToString());
                    }

                }
                else
                {
                    Debug.Log("create fail,type node name:" + monitorData_ref.monitorData[i].Type.ToString());
                }
            }

           // AddAllMonitorLabelTypeNodes(monitorData_ref);
        }


        private void AddAllMonitorLabelTypeNodes(MonitorData data)
        {
            int length = data.monitorData.Count;
            for (int i = 0; i < length; i++)
            {
                if (monitorLabelTree.AddSingleTypeLabelNode(ref monitorLabelTypeNodes, data.monitorData[i].Type) == State.OK)
                {
                }
                else
                {
                    Debug.Log("create label type node is fail,type node name" + data.monitorData[i].Type.ToString());
                }

            }
        }


        //添加所有监测点的节点
        private void AddAllMonitorPointNodes()
        {
            int length = monitorData.monitorData.Count;
            for(int i=0;i<length;i++)
            {
                int len = monitorData.monitorData[i].monitorPoints.Count;
                List<MonitorPointData> temp = monitorData.monitorData[i].monitorPoints;

                for (int j = 0; j < len; j++)
                {
                    GameObject selfObj = InstantiatePoint(temp[j].Id);
                    if (monitorPointTree.AddSingleMonitorPointNode(ref monitorTypeNodes, temp[j].Name, temp[j].Type, temp[j].Id,
                       ref selfObj, temp[j].Position) == State.OK)
                    {
                        GameObject newObj = InstantiateLabel(temp[j].Id);
                        if (monitorLabelTree.AddSingleMonitorLabelNode(ref monitorLabelTypeNodes, temp[j].Type, temp[j].Name,
                            temp[j].Id, ref newObj, PointColor.GetCorrespondColor(i)) == State.OK)
                        {
                           MonitorPointLabel headLabel =  selfObj.AddComponent<MonitorPointLabel>();
                           headLabel.headLabel = newObj.transform;
                          

                        }
                        else
                        {
                            Debug.Log("add single point is fail ,id:" + temp[j].Id.ToString() + " name:" + temp[j].Name.ToString());
                        }
                    }
                    else
                    {
                        Debug.Log("add single point is fail ,id:" + temp[j].Id.ToString() + " name:" + temp[j].Name.ToString());
                    }
                }
                
            }

            //AddAllMonitorLabelNodes();
        }

        private void AddAllMonitorLabelNodes()
        {
            int length = monitorData.monitorData.Count;
            for (int i = 0; i < length; i++)
            {
                int len = monitorData.monitorData[i].monitorPoints.Count;
                List<MonitorPointData> temp = monitorData.monitorData[i].monitorPoints;

                for (int j = 0; j < len; j++)
                {
                    GameObject selfObj = InstantiateLabel(temp[j].Id);
                    if (monitorLabelTree.AddSingleMonitorLabelNode(ref monitorLabelTypeNodes,temp[j].Type,temp[j].Name,
                        temp[j].Id,ref selfObj,PointColor.GetCorrespondColor(i))  == State.OK)
                    {
                    }
                    else
                    {
                        Debug.Log("add single point is fail ,id:" + temp[j].Id.ToString() + " name:" + temp[j].Name.ToString());
                    }
                }

            }
        }

        private GameObject InstantiateLabel(string id)
        {
            GameObject newObj = Instantiate(labelPrefab) as GameObject;
            if (newObj == null)
                return null;
            newObj.name = id;
            newObj.transform.position = Vector3.zero;
            newObj.transform.localScale = Vector3.one;
            newObj.AddComponent<MonitorLabel>();
            return newObj;
        }

        private GameObject InstantiatePoint(string id)
        {
            GameObject newObj = Instantiate(pointPrefab) as GameObject;
            if (newObj == null)
                return null;
            newObj.name = id;
            newObj.transform.position = Vector3.zero;
            newObj.transform.localScale = Vector3.one;

            return newObj;

        }

        public void DestroyMonitorPointTree()
        {
            monitorPointTree.DestroyMonitorPointTree(ref monitorTypeNodes, ref rootOfMointorPoint);
            monitorLabelTree.DestroyMonitorLabelTree(ref monitorLabelTypeNodes, ref rootOfMointorLabel);
            monitorData.monitorData.Clear();
        }

        private const int ARGSCOUNT = 2;
        public void SetSingleMonitorTypeNodeState(string strValue)
        {
            string[] newStr = strValue.Split(',');
            if (newStr.Length < ARGSCOUNT)
                return;
            PointState state;
            if (newStr[1].Equals("0"))
            {
                state = PointState.Close;
            }
            else
            {
                state = PointState.Open;
            }

            monitorPointTree.SetSingleMonitorTypeNodeState(ref rootOfMointorPoint, newStr[0], state);
            monitorLabelTree.SetSingleMonitorLabelTypeNodeState(ref rootOfMointorLabel, newStr[0], state);
        
        }

        public void SetAllMonitorTypeNodeState(string strValue)
        {
            PointState state;
            if (strValue.Equals("0"))
            { 
                state = PointState.Close;
            }
            else
            {
                state = PointState.Open;
            }
            monitorPointTree.SetAllMonitorPointState(ref rootOfMointorPoint,state);
            monitorLabelTree.SetAllMonitorLabelState(ref rootOfMointorLabel, state);

        }

        public void ResetAllMonitorPoint()
        {
            monitorPointTree.ResetAllMonitorPointState(ref rootOfMointorPoint);
            monitorLabelTree.ResetAllMonitorLabelState(ref rootOfMointorLabel);
        }


       

    }
}

