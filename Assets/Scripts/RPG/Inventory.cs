using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

	private void Awake()
	{
		if (!Instance)
		{
			Instance = this;
		}
		else Destroy(this);
	}

	public bool[] isFull;
    public GameObject[] slots;
}
