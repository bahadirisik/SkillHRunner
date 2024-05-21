using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    [SerializeField] private GameObject potionEffect;
    private Transform player;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	public void Use()
	{
		GetComponentInParent<Slot>().ClearSlot();
		GameObject potionEffGO = Instantiate(potionEffect, player.position, potionEffect.transform.rotation);
		Destroy(potionEffGO, 2f);
		Destroy(gameObject);
	}
}
