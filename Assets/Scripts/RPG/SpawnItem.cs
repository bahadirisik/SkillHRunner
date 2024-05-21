using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] private GameObject item;
	private Transform player;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	public void SpawnDroppedItem()
	{
		Vector3 playerPos = player.position + new Vector3(0f, 0f, 2f);
		Instantiate(item, playerPos, Quaternion.identity);
	}
}
