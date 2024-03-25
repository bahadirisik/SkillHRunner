using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterFightGame : MonoBehaviour
{
	public static GameMasterFightGame Instance1 { get; private set; }

	public event Action<float> OnCountdownChange;

    private float countDown = 100f;

	private void Awake()
	{
		if(Instance1 == null)
		{
			Instance1 = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Update()
	{
		DecreaseCountDown();
	}

	private void DecreaseCountDown()
	{
		countDown -= Time.deltaTime;
		OnCountdownChange?.Invoke(countDown);
	}
}
