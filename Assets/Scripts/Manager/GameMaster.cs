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
	public event Action<int> OnLevelPaused;

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
		IsGameOn = false;
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			ToggleStopGame();
		}
	}

	public void CoinTake(int amount)
	{
		currentCoin += amount;

		OnCoinTake?.Invoke(currentCoin);
	}

	public void LevelCompleted()
	{
		AudioManager.Instance.Play("Winning");
		SetGameOn(false);
		OnLevelCompleted?.Invoke(currentCoin);
	}

	public void LevelFailed()
	{
		AudioManager.Instance.Play("Fail");
		SetGameOn(false);
		OnLevelFailed?.Invoke(currentCoin);
	}

	private void SetGameOn(bool value)
	{
		IsGameOn = value;
	}

	public void StartTheGame()
	{
		SetGameOn(true);
	}

	public void ToggleStopGame()
	{
		OnLevelPaused?.Invoke(currentCoin);
		SetGameOn(IsGameOn ? false : true);
	}
}
