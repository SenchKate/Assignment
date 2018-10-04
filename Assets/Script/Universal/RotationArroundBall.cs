
using UnityEngine;
using UnityEngine.EventSystems;

public class RotationArroundBall : MonoBehaviour {

	private Transform camer;
	private Transform pivot;
	private Vector3 localRotation;
	public float mouseSensibility = 4f;
	public float orbitSpeed = 10f;
	public bool disableRotation = false;
	 
	 

	// Use this for initialization
	void Start () {
		this.camer = this.transform;
		this.pivot = this.transform.parent;
		disableRotation = true;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (!EventSystem.current.IsPointerOverGameObject())
		{
			if (Input.GetMouseButtonDown(0))
			{
				disableRotation = false;
			}
			else if (Input.GetMouseButtonUp(0))
			{
				disableRotation = true;
			}

			if (disableRotation == false)
			{
				if (Input.GetAxis("Mouse X") != 0f || Input.GetAxis("Mouse Y") != 0f)
				{
					localRotation.x += Input.GetAxis("Mouse X") * mouseSensibility;
					localRotation.y -= Input.GetAxis("Mouse Y") * mouseSensibility;
					localRotation.y = Mathf.Clamp(localRotation.y, 0f, 90f);
				}

			}
			Quaternion QT = Quaternion.Euler(localRotation.y, localRotation.x, 0);
			this.pivot.rotation = Quaternion.Lerp(this.pivot.rotation, QT, Time.deltaTime * orbitSpeed);
		}
	}
}
