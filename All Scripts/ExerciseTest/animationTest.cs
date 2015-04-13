using UnityEngine;
using System.Collections;

public class animationTest : MonoBehaviour {

	public GameObject m_cubeTest;
	public const string ANIM_STEP1 = "Step1",ANIM_STEP2 = "Step2";

	// Use this for initialization
	void Start () {
		m_cubeTest.animation.wrapMode = WrapMode.Loop;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if(GUILayout.Button("动画1",GUILayout.Height(50)))
		{
			m_cubeTest.animation.Play(ANIM_STEP1);
		}
		if(GUILayout.Button("动画2",GUILayout.Height(50)))
		{
			m_cubeTest.animation.Play(ANIM_STEP2);
		}
	}

}
