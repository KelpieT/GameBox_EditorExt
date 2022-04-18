using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Example1
{
	public class Grid : MonoBehaviour
	{
		[SerializeField] private int countX;
		[SerializeField] private int countZ;
		[SerializeField] private float distanceX;
		[SerializeField] private float distanceZ;
		public void SetGridPos()
		{
			GridObjects gridObjects = new GridObjects();
			List<GameObject> childs = new List<GameObject>();
			for (int i = 0; i < transform.childCount; i++)
			{
				childs.Add(transform.GetChild(i).gameObject);
			}
			gridObjects.gameObjects = childs;
			gridObjects.countX = countX;
			gridObjects.countZ = countZ;
			gridObjects.distanceX = distanceX;
			gridObjects.distanceZ = distanceZ;
			gridObjects.centerGridPos = transform.position;
			gridObjects.SetGridPos();
		}
	}
}
