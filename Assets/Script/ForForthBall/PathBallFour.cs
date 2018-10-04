using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBallFour : MonoBehaviour
{



public Transform ball;
	private float speed = 0;
	private int i = 0;
	private float x2 = 0;
	private float y2 = 0;
	private float z2 = 0;
	private int clicks = 0;
	private bool copyBool;
	private float copy;
	private float copyAgain;
	private double[] xValue = new double[6] { 0, 6.654262116, 13.6183642, 20.71071213, 27.74635544, 34.55603503 };
	private double[] yValue = new double[6] { 0, 12.11512397, 18.17584714, 18.18216951, 12.13409108, 0 };
	private double[] zValue = new double[6] { 15, 16.95897921, 17.6471441, 17.02919631, 15.09285012, 11.83870251 };

	private void OnEnable()
	{
		i = 0;
		ball.position = new Vector3(0, 0, 15);
		x2 = 0;
		y2 = 0;
		z2 = 0;
		clicks = 0;
		copyBool = false;

	}

	private void OnMouseDown()
	{
		clicks = clicks + 1;

		if (FirstClick() == true)
		{
			StartCoroutine(ReachGoal());
		}
		else if (clicks > 1 && copyBool == true)
		{
			speed = copy;
			copyBool = false;
			copy = 0;
		}

		else
		{
			return;
		}


	}

	IEnumerator ReachGoal()
	{
		if (copyAgain != 0)
		{
			speed = copyAgain;
		}
		copyBool = false;

		while (i < 6)
		{
			if (GetComponent<PathBallFour>().enabled == false)
			{
				break;
			}

			double a = xValue[i];
			float x1 = (float)a;
			float x = x1 + x2;
			double b = yValue[i];
			float y1 = (float)b;
			float y = y1 + y2;
			double c = zValue[i];
			float z1 = (float)c;
			float z = z1 + z2;

			if (Vector3.Distance(ball.position, new Vector3(x, y, z)) > 0)
			{
				while (Vector3.Distance(ball.position, new Vector3(x, y, z)) > 0)
				{
					if (GetComponent<PathBallFour>().enabled == true)
					{
						float step = speed * Time.deltaTime;
						ball.position = Vector3.MoveTowards(ball.position, new Vector3(x, y, z), step);
						yield return null;
					}
					if (GetComponent<PathBallFour>().enabled == false)
					{
						break;
					}
				}

			}

			else
			{

				i = i + 1;
			}

		}

		i = 0;
		x2 = ball.position[0];
		y2 = ball.position[1];
		z2 = ball.position[2];
		clicks = 0;
		copyAgain = speed;

	}
	public void SaveSpeed()
	{
		if (speed != 0)
		{
			copy = speed;
			speed = 0;
		}
		copyBool = true;

	}




	public void Speed(float speedControl)
	{
		speed = speedControl * 100;
		copyAgain = speed;
	}


	bool FirstClick()
	{
		if (clicks == 1)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}