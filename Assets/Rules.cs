using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// keep track of rules and score
public class Rules : MonoBehaviour 
{
	public Text scoreboard;

	// all goals in the game
	public Goal[] goals;

	// all players
	public Player[] players;

	// the ball
	public Ball ball;

	// teams. not all teams have to have members. have 1 team per player
	public Team[] teams;

	// Use this for initialization
	void Start () 
	{
		initializeGoals ();
		ball.owner = teams[0].players[0];
	}
	
	// Update is called once per frame
	void Update () 
	{
		// test
		updateScoreboard ();
	}

	void updateScoreboard ()
	{
		scoreboard.text = "";
		foreach (Team team in teams)
		{
			foreach (Player player in team.players)
			{
				scoreboard.text += " Player" + player.id + ": " + player.score + " ";
			}
		}
	}

	void initializeGoals ()
	{
		Goal.rules = this;
	}

	void initializePlayers ()
	{
		for (int i=0; i<players.Length; i++)
		{
			players[i].id = i;
		}
	}
}
