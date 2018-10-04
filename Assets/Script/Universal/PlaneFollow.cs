using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFollow : MonoBehaviour {

	public Transform ball;

	private void LateUpdate()
	{
	
		transform.position = new Vector3(ball.position.x , -0.49f, ball.position.z);


	}
}
