using UnityEngine;
using UnityEditor;
using System.Collections;


class CreatLight : MonoBehaviour
{
    /*
    [MenuItem("新的菜单/克隆所选择物体")]
    static void ClothObject()
    {
        Instantiate(Selection.activeTransform, Vector3.zero, Quaternion.identity);
    }
    
    [MenuItem("新的菜单/克隆所选择物体",true)]
    static bool NoClothObject()
    {
        return Selection.activeGameObject != null;
    }
    
    [MenuItem("新的菜单/删除所选择物体")]
    static void RemoveObject()
    {
        DestroyImmediate(Selection.activeGameObject,true);
    }
    
    [MenuItem("新的菜单/删除所选择物体",true)]
    static bool NoRemoveObject()
    {
        return Selection.activeGameObject != null;
    }

	// Use this for initialization
	void Start () {
	
	}
	*/


    // create light for unity render 
    /*
    [MenuItem("CreatLight/CreatLight")]
    static void CreatLightTest()
    {
       GameObject areLight = Resources.Load("Area Light") as GameObject;
       Transform farther = GameObject.Find("AreaLightGroup").transform;
       foreach( Transform light in Selection.activeTransform)
       {
           GameObject clone = Instantiate(areLight,light.position,Quaternion.Euler(new Vector3(90,0,0))) as GameObject;
           clone.transform.parent = farther;
           //Instantiate(areLight, light.position, Quaternion.Euler(new Vector3(90,0,0)));
          // Debug.Log(light.position);
       }
       // Debug.Log(Selection.activeTransform);
    }
	// Update is called once per frame
	void Update () {

	}
     * */
}
