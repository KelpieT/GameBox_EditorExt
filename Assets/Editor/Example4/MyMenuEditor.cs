using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class MyMenuEditor : Editor
{
	[MenuItem("GameObject/Sort by posXZ", false, 1010)]
	public static void SortByPosXZ()
	{
		if (Selection.objects.Length == 0) return;
		Transform parent = (Selection.objects[0] as GameObject).transform;
		List<Transform> childs = new List<Transform>();
		for (int i = 0; i < parent.childCount; i++)
		{
			childs.Add(parent.GetChild(i));
		}
		var sorted = childs.OrderBy(x => x.transform.localPosition.z).ThenBy(x => x.transform.localPosition.x).ToList();
		for (int i = 0; i < sorted.Count; i++)
		{
			sorted[i].SetSiblingIndex(i);
		}
	}
	[MenuItem("CONTEXT/Transform/Sort by pos", false, 1010)]
	public static void SortByPos()
	{
		if (Selection.objects.Length == 0) return;
		Transform parent = (Selection.objects[0] as GameObject).transform;
		List<Transform> childs = new List<Transform>();
		for (int i = 0; i < parent.childCount; i++)
		{
			childs.Add(parent.GetChild(i));
		}
		var sorted = childs.OrderBy(x => x.transform.localPosition.magnitude).ToList();
		for (int i = 0; i < sorted.Count; i++)
		{
			sorted[i].SetSiblingIndex(i);
		}
	}
	[MenuItem("Assets/My Copy path")]
	public static void CopyPathToBuffer()
	{
		if (Selection.objects.Length == 0) return;
		string path = AssetDatabase.GetAssetPath(Selection.objects[0]);
		string clickedAssetGuid = Selection.assetGUIDs[0];
		string clickedPath = AssetDatabase.GUIDToAssetPath(clickedAssetGuid);
		string clickedPathFull = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), clickedPath), Selection.objects[0].name);
		GUIUtility.systemCopyBuffer = Path.GetDirectoryName(clickedPathFull);
	}
}
