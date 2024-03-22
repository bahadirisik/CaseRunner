using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IIntreactable
{
	[SerializeField] private int coinAmount = 20;
	public void Interact()
	{
		GameMaster.Instance.IncreaseCoinAmount(coinAmount);
		gameObject.SetActive(false);
	}
}
