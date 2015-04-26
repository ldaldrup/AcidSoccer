using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public enum AnimationStates { MoveLeft, MoveRight, Idle, Kick, HandUp}

    public enum MovementStates { Right, Left, Up, Down, Idle}
    private MovementStates currentDirection = MovementStates.Idle;
    public enum Context { HandRules, FootRules}

    public enum Player { TheGood, TheUgly}

    public Player ControlScheme;

    private AnimationStates currentAnimation = AnimationStates.Idle;

    public Context currentContext;

    private GameObject ballOwned;

    private string[] keyMappingPlayerOne = { "w", "a", "s", "d", "q" };
    private string[] keyMappingPlayerTwo = { "i", "j", "k", "l", "u" };
    private string[] thisKeyMapping;

    public float MovementSpeed = 5;

    void OnCollisionEnter(Collision collision)
    { 
        if( collision.collider.CompareTag("Ball"))
        {
           ballOwned =  collision.collider.gameObject;
           freezeBall();
        }
    }

    private void freezeBall()
    {
        ballOwned.GetComponent<Rigidbody>().AddForce(
-1 * ballOwned.GetComponent<Rigidbody>().velocity, ForceMode.VelocityChange);
    }

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

        if (ballOwned != null)
        {
            freezeBall();
        }

        currentDirection = MovementStates.Idle;
        Vector3 currentPos = gameObject.transform.position;
        Vector3 desiredPos = currentPos;
        //UP
        if (Input.GetKey(thisKeyMapping[0]))
        {
            desiredPos.z += MovementSpeed;
            currentDirection = MovementStates.Up;
            GetComponent<Animator>().SetTrigger("WalkUp");
        }

        if (Input.GetKey(thisKeyMapping[1]))
        {
            desiredPos.x -= MovementSpeed;
            currentAnimation = AnimationStates.MoveLeft;
            currentDirection = MovementStates.Left;
        }

        if (Input.GetKey(thisKeyMapping[2]))
        {
            desiredPos.z -= MovementSpeed;
            currentDirection = MovementStates.Down;
            GetComponent<Animator>().SetTrigger("WalkDown");
        }

        if (Input.GetKey(thisKeyMapping[3]))
        {
            desiredPos.x += MovementSpeed;
            currentAnimation = AnimationStates.MoveRight;
            currentDirection = MovementStates.Right;
        }
        if (Input.GetKey(thisKeyMapping[4]))
        {
            if (currentContext == Context.FootRules)
            {
                currentAnimation = AnimationStates.Kick;
                GetComponent<Animator>().SetTrigger("Kick");
                PushOwnedBall();
            }

            if (currentContext == Context.HandRules)
            {
                currentAnimation = AnimationStates.HandUp;
                GetComponent<Animator>().SetTrigger("Hand");
                PushOwnedBall();
                
            }
        }

        GetComponent<Rigidbody>().MovePosition(desiredPos);

	}

    private bool PushOwnedBall()
    {
        if (ballOwned == null)
        {
            return false;
        }

        //ballOwned.GetComponent<Rigidbody>().AddRelativeTorque(-1 * ballOwned.GetComponent<Rigidbody>()., ForceMode.VelocityChange);

        float force = 9;

        //if (currentDirection == MovementStates.Left)
        //{
        //    ballOwned.GetComponent<Rigidbody>().AddForce(force, 0.0f, 0.0f);
        //}
        ballOwned.GetComponent<Rigidbody>().AddForce(force, 0.0f, 0.0f);
        ballOwned = null;
        return true;
    }
}