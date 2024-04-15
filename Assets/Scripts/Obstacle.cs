using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IIntreactable
{
	[SerializeField] private int damage;
	public void Intreact(Transform player)
	{
		GameObject effect = Instantiate(GameAssets.ins.collisionEffect, transform.position, Quaternion.identity);
		Destroy(effect, 3f);
		gameObject.SetActive(false);
		//player.gameObject.SetActive(false);
		player.GetComponent<PlayerHealth>().DecreaseHealth(damage);
	}
}
