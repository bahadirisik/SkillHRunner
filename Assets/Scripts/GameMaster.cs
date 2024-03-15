using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance { get; private set; }

	public event Action<int> OnCoinTake;
	public event Action<int> OnLevelCompleted;
	public event Action<int> OnLevelFailed;

	public bool IsGameOn { get; private set; }

	private int currentCoin = 0;

	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(this);
		}
	}

	private void Start()
	{
		IsGameOn = true;
	}

	public void CoinTake(int amount)
	{
		currentCoin += amount;

		OnCoinTake?.Invoke(currentCoin);
	}

	public void LevelCompleted()
	{
		SetGameOn(false);
		OnLevelCompleted?.Invoke(currentCoin);
	}

	public void LevelFailed()
	{
		SetGameOn(false);
		OnLevelFailed?.Invoke(currentCoin);
	}

	private void SetGameOn(bool value)
	{
		IsGameOn = value;
	}
}
