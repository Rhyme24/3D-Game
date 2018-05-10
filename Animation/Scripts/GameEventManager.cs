using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour {

    public delegate void ScoreAction();
    public static event ScoreAction OnScoreAction;

    public delegate void GameoverAction();
    public static event GameoverAction OnGameOver;

    public void PlayerEscape()
    {
        if (OnScoreAction != null)
        {
            OnScoreAction();
        }
    }

    public void GameOver()
    {
        if(OnGameOver!=null)
        {
            OnGameOver();
        }
    }
}
