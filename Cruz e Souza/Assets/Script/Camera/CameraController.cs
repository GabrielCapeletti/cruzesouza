﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Camera))]
public abstract class CameraController : MonoBehaviour
{
	private const float TOLERANCE = 0.1f;
	[Tooltip ("Following function target")]
	public Transform target;

	public float offSetX;
	public float offSetY;
	
}
