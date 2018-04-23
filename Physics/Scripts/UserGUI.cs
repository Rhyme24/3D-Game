using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    private IUserAction action;
    private int score;
    private int trial;
    private int round;
    
    // Use this for initialization  
    void Start()
    {
        action = Director.getInstance().currentSceneController as IUserAction;
        //Debug.Log(action.getTrial());
    }

    private void Update()
    {
        Debug.Log("hi");
        score = action.getScore();
        trial = action.getTrial();
        round = action.getRound();
    }

    void OnGUI()
    {
        //Debug.Log(action == null);
        //Debug.Log(action.getTrial());
        
        
        GUI.Box(new Rect(Screen.width / 2 - 75, 10, 150, 55), "Round " + (round) + "\nYour score:  " + score + "\nYour trial left:  " + (trial));
        if (action.getGameState()==GameState.ROUND_END)
        {
            GUI.Window(0, new Rect(Screen.width / 2 - Screen.width / 12, Screen.height / 2 - Screen.height / 12, Screen.width / 6, Screen.height / 6), next_round_window, "Success !");
        }
        if (action.getGameState() == GameState.GAME_OVER)
        {
            GUI.Window(0, new Rect(Screen.width / 2 - Screen.width / 12, Screen.height / 2 - Screen.height / 12, Screen.width / 6, Screen.height / 6), game_over_window, "Game Orver!");
        }
        if (Input.GetButtonDown("Fire1"))
        {

            Vector3 pos = Input.mousePosition;
            action.hit(pos);

        }

    }

    void next_round_window(int id)
    {
        if (GUI.Button(new Rect(Screen.width / 24, Screen.height / 24 + 5, Screen.width / 12, Screen.height / 12), "Next"))
        {
            action.setGameState(GameState.NEXT_ROUND);
        }

    }

    void game_over_window(int id)
    {
        if (GUI.Button(new Rect(Screen.width / 24, Screen.height / 24 + 5, Screen.width / 12, Screen.height / 12), "Restart"))
        {
            Debug.Log("Restart");

            action.setGameState(GameState.START);
        }

    }

}
