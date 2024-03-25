using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHB : MonoBehaviour
{
    [SerializeField] private Image healthBar;
	CharacterMovement characterMovement;

	private void Start()
	{
		characterMovement = GetComponent<CharacterMovement>();
		characterMovement.OnTakeDamage += CharacterController_OnTakeDamage;
	}

	private void CharacterController_OnTakeDamage(int currentHealth)
	{
		healthBar.rectTransform.localScale = new Vector3((float)currentHealth / characterMovement.Health, 1f, 1f);
	}
}
