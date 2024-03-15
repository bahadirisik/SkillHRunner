using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.TryGetComponent(out IIntreactable intrectable))
		{
			intrectable.Intreact(transform);
		}
	}
}
