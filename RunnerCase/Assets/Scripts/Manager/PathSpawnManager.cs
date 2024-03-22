using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] grounds;
	private Vector2 groundEndPoint = new Vector2(12.5f,-10f);
	Camera mainCam;

	private void Start()
	{
		mainCam = Camera.main;
		//Baþlangýçta birkaç tane platform oluþturuyoruz
		for (int i = 0; i < 5; i++)
		{
			SpawnGround();
		}
	}

	private void Update()
	{
		if(Vector2.Distance(mainCam.transform.position, groundEndPoint) < 100f)
		{
			SpawnGround();
		}
	}

	void SpawnGround()
	{
		int randomGroundIndex = Random.Range(0, grounds.Length);
		GameObject spawnedGround = ObjectPoolManager.SpawnObject(grounds[randomGroundIndex], groundEndPoint, Quaternion.identity, 
			ObjectPoolManager.PoolType.GameObjectSystem);

		groundEndPoint = spawnedGround.transform.GetChild(0).position;
	}
}
