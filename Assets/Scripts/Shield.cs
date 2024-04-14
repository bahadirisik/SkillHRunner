using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour, IIntreactable
{
	public void Intreact(Transform player)
	{
		player.GetComponent<PlayerBoost>().IsShieldActive = true;
		gameObject.SetActive(false);
	}
}
