using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public enum AnimationStates { MoveLeft, MoveRight, Idle}

    public enum MovementStates { Right, Left, Up, Down, Idle}

    public enum Player { TheGood, TheUgly}

    public Player ControlScheme;

    private string[] keyMappingPlayerOne = { "w", "a", "s", "d", "q" };
    private string[] keyMappingPlayerTwo = { "i", "j", "k", "l", "u" };
    private string[] thisKeyMapping;

    public float MovementSpeed = 5;

	// Use this for initialization
	void Start () {
        
        if (ControlScheme == Player.TheGood)
        {
            thisKeyMapping = keyMappingPlayerOne;
        }
        else if (ControlScheme == Player.TheUgly)
        {
            thisKeyMapping = keyMappingPlayerTwo;
        }
        else
        {
            Debug.LogWarning("NO PLAYER WAS SET!!! Chose a control scheme for the player");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
        Vector3 currentPos = gameObject.transform.position;
        Vector3 desiredPos = currentPos;
        //UP
        if (Input.GetKeyDown(thisKeyMapping[0]))
        {
            desiredPos.z += MovementSpeed;
        }

        if (Input.GetKeyDown(thisKeyMapping[1]))
        {
            desiredPos.x += MovementSpeed;
        }

        if (Input.GetKeyDown(thisKeyMapping[2]))
        {
            desiredPos.z -= MovementSpeed;
        }

        if (Input.GetKeyDown(thisKeyMapping[3]))
        {
            desiredPos.x -= MovementSpeed;
        }

        GetComponent<Rigidbody>().MovePosition(desiredPos);
	}
}