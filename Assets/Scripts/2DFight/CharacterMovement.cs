using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour, IDamageable
{
	#region Animation
	private Animator anim;
	#endregion
	#region Movement
	[SerializeField] private float moveSpeed = 10f;
	[SerializeField] private float jumpForce = 10f;
	[SerializeField] private Transform enemy;
    Rigidbody2D rb;
	#endregion

	#region Input
	CharacterInput characterInput;
	#endregion

	#region Attack
	public bool SwordTrigger { get; set; } = false;
	[SerializeField] private Transform projectile;
	[SerializeField] private Transform firePoint;
	#endregion

	#region Health
	public event Action<int> OnTakeDamage;
	public int Health { get; set; } = 100;
	[field : SerializeField]public int CurrentHealth { get; set; }
	#endregion

	private void Start()
	{
		anim = GetComponentInChildren<Animator>();
		CurrentHealth = Health;
		characterInput = GetComponent<CharacterInput>();
		rb = GetComponent<Rigidbody2D>();

		SubEvents();
	}


	private void Update()
	{
		if (CurrentHealth <= 0)
			Die();

		TogglePlayerDir();
	}

	private void FixedUpdate()
	{
		rb.velocity = new Vector2(characterInput.GetMovement().x * moveSpeed * Time.fixedDeltaTime, rb.velocity.y);
	}

	void SubEvents()
	{
		characterInput.OnJump += Jump;
		characterInput.OnSwordAttack += SwordAttack;
		characterInput.OnRangedAttack += ProjectileAttack;
	}

	private void SwordAttack()
	{
		anim.SetTrigger("Attack");

		if (!SwordTrigger)
			return;

		enemy.GetComponent<IDamageable>().DecreaseHealth(20);
	}

	private void ProjectileAttack()
	{
		anim.SetTrigger("Attack");
		GameObject projectileGO = Instantiate(projectile, firePoint.position, Quaternion.identity).gameObject;
		projectileGO.transform.right = Vector3.right * -Mathf.Sign(transform.localScale.x);
		Destroy(projectileGO, 7f);
	}

	void TogglePlayerDir()
	{
		if(transform.position.x > enemy.position.x)
		{
			transform.localScale = new Vector3(1f,
				transform.localScale.y, transform.localScale.z);
		}else if(transform.position.x < enemy.position.x)
		{
			transform.localScale = new Vector3(-1f,
							transform.localScale.y, transform.localScale.z);
		}
	}

	private void Jump()
	{
		anim.SetTrigger("Jump");
		rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
	}

	public void DecreaseHealth(int amount)
	{
		CurrentHealth -= amount;
		OnTakeDamage?.Invoke(CurrentHealth);
	}

	public void Die()
	{
		anim.SetTrigger("Die");
		this.enabled = false;
	}

	
}
