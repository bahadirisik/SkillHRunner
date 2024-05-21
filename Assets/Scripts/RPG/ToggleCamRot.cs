using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ToggleCamRot : MonoBehaviour
{
	[SerializeField] private CinemachineFreeLook cam;
    private bool isMouseActive;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		isMouseActive = false;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			ToggleMouse();
		}
	}

	private void ToggleMouse()
	{
		isMouseActive = !isMouseActive;
		cam.enabled = !isMouseActive;
		Cursor.visible = isMouseActive;
		Cursor.lockState = isMouseActive ? CursorLockMode.Confined : CursorLockMode.Locked;
	}
}
