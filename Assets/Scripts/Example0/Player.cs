using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Example0
{


	[ExecuteInEditMode]
	public class Player : MonoBehaviour
	{
		[SerializeField] private float range;
		[SerializeField] private float angle;
		void Update()
		{
			DrawRangeZone();
		}
		void DrawRangeZone()
		{
			Debug.DrawLine(transform.position, transform.position + (transform.rotation * Quaternion.Euler(0, -angle / 2, 0)) * Vector3.forward * range);
			Debug.DrawLine(transform.position, transform.position + (transform.rotation * Quaternion.Euler(0, angle / 2, 0)) * Vector3.forward * range);
			int countSteps = 10;
			for (int i = 1; i <= countSteps; i++)
			{
				float deltaangle = angle / countSteps;
				Debug.DrawLine(
					transform.position + (transform.rotation * Quaternion.Euler(0, -angle / 2 + deltaangle * (i - 1), 0)) * Vector3.forward * range,
					transform.position + (transform.rotation * Quaternion.Euler(0, -angle / 2 + deltaangle * (i), 0)) * Vector3.forward * range);
			}
		}
	}
}
