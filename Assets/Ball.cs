using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	// player who last touched the ball
	// TODO: find better name
	public Player owner;

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.collider.tag == "Player")
		{
			owner = other.collider.GetComponent<Player>();
			// test
			GetComponent<SpriteRenderer>().color = other.collider.GetComponent<SpriteRenderer>().color;
		}
	}
}
