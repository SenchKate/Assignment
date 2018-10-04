using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathForThird : MonoBehaviour
{

	public Transform ball;
	private float speed = 0;
	private int i = 0;
	private float x2 = 0;
	private float y2 = 0;
	private float z2 = 0;
	private int clicks = 0;
	private float copyAgain;
	private bool copyBool;

	private float copy;
	private double[] xValue = new double[26] { 0, 1.295867672, 2.609753061, 3.940266729, 5.286007104, 6.645561307, 8.017505989, 9.400408169, 10.79282607, 12.19331, 13.60040314, 15.01264248, 16.42855963, 17.8466817, 19.26553215, 20.6836317, 22.09949917, 23.51165234, 24.91860885, 26.3188871, 27.71100703, 29.09349112, 30.46486514, 31.82365914, 33.16840821, 34.55603503 };
	private double[] yValue = new double[26] { 0, 2.903831765, 5.56610333, 7.986814696, 10.16596586, 12.10355683, 13.79958759, 15.25405816, 16.46696852, 17.43831869, 18.16810865, 18.65633842, 18.90300798, 18.90811735, 18.67166651, 18.19365548, 17.47408424, 16.51295281, 15.31026117, 13.86600934, 12.1801973, 10.25282507, 8.083892634, 5.673399999, 3.021347164, 0 };
	private double[] zValue = new double[26] { 10, 10.49041295, 10.93182643, 11.32374433, 11.66570557, 11.95728435, 12.19809043, 12.38776938, 12.52600276, 12.61250837, 12.6470404, 12.62938962, 12.55938349, 12.43688633, 12.26179936, 12.03406087, 11.75364621, 11.42056788, 11.03487553, 10.596656, 10.10603328, 9.563168474, 8.968259766, 8.32154234, 7.623288287, 6.838702514 };

	private void OnEnable()
	{
		i = 0;
		ball.position = new Vector3(0, 0, 10);
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
		else if (clicks > 1 && copyBool == true )
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
		while (i < 26)
		{
			if (GetComponent<PathForThird>().enabled == false)
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
					if (GetComponent<PathForThird>().enabled == true)
					{
						float step = speed * Time.deltaTime;
						ball.position = Vector3.MoveTowards(ball.position, new Vector3(x, y, z), step);
						yield return null;
					}
					if (GetComponent<PathForThird>().enabled == false)
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
