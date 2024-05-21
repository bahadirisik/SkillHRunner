using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	[SerializeField] private GameObject itemButton;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			for (int i = 0; i < Inventory.Instance.slots.Length; i++)
			{
				if (!Inventory.Instance.isFull[i])
				{
					Inventory.Instance.isFull[i] = true;
					Instantiate(itemButton, Inventory.Instance.slots[i].transform, false);
					Destroy(gameObject);
					break;
				}
			}
		}
	}
}
