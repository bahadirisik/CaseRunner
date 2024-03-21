using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance { get; private set; }

	public event Action<int> OnCoinTake;
	public event Action OnLevelFailed;

	private int coinAmount = 0;

	private void Awake()
	{
		if(Instance == null)
		{
            Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		coinAmount = 0;
	}

	public void IncreaseCoinAmount(int amount)
	{
		coinAmount += amount;
		OnCoinTake?.Invoke(coinAmount);
	}

	public void LevelFailed()
	{
		Debug.Log("Level Failed");
		OnLevelFailed?.Invoke();
	}
}
