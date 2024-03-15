using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IIntreactable
{
	[SerializeField] private int coinAmount;
	public void Intreact(Transform player)
	{
		GameMaster.Instance.CoinTake(coinAmount);
	}
}
