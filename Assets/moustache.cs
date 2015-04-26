using UnityEngine;
using System.Collections;

public class moustache : MonoBehaviour {
	// Use this for initialization
	float currentTime;
	int nextSwing;
	bool leftright;
	Rigidbody rb;
	public float torque;
	
	void Start () {
		nextSwing = 0;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		//
		Debug.Log (leftright);
		if (nextSwing == 60) {
			if(!leftright){
				leftright = true;
			}
			else if(leftright){
				leftright = false;
			}
			nextSwing = 0;
		}
		if (leftright) {
			rb.AddRelativeForce (new Vector3 (-2.6f, 0.0f, 0.00f));
		}
		if (!leftright) {
			rb.AddRelativeForce (new Vector3 (0.6f, 0.0f, 0.00f));
		}


		nextSwing ++;

		//rotate


		rb.AddTorque(transform.up * torque);
		
	}
}
