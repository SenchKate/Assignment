using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCamera : MonoBehaviour {

	public Camera firstCamera;
	public Camera secondCamera;
	public Camera thirdCamera;
	public Camera forthCamera;
	public Canvas slider1;
	public Canvas slider2;
	public Canvas slider3;
	public Canvas slider4;



	public void Left()
	{
		if (firstCamera.enabled == true)
		{
			firstCamera.enabled = false;
			forthCamera.enabled = true;
			slider1.enabled =false;
			slider4.enabled = true;

		}
		else if (secondCamera.enabled == true)
		{
			firstCamera.enabled = true;
			secondCamera.enabled = false;
			slider2.enabled = false;
			slider1.enabled = true;

		}
		else if ( thirdCamera.enabled == true)
		{
			thirdCamera.enabled = false;
			secondCamera.enabled = true;
			slider3.enabled = false;
			slider2.enabled = true;
		}
		else if (forthCamera.enabled== true)
		{
			thirdCamera.enabled = true;
			forthCamera.enabled = false;
			slider4.enabled = false;
			slider3.enabled = true;
		}
	}

}
