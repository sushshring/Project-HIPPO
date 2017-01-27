using UnityEngine;
using System.Collections;

public class Motor : MonoBehaviour {

    //Make the object that this script is attached to a gameObject
    GameObject character =null;
	Rigidbody2D rigidBody = null;
    //Rate of movement for the gameObject
	float forcex = 2.0f;
	float forcey = 2.0f;


    // Use this for initialization
    void Start () {
        //Initialize the character object to the script's container
	}
	
	// Update is called once per frame
	void Update () {

        //Determine which key(s) are placed that the motor should capture
        if (Input.GetKey("w")||Input.GetKey("up"))
            moveUp();
        if (Input.GetKey("a") || Input.GetKey("left"))
            moveLeft();
        if (Input.GetKey("s") || Input.GetKey("down"))
            moveDown();
        if (Input.GetKey("d") || Input.GetKey("right"))
            moveRight();
            
	}

    //Move the attached object up a set number of units
    void moveUp()
    {
        print("Motor: Up");
		this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,forcey), ForceMode2D.Force);
    }

    //Move the attached object left a set number of units
    void moveLeft()
    {
        print("Motor: Left");

		this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-forcex,0), ForceMode2D.Force);
    }

    //Move the attached object down a set number of units
    void moveDown()
    {
        print("Motor: Down");

		this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-forcey), ForceMode2D.Force);
    }

    //Move the attached object right a set number of units
    void moveRight()
    {
        print("Motor: Right");

		this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forcex,0), ForceMode2D.Force);
    }

}