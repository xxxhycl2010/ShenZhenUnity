using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class TestAnalyseColor : MonoBehaviour {

    string strValue = "[0,1,0,0]";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject cube;
    void TestAnalyseColorOfPoint()
    {
        StringBuilder str = new StringBuilder(strValue);
        str.Remove(0, 1);
        str.Remove(str.Length - 1, 1);
        Debug.Log(str);
        string[] arr = (str.ToString()).Split(',');
        if (arr.Length == 4)
        {
            Color color = new Color(int.Parse(arr[0]), int.Parse(arr[1]), int.Parse(arr[2]), 1);
            cube.renderer.material.color = color;
        }
        
    }

    void OnGUI()
    {
        if (GUILayout.Button("test string"))
        {
            TestAnalyseColorOfPoint();
        }
    }
}
