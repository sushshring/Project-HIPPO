using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

    public int numToSpawn = 10;

	// Use this for initialization
	void Start () {
        if (numToSpawn > 0)
        {
            numToSpawn--;
            GameObject newAI = Instantiate(this.gameObject);
        }
     
        this.gameObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-10,10),Random.Range(-10,10));
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Motor>().hasMotor())
            kill();
    }

    // Update is called once per frame
    void Update () {

        //Create a movement AI for the enemy
        //Must discuss how to do this

        if(this.gameObject.transform.GetComponent<Rigidbody2D>().velocity.x == 0)
            this.gameObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-10, 10), this.gameObject.transform.GetComponent<Rigidbody2D>().velocity.y);
        if (this.gameObject.transform.GetComponent<Rigidbody2D>().velocity.y == 0)
            this.gameObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(this.gameObject.transform.GetComponent<Rigidbody2D>().velocity.x, Random.Range(-10, 10));

    }

    void kill()
    {
        print("Enemy collided with, destroying.");
        Destroy(this.gameObject);
    }
}
