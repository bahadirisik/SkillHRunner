using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IIntreactable
{
	[SerializeField] private int coinAmount;
	[SerializeField] private GameObject coinPickUpEffect;
	public void Intreact(Transform player)
	{
		GameObject effect = Instantiate(coinPickUpEffect, transform.position, Quaternion.identity);
		Destroy(effect, 3f);
		GameMaster.Instance.CoinTake(coinAmount);
		gameObject.SetActive(false);
	}
}
