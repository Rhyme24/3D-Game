using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour, IsceneController,diskAction {

    public ScoreRecorder scoreRecorder = new ScoreRecorder();
    
    private int trial = 1;
    private int round = 0;
    
    bool game_over = false;
    bool next_round = false;
    private DiskFactory df = DiskFactory.GetInstance();
    private int score;
    
  

    void Awake()
    {
        SSDirector director = SSDirector.getInstance();
        director.setFPS(60);
        director.currentSceneController = this;
        director.currentSceneController.LoadResources();
    }

    public void LoadResources()
    {
        df.GetDisk(round);
        
    }

    public void Boomshakalaka(GameObject disk)
    {
        
        df.FreeDisk(disk);
        
        if (df.GetCount() == 0)
        {
            next_round = true;
            scoreRecorder.AddScore(round + 1);
            trial = 1;
        }
        
        
    }

    public void Drop(GameObject disk)
    {
        trial++;
        if(trial > 10)
        {
            game_over = true;
            df.FreeDisk(disk);
        }
        else
        {
            df.FreeDisk(disk);
            df.GetDisk(round);
           
        }
    }

	// Use this for initialization
	void Start () {
       
    }


    // Update is called once per frame
    void Update () {
        score = scoreRecorder.getScore();
	}

    void OnGUI()
    {

        GUI.Box(new Rect(Screen.width / 2 - 75, 10, 150, 55), "Round " + (round + 1) + "\nYour score:  " + score + "\nYour trial left:  " + (11-trial));
        if(next_round)
        {
            GUI.Window(0, new Rect(Screen.width / 2 - Screen.width / 12, Screen.height / 2 - Screen.height / 12, Screen.width / 6, Screen.height / 6), next_round_window, "Success !");
        }
        if (game_over)
        {
            GUI.Window(0, new Rect(Screen.width / 2 - Screen.width / 12, Screen.height / 2 - Screen.height / 12, Screen.width / 6, Screen.height / 6), game_over_window, "Game Orver!");
        }
    }

    void next_round_window(int id)
    {
        if (GUI.Button(new Rect(Screen.width / 24, Screen.height / 24 + 5, Screen.width / 12, Screen.height / 12), "Next"))
        {
            NextRound();
        }

    }

    private void NextRound()
    {
        round++;
        next_round = false;
        df.GetDisk(round);
        
    }

    void game_over_window(int id)
    {
        if (GUI.Button(new Rect(Screen.width / 24, Screen.height / 24 + 5, Screen.width / 12, Screen.height / 12), "Restart"))
        {
            Debug.Log("Restart");

            Restart();
        }

    }

    private void Restart()
    {
        
        
        trial = 1;
        round = 0;
        
        game_over = false;
        next_round = false;
        
        scoreRecorder.Reset();
        df.GetDisk(round);
    }
}
