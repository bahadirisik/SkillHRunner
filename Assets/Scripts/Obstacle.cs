using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IIntreactable
{
	[SerializeField] private GameObject collisionEffect;
	public void Intreact(Transform player)
	{
		GameObject collisionEffectGO = Instantiate(collisionEffect, player.transform.position, Quaternion.identity);
		Destroy(collisionEffectGO, 2f);

		GameMaster.Instance.LevelFailed();

		//player.gameObject.SetActive(false);
		player.GetComponentInChildren<Animator>().SetTrigger("Die");
	}
}
