using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IIntreactable
{
	[SerializeField] private int damage;
	public void Intreact(Transform player)
	{
		//player.gameObject.SetActive(false);
		player.GetComponent<PlayerHealth>().DecreaseHealth(damage);
	}
}
