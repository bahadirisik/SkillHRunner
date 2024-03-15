using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCompletedUI : MonoBehaviour
{
	[SerializeField] private GameObject levelCompletedPanel;
	[SerializeField] private TextMeshProUGUI winningScoreText;
	[SerializeField] private GameObject levelFailedPanel;
	[SerializeField] private TextMeshProUGUI failScoreText;

	private void Start()
	{
		GameMaster.Instance.OnLevelCompleted += GameMaster_OnLevelCompleted;
		GameMaster.Instance.OnLevelFailed += GameMaster_OnLevelFailed;
	}

	private void GameMaster_OnLevelFailed(int totalCoin)
	{
		levelFailedPanel.SetActive(true);
		failScoreText.text = "Score : " + totalCoin;
	}

	private void GameMaster_OnLevelCompleted(int totalCoin)
	{
		levelCompletedPanel.SetActive(true);
		winningScoreText.text = "Score : " + totalCoin;
	}
}
