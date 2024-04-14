using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoost : MonoBehaviour
{
	public bool IsMagnetActive { get; set; }
	public bool IsShieldActive { get; set; }

	private void Start()
	{
		IsMagnetActive = false;
		IsShieldActive = false;
	}
}
