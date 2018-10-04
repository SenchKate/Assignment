using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleClick : MonoBehaviour {

	public int clicks = 0;
	public float delaytime = 0.5f;
	private TrailRenderer line;
	private void Start()
	{
		line = GetComponent<TrailRenderer>();
	}

	private void OnMouseDown()
	{ 
		clicks = clicks + 1;
		StartCoroutine(ClickedOnce());
	}

	IEnumerator ClickedOnce()
	{
		if (clicks > 1)
		{
			clicks = 0;
			GetComponent<Path>().enabled = false;
			StartCoroutine(WaitToRestart());
		}
		yield return new WaitForSeconds(delaytime);
		clicks = 0;
	}


	IEnumerator WaitToRestart(){
		yield return new WaitForSeconds(0.01f);
		line.time = 0;
		GetComponent<Path>().enabled = true;

	}
}




