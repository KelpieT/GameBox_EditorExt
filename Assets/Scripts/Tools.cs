using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Tools
{

	// void SetOrderByPos()
	// {
	// 	var selected = Selection.gameObjects;
	// 	var temp = selected.OrderBy(x => x.transform.position.x).ThenBy(x => x.transform.position.z).ToList();
	// 	for (int i = 0; i < temp.Count; i++)
	// 	{
	// 		GameObject item = temp[i];
	// 		item.transform.SetSiblingIndex(i);
	// 	}
	// }
	// void SetScale()
	// {
	// 	var selected = Selection.gameObjects;
	// 	foreach (var item in selected)
	// 	{
	// 		item.transform.localScale = Vector3.one * totalScale;
	// 	}
	// }
}
public class GridObjects
{
	public List<GameObject> gameObjects = new List<GameObject>();
	public int countX;
	public int countZ;
	public Vector3 centerGridPos;
	public float distanceX;
	public float distanceZ;
	public void SetGridPos()
	{
		for (int i = 0; i < countX; i++)
		{
			float x = distanceX * i;
			for (int j = 0; j < countZ; j++)
			{
				float z = distanceZ * j;
				if (i * countZ + j >= gameObjects.Count)
				{
					Debug.LogWarning("Less");
					return;
				}
				GameObject g = gameObjects[i * countZ + j];
				if (g == null) continue;
				Vector3 pos = centerGridPos + new Vector3(x - distanceX * countX / 2f, 0, z - distanceZ * countZ / 2f);
				pos += new Vector3(distanceX / 2, 0, distanceZ / 2);
				g.transform.position = pos;

			}
		}
		if (countX * countZ < gameObjects.Count)
		{
			Debug.LogWarning("More");
		}
	}
	public List<Vector3> GetPoints()
	{
		List<Vector3> temp = new List<Vector3>();
		for (int i = 0; i < countX; i++)
		{
			float x = distanceX * i;
			for (int j = 0; j < countZ; j++)
			{
				float z = distanceZ * j;
				Vector3 pos = centerGridPos + new Vector3(x - distanceX * countX / 2f, 0, z - distanceZ * countZ / 2f);
				pos += new Vector3(distanceX / 2, 0, distanceZ / 2);
				temp.Add(pos);

			}
		}
		if (countX * countZ < gameObjects.Count)
		{
			Debug.LogWarning("More");
		}
		return temp;

	}
}


