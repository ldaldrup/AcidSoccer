using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Team
{
	public Color color;
	public Player[] players;
	// goals that belong to the team
	// points are scored by getting the ball into opposing team's goal
	public List<Goal> goals = new List<Goal>();
	
}
