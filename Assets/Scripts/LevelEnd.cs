using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour, IIntreactable
{
	[SerializeField] private GameObject levelEndEffect;
	public void Intreact(Transform player)
	{
		GameObject levelEndEffectGO = Instantiate(levelEndEffect, player.position, Quaternion.identity);
		Destroy(levelEndEffectGO, 2f);

		GameMaster.Instance.LevelCompleted();

		//player.GetComponentInChildren<Animator>().SetTrigger("Victory");
	}
}
