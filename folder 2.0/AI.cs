using UnityEngine;
using System.Collections;


public class AI : MonoBehaviour {

    public int numToSpawn = 10;
    public float vRange = 10;
    public bool isFirst = true;


	// Use this for initialization
	void Start () {
        if (isFirst)
        {
            numToSpawn = (Application.loadedLevel) * 10;
            vRange = (Application.loadedLevel) * 5;
            isFirst = false;
        }
        if (numToSpawn > 0)
        {
            numToSpawn--;
            GameObject newAI = Instantiate(this.gameObject);
        }
        this.gameObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-vRange,vRange),Random.Range(-vRange,vRange));
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "Hippo")
            kill();
    }

    // Update is called once per frame
    void Update () {

		//Create a movement AI for the enemy

		if ((int)this.gameObject.transform.GetComponent<Rigidbody2D> ().velocity.x == 0)
			this.gameObject.transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Random.Range (-vRange, vRange), this.gameObject.transform.GetComponent<Rigidbody2D> ().velocity.y);
		if ((int)this.gameObject.transform.GetComponent<Rigidbody2D> ().velocity.y == 0)
			this.gameObject.transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.gameObject.transform.GetComponent<Rigidbody2D> ().velocity.x, Random.Range (-vRange, vRange));

		GameObject[] hippoPos = GameObject.FindGameObjectsWithTag ("Hippo");

		if (Application.loadedLevel >= 3) {
			foreach (GameObject hippo in hippoPos) {
				if (Vector2.Distance (hippo.transform.position, this.gameObject.transform.position) < 5) {
					this.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (hippo.GetComponent<Rigidbody2D> ().velocity.x * 0.85f, hippo.GetComponent<Rigidbody2D> ().velocity.y * 0.85f);
				}
			}
		}
	}
    void kill()
    {
        print("Enemy collided with, destroying.");
        Destroy(this.gameObject);
    }
}
