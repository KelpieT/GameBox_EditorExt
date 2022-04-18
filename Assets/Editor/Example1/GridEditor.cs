using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace Example1
{
	[CustomEditor(typeof(Grid))]
	public class GridEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			Grid grid = (Grid)target;
			if (GUILayout.Button("Set positions by grid"))
			{
				grid.SetGridPos();
			}
		}
	}
}
