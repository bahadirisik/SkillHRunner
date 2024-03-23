using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	Rigidbody2D rb;
	float speed = 20f;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.TryGetComponent(out IDamageable damageable))
		{
			damageable.DecreaseHealth(20);
			Destroy(gameObject);
		}
	}
}
