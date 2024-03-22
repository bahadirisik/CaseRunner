using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundReturnToPool : MonoBehaviour
{
    private Vector2 groundEndPoint;
	Camera mainCam;

	private void OnEnable()
	{
		foreach (Transform child in transform)
		{
			child.gameObject.SetActive(true);
		}

		mainCam = Camera.main;
		groundEndPoint = transform.GetChild(0).transform.position;
	}

	private void LateUpdate()
	{
		if ((mainCam.transform.position.x - groundEndPoint.x) > 40f)
		{
			Debug.Log(mainCam.transform.position.x);
			Debug.Log(groundEndPoint.x);
			ReturnToThePool();
		}
	}

	void ReturnToThePool()
	{
		ObjectPoolManager.ReturnObjectToPool(gameObject);
	}
}
