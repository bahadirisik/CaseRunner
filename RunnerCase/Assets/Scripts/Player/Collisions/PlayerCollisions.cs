using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.TryGetComponent(out IIntreactable interactable))
		{
			interactable.Interact();
		}
	}
}
