
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform ball;
	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	private void LateUpdate()
	{
		Vector3 desiredPosition = ball.position + offset;
		Vector3 smoothedPostion = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPostion;
		transform.LookAt(ball);
	}
}
