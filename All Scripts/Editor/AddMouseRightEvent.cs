using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

/// <summary>
/// Add mouse right event.
/// </summary>
public static class AddMouseRightEvent  {

	static  AddMouseRightEvent()
	{
		//OnSceneFunc();
		//SceneView.OnSceneGUIDelegate = OnSceneFunc;
		OnSceneFunc();
	}

	private class Item
	{
		public string MenuName{set;get;}
		public GenericMenu.MenuFunction2 Call{set;get;}

	}

	static List<Item> S_MenuList = new List<Item>();
	public static void AddMenu(string menuName,GenericMenu.MenuFunction2 call)
	{
		Item item = new Item();
		item.MenuName = menuName;
		item.Call = call;
		S_MenuList.Add(item);
	}

	static void OnSceneFunc()
	{
		if(S_MenuList.Count == 0)
		{
			return;
		}

		if(Event.current.isMouse && Event.current.button == 1)
		{
			Vector3 p = Event.current.mousePosition;
			GenericMenu menu = new GenericMenu();
			foreach(Item i in S_MenuList)
			{
				menu.AddItem(new GUIContent(i.MenuName),false,i.Call,p);
			}
			menu.ShowAsContext();
			Event.current.Use();
			Debug.Log("aaa");
		}
	}

	public static void Reset()
	{
		while(S_MenuList.Count > 0)
		{
			S_MenuList.RemoveAt(0);
		}
	}


}
