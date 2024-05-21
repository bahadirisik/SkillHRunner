using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
	public int index;
	public void DropItem()
	{
		foreach (Transform item in transform)
		{
			item.GetComponent<SpawnItem>().SpawnDroppedItem();
			Destroy(item.gameObject);
		}

		ClearSlot();
	}

	public void ClearSlot()
	{
		Inventory.Instance.isFull[index] = false;
	}
}
