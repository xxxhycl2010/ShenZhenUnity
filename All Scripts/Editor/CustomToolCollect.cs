using UnityEngine;
using System.Collections;
using UnityEditor;

public class CustomToolCollect : MonoBehaviour
{

    // this is example that descript how to write the custom function

    /*
    [MenuItem("新的菜单/克隆所选择物体")]
    static void ClothObject()
    {
        Instantiate(Selection.activeTransform, Vector3.zero, Quaternion.identity);
    }
    */

    [MenuItem("CustomToolCollect/Create Child GameObject")]
    static void CreateChildGameObject()
    {
        GameObject t_parent = Selection.activeTransform.gameObject;
        if (t_parent == null)
            return;
        int layNum = t_parent.layer;
        GameObject newObj = new GameObject("ChildGameObject");

        newObj.transform.parent = t_parent.transform;
        newObj.transform.localPosition = Vector3.zero;
        newObj.transform.localScale = Vector3.one;
        newObj.layer = layNum;

    }
}
