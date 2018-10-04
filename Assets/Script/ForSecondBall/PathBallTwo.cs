using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBallTwo : MonoBehaviour
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
	private double[] xValue = new double[52] { 0, 0.6332146823, 1.270932612, 1.912991025, 2.55922641, 3.209474526, 3.863570429, 4.521348494, 5.182642441, 5.847285354, 6.51510971, 7.185947397, 7.859629744, 8.535987541, 9.214851063, 9.896050095, 10.57941396, 11.26477153, 11.95195127, 12.64078124, 13.33108914, 14.02270233, 14.71544785, 15.40915241, 16.10364251, 16.79874435, 17.49428393, 18.19008705, 18.88597935, 19.58178631, 20.27733327, 20.97244551, 21.66694821, 22.3606665, 23.0534255, 23.74505033, 24.43536611, 25.12419805, 25.81137141, 26.49671155, 27.18004396, 27.86119428, 28.53998834, 29.21625213, 29.88981191, 30.56049415, 31.22812561, 31.89253337, 32.55354478, 33.21098759, 33.86468989, 34.55603503 };
	private double[] yValue = new double[52] { 0, 1.454356267, 2.850608334, 4.188756201, 5.468799868, 6.690739335, 7.854574602, 8.960305669, 10.00793254, 10.9974552, 11.92887367, 12.80218794, 13.617398, 14.37450387, 15.07350554, 15.71440301, 16.29719627, 16.82188534, 17.28847021, 17.69695087, 18.04732734, 18.33959961, 18.57376767, 18.74983154, 18.86779121, 18.92764668, 18.92939794, 18.87304501, 18.75858788, 18.58602654, 18.35536101, 18.06659128, 17.71971734, 17.31473921, 16.85165688, 16.33047035, 15.75117961, 15.11378468, 14.41828555, 13.66468221, 12.85297468, 11.98316295, 11.05524701, 10.06922688, 9.025102548, 7.922874015, 6.762541282, 5.544104349, 4.267563216, 2.932917883, 1.54016835, 0 };
	private double[] zValue = new double[52] { 5, 5.246611133, 5.481499569, 5.704603647, 5.915863711, 6.115222123, 6.302623272, 6.478013579, 6.641341507, 6.79255757, 6.931614333, 7.058466431, 7.173070562, 7.275385506, 7.365372122, 7.44299336, 7.508214261, 7.56100197, 7.601325733, 7.629156908, 7.644468965, 7.647237494, 7.637440207, 7.615056943, 7.580069671, 7.532462492, 7.472221644, 7.399335503, 7.313794587, 7.215591558, 7.104721221, 6.981180529, 6.844968585, 6.696086638, 6.534538089, 6.36032849, 6.173465542, 5.973959097, 5.761821159, 5.537065879, 5.299709561, 5.049770653, 4.78726975, 4.512229594, 4.224675066, 3.924633192, 3.612133131, 3.28720618, 2.949885769, 2.600207453, 2.238208916, 1.838702514 };

	private void OnEnable()
	{
		i = 0;
		ball.position = new Vector3(0, 0, 5);
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

		while (i < 52)
		{
			if (GetComponent<PathBallTwo>().enabled == false)
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
					if (GetComponent<PathBallTwo>().enabled == true)
					{
						float step = speed * Time.deltaTime;
						ball.position = Vector3.MoveTowards(ball.position, new Vector3(x, y, z), step);
						yield return null;
					}
					if (GetComponent<PathBallTwo>().enabled == false)
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


