using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour {

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 40), "Quit"))
            Application.Quit();
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 60, 100, 40), "Begin"))
            Application.LoadLevel(Application.loadedLevel+1);
    }
}
