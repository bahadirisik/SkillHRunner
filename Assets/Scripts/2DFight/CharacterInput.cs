using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
	public event Action OnJump;
	public event Action OnSwordAttack;
	public event Action OnRangedAttack;

	[SerializeField] private KeyCode leftKey;
	[SerializeField] private KeyCode rightKey;
	[SerializeField] private KeyCode jumpKey;
	[SerializeField] private KeyCode swordAttackKey;
	[SerializeField] private KeyCode rangedAttackKey;

    Vector3 movement;

	private void Update()
	{
		if (Input.GetKey(leftKey))
		{
			movement.x = -1;
		}
		else if (Input.GetKey(rightKey))
		{
			movement.x = 1;
		}
		else { movement.x = 0; }

		if (Input.GetKeyDown(jumpKey))
			JumpInput();

		if (Input.GetKeyDown(swordAttackKey))
			SwordAttack();

		if (Input.GetKeyDown(rangedAttackKey))
			RangedAttack();
	}

	private void RangedAttack()
	{
		OnRangedAttack?.Invoke();
	}

	public Vector3 GetMovement()
	{
		return movement;
	}

	private void JumpInput()
	{
		OnJump?.Invoke();
	}

	private void SwordAttack()
	{
		OnSwordAttack?.Invoke();
	}


}
