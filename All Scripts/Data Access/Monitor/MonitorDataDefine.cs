//这个程序暂时保留，是以前旧的版本



using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ShenZhen.Monitor
{
#if tempSave
    public enum State
    {
        Error = 0,
        OK =    1
    }


    //--------------- 监测点实例树的数据结构-----------------------------
    public class MonitorPoint
    {
        public GameObject SelfObj { set; get; }
        public GameObject ParentObj { set; get; }
        public string Id { set; get; }
        public string Type { set; get; }
        public string Name { set; get; }
        public Vector3 Positon { set; get; }

        public MonitorPoint(GameObject obj)
        {
            SelfObj = obj;
            Name = null;
            ParentObj = null;
            Id = null;
            Type = null;
            Positon = Vector3.zero;
        }

        public MonitorPoint(string name, string id, string type, Vector3 position,GameObject obj, GameObject parent)
        {
            Name = name;
            SelfObj = obj;
            SelfObj.name = id;
            ParentObj = parent;
            Id = id;
            Type = type;
            Positon = position;
            SelfObj.transform.parent = parent.transform;
            SelfObj.transform.localPosition = position;
            SelfObj.transform.localScale = Vector3.one;
        }

        public override string ToString()
        {
            return string.Format("name:{0} ,id:{1} ,type:{2} ,position:{3} ,parent name:{4}",
                Name,Id,Type,Positon.ToString(),ParentObj.name);
        }
    }

    public class MonitorType
    {
        public string TypeName { set; get; }
        public GameObject SelfObj { set; get; }
        public GameObject ParentObj { set; get; }
        public List<MonitorPoint> PointList;

        public MonitorType()
        {
            TypeName = null;
            SelfObj = new GameObject();
            ParentObj = null;
            PointList = new List<MonitorPoint>();
        
        }

        public MonitorType(string type, GameObject parent)
        {
            this.TypeName = type;
            this.SelfObj = new GameObject(type);
            this.ParentObj = parent;
            this.SelfObj.transform.parent = parent.transform;
            this.PointList = new List<MonitorPoint>();
        }

        public MonitorType(string type, GameObject parent, List<MonitorPoint> points)
        {
            this.TypeName = type;
            this.SelfObj = new GameObject(type);
            this.ParentObj = parent;
            this.SelfObj.transform.parent = parent.transform;
            this.PointList = points;
        }

        public override string ToString()
        {
            return string.Format("typename:{0} ,selfobj name:{1} ,parent name:{2} ,child count:{3} ",
                TypeName,SelfObj.name,ParentObj.name,PointList.Count);
        }
    }

    public class MonitorPointTree
    {
        #region 监测点树数据结构定义
        public GameObject RootObj { set; get; }
        public List<MonitorType> typeList;

        public MonitorPointTree()
        {
            this.RootObj = new GameObject("AllMonitorPoints");
            this.typeList = new List<MonitorType>();
            
        }

        public MonitorPointTree(string name, List<MonitorType> typeList)
        {
            this.RootObj = new GameObject(name);
            this.typeList = typeList;
        }

        #endregion


        #region 监测点树的操作


   
        public State AddSingleMonitorTypeNode(ref List<MonitorType> typeList, string strType)
        {
            if (this.RootObj == null || strType == null)
                return State.Error;
          

            MonitorType newType = new MonitorType();
            if (newType.SelfObj == null)
                return State.Error;

            /*
            if (GetAllMonitorTypeName(typeList).Contains(strType))
                return State.OK;
            */
        
            newType.TypeName = strType;
            newType.SelfObj.name = strType;
            newType.SelfObj.transform.parent = this.RootObj.transform;
            newType.SelfObj.transform.localPosition = Vector3.zero;
            newType.SelfObj.transform.localScale = Vector3.one;

            typeList.Add(newType);


            return State.OK;

        }


        //所有的监测类型名称数据
        public List<string> GetAllMonitorTypeName(List<MonitorType> typeList)
        {
            List<string> types = new List<string>();
            int length = typeList.Count;
            for (int i = 0; i < length; i++)
            {
                types.Add(typeList[i].TypeName);
            }
            return types;
        }

        //所有的监测点id数据
        public List<string> GetAllMonitorPointId(ref List<MonitorType> typeList)
        {
            List<string> idList = new List<string>();
            int length = typeList.Count;
            for (int i = 0; i < length; i++)
            {
                List<MonitorPoint> temp = typeList[i].PointList;
                int tempLength = temp.Count;
                for (int j = 0; j < tempLength; j++)
                {
                    idList.Add(temp[j].Id);
                }
            }
            return idList;
        }
        
        //用于添加单个新的监测类型的数据处理
      


        public State AddSingleMonitorPointNode(ref List<MonitorType> typeList,string name, string type, string id,ref GameObject selfObj, Vector3 position)
        {

            if (selfObj == null )
                return State.Error;

            if (name == null || type == null || id == null)
                return State.Error;
            
			int length = typeList.Count;

			for (int i = 0; i < length; i++)
            {
                if (typeList[i].TypeName.Equals(type))
                {
                    
                    MonitorPoint myPoint = new MonitorPoint(name, id, type, position, selfObj, typeList[i].SelfObj);

                    typeList[i].PointList.Add(myPoint);
                }
            }

             return State.OK;

        }


        public void DestroyMonitorPointTree(ref List<MonitorType> typeList,ref GameObject rootObj)
        {
            GameObject.Destroy(rootObj);
            typeList.Clear();
        }

        public void RemoveSingleMonitorPoint(ref GameObject rootObj, string strId)
        {
            foreach (Transform child in rootObj.transform)
            {
                foreach (Transform item in child)
                {
                    if (item.gameObject.name.Equals(strId))
                    {
                        GameObject.Destroy(item.gameObject);
                    }
                }
            }
        }

        public void SetAllMonitorPointState(ref GameObject rootObj,PointState state)
        {
            if (state == PointState.Open)
            {
                rootObj.SetActive(true);
            }
            else
            {
                rootObj.SetActive(false);
            }
            
        }


        public void SetSingleMonitorTypeNodeState(ref GameObject rootObj, string strType, PointState state)
        {
            foreach (Transform type in rootObj.transform)
            {
                if (type.gameObject.name.Equals(strType))
                {
                    if (state == PointState.Open)
                    {
                        type.gameObject.SetActive(true);
                    }
                    else
                    {
                        type.gameObject.SetActive(false);
                    }
                }
            }
        }

        public void ResetAllMonitorPointState(ref GameObject rootObj)
        {
            rootObj.SetActive(true);
            foreach (Transform type in rootObj.transform)
            {
                type.gameObject.SetActive(true);
                foreach (Transform point in type)
                {
                    point.gameObject.SetActive(true);
                }
            }
        }



        #endregion

    }


    public class MonitorDataDefine
    {
        
    
    }


    //--------------监测点标签树的数据结构--------------------------------------

    public class MonitorLabelNode
    {
        public GameObject Label;

        public MonitorLabelNode(GameObject label)
        {
            this.Label = label;
            
        }
    }

    public class MonitorLabelTypeNode
    {
        public GameObject labelType;
        public List<MonitorLabelNode> labelList;

        public MonitorLabelTypeNode()
        {
            this.labelType = new GameObject();
            labelList = new List<MonitorLabelNode>();
        }

        public MonitorLabelTypeNode(string name)
        {
            this.labelType = new GameObject(name);
            labelList = new List<MonitorLabelNode>();
        }

        public MonitorLabelTypeNode(string name, List<MonitorLabelNode> typeNodes)
        {
            this.labelType = new GameObject();
            this.labelList = new List<MonitorLabelNode>();
        }
    }

    public class MonitorLabelTree
    {

        #region 监测标签树的定义

        public GameObject rootOfMonitorLabel;
        public List<MonitorLabelTypeNode> typeLabelNodes;

        private int layerNum;
        public MonitorLabelTree(GameObject rootOfAllLabel)
        {
            this.rootOfMonitorLabel = rootOfAllLabel;
            this.typeLabelNodes = new List<MonitorLabelTypeNode>();
            layerNum = LayerMask.NameToLayer("NGUI");

        }
        #endregion


        #region 监测点标签树的操作

        public State AddSingleTypeLabelNode(ref List<MonitorLabelTypeNode> typeLabelNodes, string strType)
        {
            if (strType == null)
                return State.Error;

            if (GetAllLabelTypeName(typeLabelNodes).Contains(strType))
                return State.OK;

            MonitorLabelTypeNode typeNode = new MonitorLabelTypeNode(strType);
            GameObject tempObj = typeNode.labelType;
            tempObj.transform.parent = this.rootOfMonitorLabel.transform;
            tempObj.transform.localPosition = Vector3.zero;
            tempObj.transform.localScale = Vector3.one;

            tempObj.layer = layerNum;

            this.typeLabelNodes.Add(typeNode);

            return State.OK;
        }

        public List<string> GetAllLabelTypeName(List<MonitorLabelTypeNode> typeLabelNodes)
        {
            List<string> labelTypes = new List<string>();
            int length = typeLabelNodes.Count;
            for (int i = 0; i < length; i++)
            {
                labelTypes.Add(typeLabelNodes[i].labelType.name);
            }
            return labelTypes;
        }

     

        public State AddSingleMonitorLabelNode(ref List<MonitorLabelTypeNode> typeLabelNodes,string type, string name, string id,ref GameObject selfObj,Color color)
        {
            if (selfObj == null)
                return State.Error;

            if (name == null || type == null || id == null)
                return State.Error;
            int length = typeLabelNodes.Count;
            for (int i = 0; i < length; i++)
            {
                if (typeLabelNodes[i].labelType.name.Equals(type))
                {

                    MonitorLabelNode myLabel = new MonitorLabelNode(selfObj);
                    GameObject tempObj = myLabel.Label;
                    tempObj.name = id;
                    tempObj.transform.parent = typeLabelNodes[i].labelType.transform;
                    tempObj.transform.localPosition = Vector3.zero;
                    tempObj.transform.localScale = Vector3.one;
                    tempObj.GetComponent<UILabel>().text = name;
                    tempObj.GetComponent<UILabel>().color = color;
                    tempObj.layer = layerNum;

                    typeLabelNodes[i].labelList.Add(myLabel);
                }
            }

            return State.OK;
        }

        public void DestroyMonitorLabelTree(ref List<MonitorLabelTypeNode> typeLabelNodes, ref GameObject rootObj)
        {
            foreach (Transform child in rootObj.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            typeLabelNodes.Clear();
        }

        public void RemoveSingleMonitorLabel(ref GameObject rootObj, string strId)
        {
            foreach (Transform child in rootObj.transform)
            {
                foreach (Transform item in child)
                {
                    if (item.gameObject.name.Equals(strId))
                    {
                        GameObject.Destroy(item.gameObject);
                    }
                }
            }
        }

        public void SetAllMonitorLabelState(ref GameObject rootObj, PointState state)
        {
            if (state == PointState.Open)
            {
                rootObj.SetActive(true);
            }
            else
            {
                rootObj.SetActive(false);
            }

        }

        public void SetSingleMonitorLabelTypeNodeState(ref GameObject rootObj, string strType, PointState state)
        {
            foreach (Transform type in rootObj.transform)
            {
                if (type.gameObject.name.Equals(strType))
                {
                    if (state == PointState.Open)
                    {
                        type.gameObject.SetActive(true);
                    }
                    else
                    {
                        type.gameObject.SetActive(false);
                    }
                }
            }
        }

        public void ResetAllMonitorLabelState(ref GameObject rootObj)
        {
            rootObj.SetActive(true);
            foreach (Transform type in rootObj.transform)
            {
                type.gameObject.SetActive(true);
                foreach (Transform point in type)
                {
                    point.gameObject.SetActive(true);
                }
            }
        }



     



        #endregion
    }


    //------------------------------所有监测点数据的数据结构-----------------------------

    public class MonitorPointData
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public string Type { set; get; }
        public Vector3 Position { set; get; }

        public MonitorPointData(string id, string name, string type, Vector3 position)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.Position = position;
        }

        public override string ToString()
        {
            return string.Format("id:{0} ,name:{1} ,type:{2} ,position:{3} ",
                Id,Name,Type,Position.ToString());
        }
    }

    public class MonitorTypeData
    {
        public string Type { set; get; }
        public List<MonitorPointData> monitorPoints;

        public MonitorTypeData(string strType)
        {
            this.Type = strType;
            this.monitorPoints = new List<MonitorPointData>();
        }

        public MonitorTypeData(string type, List<MonitorPointData> monitorPoints)
        {
            this.Type = type;
            this.monitorPoints = monitorPoints;
        }

        public override string ToString()
        {
            return string.Format("type:{0} ,point count:{1} ",
                Type,monitorPoints.Count);
        }
    }

    public class MonitorData
    {
        public List<MonitorTypeData> monitorData;

        public MonitorData()
        {
            monitorData = new List<MonitorTypeData>();
        }

        public override string ToString()
        {
            return string.Format("type count:{0}",monitorData.Count);
        }

        public State AddSingleTypeNode(ref List<MonitorTypeData> monitorData, string strType)
        {
            //TODO:这里的代码需要完善

            return State.OK;
        }

        public State AddSinglePointNode(ref List<MonitorTypeData> monitorData, string id, string name, string type, Vector3 pos)
        { 
            //TODO:这里的代码需要完善

            return State.OK;
        }

        public void ClearMonitorData(ref List<MonitorTypeData> monitorData)
        {
            monitorData.Clear();
        }




    }

#endif

}

