using UnityEngine;
using System.Collections;

public class volume : MonoBehaviour {

    public bool collided = false;
    public bool paused = false;
    public string pauseKey = "escape";
    public bool gameWin = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Are there Enemies Left?
        if(GameObject.FindGameObjectsWithTag("Enemy").Length  == 0)
        {
            win();
        }

        if (Input.GetKeyDown(pauseKey))
            pause();

	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Motor>().hasMotor())
            kill(collision);
    }

    void OnGUI()
    {
        if (collided)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 40), "Quit"))
                quit();
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 60, 100, 40), "New Game"))
                newGame();
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 120, 100, 40), "Resume"))
                resumeGame();
        }
        else if (paused)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 40), "Quit"))
                quit();
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 60, 100, 40), "Resume Game"))
                resumeGame();
        }else if (gameWin)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 60, 100, 40), "Quit"))
                quit();
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 40), "Restart Level"))
                Application.LoadLevel(Application.loadedLevel);
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 60, 100, 40), "Next Level"))
                Application.LoadLevel(Application.loadedLevel + 1);
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 120, 100, 40), "You Won!");
        }

    }

    void kill(Collision2D collision)
    {
        Time.timeScale = 0.0f;
        print("You Ded!\n#RIP in pizza");
        collided = true;
        print(collided);

        collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        collision.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
    }

    void resumeGame()
    {
        print("Resuming Game");
        Time.timeScale = 1.0f;
        collided = false;
        paused = false;
        print(collided);
    }

    void quit()
    {
        Application.Quit();
    }

    void newGame()
    {
        //Fix load error
        Application.LoadLevel(0);
    }

    void pause()
    {
        print("Pausing Game");
        Time.timeScale = 0.0f;
        paused = true;

    }

    void win()
    {
        gameWin = true;
        Time.timeScale = 0.0f;
    }

}
