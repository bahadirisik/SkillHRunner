using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrigger : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.TryGetComponent(out IDamageable damageable))
		{
			GetComponentInParent<CharacterMovement>().SwordTrigger = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out IDamageable damageable))
		{
			GetComponentInParent<CharacterMovement>().SwordTrigger = false;
		}
	}
}
