using UnityEngine;
using System.Collections;

[System.Serializable]
public class Team
{
	public Color color;
	public Player[] players;
	// goals that belong to the team
	// points are scored by getting the ball into opposing team's goal
	public GameObject[] goals;
	
}
