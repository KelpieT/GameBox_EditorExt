using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Example2
{
	public class SpawnSnapWindow : EditorWindow
	{
		Object prefab;

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
		}

		public float GetDistanceBeetwenZ()
		{
			return distanceBeetwenZ;
		}

		public void SetDistanceBeetwenZ(float value)
		{
			float v = distanceBeetwenZ;
			distanceBeetwenZ = value;
		}

		[MenuItem("My tools/Spawn and Snap")]
		static void Init()
		{
			SpawnSnapWindow window = (SpawnSnapWindow)EditorWindow.GetWindow(typeof(SpawnSnapWindow));
			window.Show();
		}
		protected virtual void OnGUI()
		{
			prefab = EditorGUILayout.ObjectField(prefab, typeof(GameObject), true);

			countX = EditorGUILayout.IntField("countX", countX);
			countZ = EditorGUILayout.IntField("countZ", countZ);
			SetDistanceBeetwenX(EditorGUILayout.FloatField("distX", GetDistanceBeetwenX()));
			SetDistanceBeetwenZ(EditorGUILayout.FloatField("distZ", GetDistanceBeetwenZ()));




			if (GUILayout.Button("Spawn"))
			{
				Spawn();
			}
			if (GUILayout.Button("Snap"))
			{
				Snap();
			}
			if (GUILayout.Button("Snap and Rotate"))
			{
				SnapAndRotate();
			}
		}
		void Spawn()
		{

			InitGrid();
			List<Vector3> points = gridObjects.GetPoints();
			foreach (var item in points)
			{
				Instantiate(prefab, item + Vector3.up * 10, Quaternion.identity);
			}
		}
		void Snap()
		{
			var selected = Selection.gameObjects;
			foreach (var item in selected)
			{
				Ray ray = new Ray(item.transform.position + Vector3.down, Vector3.down);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit))
				{
					item.transform.position = hit.point;
				}
			}
		}
		void SnapAndRotate()
		{
			var selected = Selection.gameObjects;
			foreach (var item in selected)
			{
				Ray ray = new Ray(item.transform.position + Vector3.down, Vector3.down);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit))
				{
					item.transform.position = hit.point;
					item.transform.rotation = Quaternion.LookRotation(hit.normal, Vector3.up);
				}
			}
		}
		void InitGrid()
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
