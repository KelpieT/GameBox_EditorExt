using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
namespace Example2
{
	public class GridEditorWindow : EditorWindow
	{
		int countX = 5;
		int countZ = 3;
		float distanceBeetwenX = 1.5f;
		float distanceBeetwenZ = 1.5f;
		List<GameObject> gameObjects = new List<GameObject>();
		protected GridObjects gridObjects;

		public float GetDistanceBeetwenX()
		{
			return distanceBeetwenX;
		}

		public void SetDistanceBeetwenX(float value)
		{
			float v = distanceBeetwenX;
			distanceBeetwenX = value;
			if (v != distanceBeetwenX) Edit();
		}

		public float GetDistanceBeetwenZ()
		{
			return distanceBeetwenZ;
		}

		public void SetDistanceBeetwenZ(float value)
		{
			float v = distanceBeetwenZ;
			distanceBeetwenZ = value;
			if (v != distanceBeetwenZ) Edit();
		}

		[MenuItem("My tools/Grid Window")]
		static void Init()
		{
			GridEditorWindow window = (GridEditorWindow)EditorWindow.GetWindow(typeof(GridEditorWindow));
			window.Show();
		}
		protected virtual void OnGUI()
		{

			countX = EditorGUILayout.IntField("countX", countX);
			countZ = EditorGUILayout.IntField("countZ", countZ);
			SetDistanceBeetwenX(EditorGUILayout.FloatField("distX", GetDistanceBeetwenX()));
			SetDistanceBeetwenZ(EditorGUILayout.FloatField("distZ", GetDistanceBeetwenZ()));

			if (GUILayout.Button("Edit"))
			{
				Edit();
			}
		}
		void Edit()
		{
			gridObjects = new GridObjects();
			List<GameObject> childs = Selection.gameObjects.ToList();
			if (childs == null || childs.Count == 0) return;
			gridObjects.gameObjects = childs;
			gridObjects.countX = countX;
			gridObjects.countZ = countZ;
			gridObjects.distanceX = GetDistanceBeetwenX();
			gridObjects.distanceZ = GetDistanceBeetwenZ();
			if (childs[0].transform.parent != null)
				gridObjects.centerGridPos = childs[0].transform.parent.position;
			gridObjects.SetGridPos();
		}
	}
}
