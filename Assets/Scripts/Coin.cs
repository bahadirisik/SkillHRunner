using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IIntreactable
{
	PlayerBoost playerBoost;

	[SerializeField] private int coinAmount;
	private float distanceToPlayer;
	private float coinMoveSpeed = 30f;
	private Vector3 heading;

	private void Start()
	{
		playerBoost = FindObjectOfType<PlayerBoost>();
	}
	
	public void Intreact(Transform player)
	{
		AudioManager.Instance.Play("Coin");

		GameObject effect = Instantiate(GameAssets.ins.coinPickUpEffect, transform.position, Quaternion.identity);
		Destroy(effect, 3f);
		GameMaster.Instance.CoinTake(coinAmount);
		gameObject.SetActive(false);
	}

	private void Update()
	{
		distanceToPlayer = DistanceCheck();

		if (playerBoost.IsMagnetActive && distanceToPlayer <= 500f)
		{
			GoToPlayer();
		}
	}

	private float DistanceCheck()
	{
		float distanceSquared;

		heading.x = transform.position.x - playerBoost.transform.position.x;
		heading.y = transform.position.y - playerBoost.transform.position.y;
		heading.z = transform.position.z - playerBoost.transform.position.z;

		distanceSquared = heading.x * heading.x + heading.y * heading.y + heading.z * heading.z;

		return distanceSquared;
	}

	private void GoToPlayer()
	{
		transform.Translate(-heading.normalized * coinMoveSpeed * Time.deltaTime);
	}
}
