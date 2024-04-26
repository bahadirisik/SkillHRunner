using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	private PlayerBoost playerBoost;

	public int Health { get; private set; }

	private bool isDead = false;

	private void Start()
	{
		Health = 100;
		playerBoost = GetComponent<PlayerBoost>();
		isDead = false;
	}

	private void Update()
	{
		if(Health <= 0 && !isDead)
		{
			Die();
		}
	}

	public void DecreaseHealth(int damage)
	{
		if (playerBoost.IsShieldActive)
		{
			playerBoost.ToggleShield(false);
			return;
		}

		Health -= damage;
	}

	public void IncreaseHealth(int amount)
	{
		Health += amount;
	}

	void Die()
	{
		isDead = true;

		GameObject collisionEffectGO = Instantiate(GameAssets.ins.collisionEffect, transform.position, Quaternion.identity);
		Destroy(collisionEffectGO, 2f);

		GameMaster.Instance.LevelFailed();

		gameObject.SetActive(false);

		//GetComponentInChildren<Animator>().SetTrigger("Die");
	}
}
