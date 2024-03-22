using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour, IIntreactable
{
	public void Interact()
	{
		Transform player = FindObjectOfType<Player>().transform;
		player.GetComponent<Player>().Die();
	}
}
