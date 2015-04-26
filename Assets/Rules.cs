using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

// keep track of rules and score
public class Rules : MonoBehaviour 
{
	public float rulechangeCooldown = 5;
	float rulechangeTimer = 0;

	public Text scoreboard;

	// all goals in the game
	Goal[] goals;

	// all players
	// test
	public Player[] players;

	// the ball
	public Ball ball;

	// teams. not all teams have to have members. have 1 team per player
	public Team[] teams;

	// Use this for initialization
	void Start () 
	{
		goals = (Goal[]) FindObjectsOfType<Goal>();
		initializeGoals ();
		ball.owner = teams[0].players[0];
	}
	
	// Update is called once per frame
	void Update () 
	{
		// test
		updateScoreboard ();
		rulechangeTimer -= Time.deltaTime;
		if (rulechangeTimer <= 0)
		{
			changeRules ();
			rulechangeTimer = rulechangeCooldown;
		}
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

	void changeRules ()
	{
		// change goals of teams
		foreach (Team team in teams)
		{
			team.goals.Clear();
		}
		List<Goal> goalsToAssign = new List<Goal>();
		// warning: stupid code ahead
		foreach (Goal goal in goals)
		{
			goalsToAssign.Add (goal);
		}
		while (goalsToAssign.Count > 0)
		{
			for (int t=0; t<teams.Length; t++)
			{
				int g = Random.Range (0, goalsToAssign.Count);
				teams[t].goals.Add (goalsToAssign[g]);
				goalsToAssign[g].gameObject.GetComponent<SpriteRenderer>().color = teams[t].color;
				goalsToAssign.RemoveAt (g);
			}
		}
	}
}
