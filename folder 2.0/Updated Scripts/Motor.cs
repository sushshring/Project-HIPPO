using UnityEngine;

//On load if not the first instance of the level, the keyListener fails

public class Motor : MonoBehaviour {

    //Rate of movement for the gameObject
    public float forcey = 2;
    public float forcex = 2;

    //How many Hippos you want?
    public int maxHippos;

    //Is this hippo Active?
    public bool activeHippo = true;
    public short numbHippos = 0;
    public short myNum = 0;

    //Animation fileNames
    public string sitAnim = "";
    public string upAnim = "";
    public string downAnim = "";
    public string leftAnim = "";
    public string rightAnim = "";

    // Use this for initialization
    void Start()
    {
        //Initialize the character object to the script's container
        Time.timeScale = 1.0f;
        this.gameObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(0, 5), Random.Range(-5, 5));
        maxHippos = Application.loadedLevel;
        newHippo();
    }

    // Update is called once per frame
    void Update () {

        //Determine which key(s) are placed that the motor should capture
        if (activeHippo)
        {
            if (Input.GetKey("w") || Input.GetKey("up"))
                moveUp();
            if (Input.GetKey("a") || Input.GetKey("left"))
                moveLeft();
            if (Input.GetKey("s") || Input.GetKey("down"))
                moveDown();
            if (Input.GetKey("d") || Input.GetKey("right"))
                moveRight();
        }

        //Read out the X and Y velocities
        float xVel = this.gameObject.GetComponent<Rigidbody2D>().velocity.x;
        float yVel = this.gameObject.GetComponent<Rigidbody2D>().velocity.y;

		//Current angle of hippo
		float currentAngle = Mathf.Rad2Deg * (Mathf.Atan2 (yVel, xVel));

        //Correct the rotation to align with the motion
        this.gameObject.GetComponent<Rigidbody2D>().MoveRotation(currentAngle);

//        if (xVel == 0 && yVel == 0)
//            sit();
//        if (xVel > 0)
//            right();
//        if (xVel < 0)
//            left();
//        if (yVel > 0)
//            up();
//        if (yVel < 0)
//            down();

		//Error catching for improper collision causin hippos to shoot off
		if (this.gameObject.GetComponent<Rigidbody2D> ().velocity.magnitude > 15)
			this.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (3 * Mathf.Cos (currentAngle), 3 * Mathf.Sin (currentAngle));

        if (Input.GetKeyDown("space"))
            newHippo();

        if (Input.GetKeyDown("1"))
            if (myNum == 0)
                activeHippo = true;
            else
                activeHippo = false;
        if (Input.GetKeyDown("2"))
            if (myNum == 1)
                activeHippo = true;
            else
                activeHippo = false;
        if (Input.GetKeyDown("3"))
            if (myNum == 2)
                activeHippo = true;
            else
                activeHippo = false;
        if (Input.GetKeyDown("4"))
            if (myNum == 3)
                activeHippo = true;
            else
                activeHippo = false;
        if (Input.GetKeyDown("5"))
            if (myNum == 4)
                activeHippo = true;
            else
                activeHippo = false;
        if (Input.GetKeyDown("6"))
            if (myNum == 5)
                activeHippo = true;
            else
                activeHippo = false;
        if (Input.GetKeyDown("7"))
            if (myNum == 6)
                activeHippo = true;
            else
                activeHippo = false;
        if (Input.GetKeyDown("8"))
            if (myNum == 7)
                activeHippo = true;
            else
                activeHippo = false;
        if (Input.GetKeyDown("9"))
            if (myNum == 8)
                activeHippo = true;
            else
                activeHippo = false;
        if (Input.GetKeyDown("0"))
            if (myNum == 9)
                activeHippo = true;
            else
                activeHippo = false;

    }

    void newHippo()
    {
        print("New Hippo");
        // Create a new instance of the hippo, and control it with number keys
        if (numbHippos < maxHippos -1)
        {
            numbHippos++;
            if (activeHippo)
            {
                GameObject newHippo = Instantiate(this.gameObject);
                newHippo.transform.Translate(4, 0, 0, Camera.main.transform);
                newHippo.GetComponent<Motor>().myNum++;
                activeHippo = false;
            }
        }
    }


    //Move the attached object up a set number of units
    void moveUp()
    {
        print("Motor: Up");
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forcey), ForceMode2D.Force);
    }

    //Move the attached object left a set number of units
    void moveLeft()
    {
        print("Motor: Left");
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-forcex, 0), ForceMode2D.Force);
    }

    //Move the attached object down a set number of units
    void moveDown()
    {
        print("Motor: Down");
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -forcey), ForceMode2D.Force);
    }

    //Move the attached object right a set number of units
    void moveRight()
    {
        print("Motor: Right");
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forcex, 0), ForceMode2D.Force);
    }

    public bool hasMotor()
    {
        return true;
    }

}