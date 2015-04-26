using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	// player who last touched the ball
	// TODO: find better name
	public Player owner;

<<<<<<< HEAD
	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.collider.tag == "Player")
		{
			owner = other.collider.GetComponent<Player>();
			// test
			GetComponent<SpriteRenderer>().color = other.collider.GetComponent<SpriteRenderer>().color;
		}
	}
=======
    public void Start()
    {
        GetComponent<Rigidbody>().AddExplosionForce(7.0f, new Vector3(0,0,0),88.0f);
    }
>>>>>>> 296dc21c7823cf72e439077cb423d2e3ac287621
}
