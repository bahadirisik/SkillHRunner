using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBoostsUI : MonoBehaviour
{
    [SerializeField] private Image magnetIconImage;
    [SerializeField] private Image shieldIconImage;

	private void Start()
	{
		SubEvents();
	}

	private void SubEvents()
	{
		PlayerBoost.OnMagnetCollect += Magnet_OnMagnetCollect;
		PlayerBoost.OnShieldCollect += Shield_OnShieldCollect;
	}

	private void Shield_OnShieldCollect(bool value)
	{
		shieldIconImage.gameObject.SetActive(value);
	}

	private void Magnet_OnMagnetCollect(bool value)
	{
		magnetIconImage.gameObject.SetActive(value);
	}
}
