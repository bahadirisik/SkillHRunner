using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour, IIntreactable
{
	public void Intreact(Transform player)
	{
		player.GetComponent<PlayerBoost>().IsMagnetActive = true;
		gameObject.SetActive(false);
	}
}
