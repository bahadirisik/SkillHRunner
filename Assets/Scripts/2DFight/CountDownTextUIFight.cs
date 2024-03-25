using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownTextUIFight : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countDownText;

	private void Start()
	{
		GameMasterFightGame.Instance1.OnCountdownChange += GameMasterFightGame_OnCountdownChange;
	}

	private void GameMasterFightGame_OnCountdownChange(float countdown)
	{
		countDownText.text = countdown.ToString("F0");
	}
}
