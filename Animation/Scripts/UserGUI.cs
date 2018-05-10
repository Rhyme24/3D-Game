using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour {

    private IUserAction action;
    private int score;

	// Use this for initialization
	void Start () {
        action = SSDirector.GetInstance().CurrentScenceController as IUserAction;
	}
	
	// Update is called once per frame
	void Update () {
        score=action.getScore();
	}

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2 - 75, 10, 150, 55),  "\nYour score:  " + score );
        if (action.getGameState() == GameState.GAMEOVER)
        {
            GUI.Window(0, new Rect(Screen.width / 2 - Screen.width / 12, Screen.height / 2 - Screen.height / 12, Screen.width / 6, Screen.height / 6), game_over_window, "Game Orver!");

        }

    }

    void game_over_window(int id)
    {
        if (GUI.Button(new Rect(Screen.width / 24, Screen.height / 24 + 5, Screen.width / 12, Screen.height / 12), "Restart"))
        {
            Debug.Log("Restart");

            action.restart();
        }

    }

}
