using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace Example5
{
	[CustomEditor(typeof(Player))]
	public class MyHandlesEditor : Editor
	{
		public void OnSceneGUI()
		{
			Player t = target as Player;
			for (int i = 0; i < t.points.Count; i++)
			{
				t.points[i] = Handles.PositionHandle(t.points[i], Quaternion.identity);
			}
		}
	}
}
