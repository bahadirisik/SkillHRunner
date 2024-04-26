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

		if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			Crouch(2f, 1f, true);
		}

		if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
		{
			Crouch(7f, 3.5f, false);
		}
	}

	private void SubscribeEvents()
	{
		GameMaster.Instance.OnLevelCompleted += ResetVelocity;
		GameMaster.Instance.OnLevelFailed += ResetVelocity;
		GameMaster.Instance.OnLevelPaused += ResetVelocity;
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

	public void MoveRight()
	{
		if (pathIndex >= pathChild.childCount - 1)
			return;

		MoveRightLeft(1);
	}

	public void MoveLeft()
	{
		if (pathIndex <= 0)
			return;

		MoveRightLeft(-1);
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

	private void Crouch(float sizeY, float centerY, bool isCrouching)
	{
		GetComponentInChildren<Animator>().SetBool("Crouch", isCrouching);
		GetComponentInChildren<BoxCollider>().size = new Vector3(3f, sizeY, 3f);
		GetComponentInChildren<BoxCollider>().center = new Vector3(0f, centerY, 0.6f);
	}

	public void CrouchWithTimer()
	{
		StartCoroutine(CrouchTimer());
	}

	private IEnumerator CrouchTimer()
	{
		GetComponentInChildren<Animator>().SetBool("Crouch", true);
		GetComponentInChildren<BoxCollider>().size = new Vector3(3f, 2f, 3f);
		GetComponentInChildren<BoxCollider>().center = new Vector3(0f, 1f, 0.6f);

		yield return new WaitForSeconds(1f);

		GetComponentInChildren<Animator>().SetBool("Crouch", false);
		GetComponentInChildren<BoxCollider>().size = new Vector3(3f, 7f, 3f);
		GetComponentInChildren<BoxCollider>().center = new Vector3(0f, 3.5f, 0.6f);
	}
}
