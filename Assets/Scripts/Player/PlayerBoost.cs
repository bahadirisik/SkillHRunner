using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoost : MonoBehaviour
{
	public static event Action<bool> OnMagnetCollect;
	public static event Action<bool> OnShieldCollect;

	public bool IsMagnetActive { get; private set; }
	public bool IsShieldActive { get; private set; }

	private float magnetStartTimer = 3f;
	private float magnetCurrentTimer;

	private void Start()
	{
		magnetCurrentTimer = magnetStartTimer;
		IsMagnetActive = false;
		IsShieldActive = false;
	}

	private void Update()
	{
		if(magnetCurrentTimer <= 0f)
			ToggleMagnet(false);

		if(IsMagnetActive)
			magnetCurrentTimer -= Time.deltaTime;
	}

	public void ToggleMagnet(bool value)
	{
		OnMagnetCollect?.Invoke(value);
		magnetCurrentTimer = magnetStartTimer;
		IsMagnetActive = value;
	}

	public void ToggleShield(bool value)
	{
		OnShieldCollect?.Invoke(value);
		IsShieldActive = value;
	}
}
