using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{

	private TrailRenderer line;
	public Transform ball;
	void Start()
	{
		line = GetComponent<TrailRenderer>();
		line.time = 1f;
	}
	private void Update()
	{

		line.time +=  Time.deltaTime;
	
	}
}

