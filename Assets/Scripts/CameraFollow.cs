using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z);
    }
}
