using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private Transform pathChild;
	[SerializeField] private float speed = 10f;

	int pathIndex = 1;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

		SubscribeEvents();
    }

	private void Update()
	{
		if (!GameMaster.Instance.IsGameOn)
			return;

		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			if (pathIndex <= 0)
				return;

			MoveRightLeft(-1);
		}

		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			if (pathIndex >= pathChild.childCount - 1)
				return;

			MoveRightLeft(1);
		}
	}

	private void SubscribeEvents()
	{
		GameMaster.Instance.OnLevelCompleted += ResetVelocity;
		GameMaster.Instance.OnLevelFailed += ResetVelocity;
	}

	private void FixedUpdate()
	{
		if (!GameMaster.Instance.IsGameOn)
			return;

		MoveForward();
	}

    void MoveForward()
	{
		Vector3 currentVelocity = rb.velocity;
		currentVelocity.z = speed * Time.fixedDeltaTime;
		rb.velocity = currentVelocity;
	}

	void MoveRightLeft(int pathIndexValue)
	{
		pathIndex += pathIndexValue;

		transform.DOMoveX(pathChild.GetChild(pathIndex).position.x, 0.25f).SetEase(Ease.InOutExpo);
	}

	private void ResetVelocity(int value)
	{
		rb.velocity = Vector3.zero;
	}
}
