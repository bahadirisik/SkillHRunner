using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObstacleMovement : MonoBehaviour
{
	[Header("Move Logic")]
	[SerializeField] private Transform[] walkPoints;
	[SerializeField] private float moveSpeed = 4f;
	private int positionIndex = 0;
	private int positionIndexSetter = -1;
	private bool isMoving = true;

	//private float rotationSpeed = 5f;

	Rigidbody rb;

	private void Start()
	{
		positionIndexSetter = -1;
		rb = GetComponent<Rigidbody>();
		positionIndex = 0;
		isMoving = true;
	}

	void Update()
	{
		if (!GameMaster.Instance.IsGameOn)
			return;

		//Bir sonraki yürüme noktasýna varýp varmadýðýný kontrol ediyor
		if (isMoving && Vector3.Distance(transform.position, walkPoints[positionIndex].position) <= 0.2f)
		{
			//Son noktaya gelince ilerleme yönünü ters çevirip tersten ilerliyor, en baþa gelince de tekrar ileri gitmesini saðlýyor
			//ilk ve son nokta arasýnda sürekli bir döngü oluþturuyor
			if (positionIndex <= 0 || positionIndex >= walkPoints.Length - 1)
			{
				positionIndexSetter *= -1;
			}
			positionIndex += positionIndexSetter;
		}

		MoveToNextPoint();
	}

	//Daha pürüzsüz dönüþler için late update içinde çaðýrýyoruz dönme fonksiyonunu
	/*private void LateUpdate()
	{
		LookAtWalkPoint();
	}*/

	//Bir sonraki yürüme noktasýna ilerleme
	private void MoveToNextPoint()
	{
		isMoving = true;
		Vector3 dir = walkPoints[positionIndex].position - transform.position;
		rb.MovePosition(transform.position + dir.normalized * moveSpeed * Time.fixedDeltaTime);
	}

	//Gittiði yöne bakma
	/*private void LookAtWalkPoint()
	{
		Quaternion lookRotation = Quaternion.LookRotation(walkPoints[positionIndex].position - transform.position);

		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
	}*/
}
