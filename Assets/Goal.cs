using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	// reference to goals object
	public static Rules rules;

	public void setRulesRef (Rules rulesRef)
	{
		rules = rulesRef;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Ball")
		{
			//Ball ball = GetComponent<Ball>();
			// test
			if (rules == null)
			{
				Debug.Log ("not initialized");
				return;
			}
			rules.ball.owner.score++;
		}
	}
}
