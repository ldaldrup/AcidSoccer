using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	// reference to goals object
	public static Rules rules;

	public int teamIndex = 0;

	public void setRulesRef (Rules rulesRef)
	{
		rules = rulesRef;
	}

	void OnTriggerEnter (Collider other)
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
			// if the ball's owner is not part of the goal's team
			if (!rules.teams[teamIndex].players.Contains(rules.ball.owner))
			{
				foreach (Player player in rules.teams[rules.ball.owner.teamIndex].players)
				{
					player.score++;
				}
			}
			else 
			{
				foreach (Player player in rules.teams[rules.ball.owner.teamIndex].players)
				{
					player.score--;
				}
			}
		}
	}
}
