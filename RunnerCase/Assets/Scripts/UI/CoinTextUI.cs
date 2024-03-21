using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinTextUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

	private void Start()
	{
		SubEvents();
	}

	void SubEvents()
	{
		GameMaster.Instance.OnCoinTake += GameMaster_OnCoinTake;
	}

	private void GameMaster_OnCoinTake(int coinAmount)
	{
		coinText.text = "Coin : " + coinAmount;
	}
}
