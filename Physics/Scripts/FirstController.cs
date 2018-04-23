using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneControl, IUserAction
{
    public ActionMode mode { get; set; }

    public IActionManager actionManager { get; set; }

    public ScoreRecorder scoreRecorder { get; set; }

  
    private int trial;
    private GameState gameState;
    public int round = 1;

    void Awake()
    {
        Director director = Director.getInstance();
        director.setFPS(60);
        director.currentSceneController = this;
        this.gameObject.AddComponent<ScoreRecorder>();
        this.gameObject.AddComponent<DiskFactory>();
        this.gameObject.AddComponent<CCActionManager>();
        
        gameState = GameState.START;
        scoreRecorder = Singleton<ScoreRecorder>.Instance;
        //actionManager = Singleton<CCActionManager>.Instance;
        setMode(ActionMode.KINEMATIC);
        LoadResources();
    }

    private void Update()
    {
        if(gameState == GameState.START)
        {
            scoreRecorder.Reset();
            trial = 10;
            round = 1;
            ThrowDisk();
            gameState = GameState.RUNNING;
        }
        if(gameState == GameState.NEXT_ROUND)
        {
            round++;
            gameState = GameState.RUNNING;
            trial = 10;
            ThrowDisk();
        }
        if(gameState == GameState.DROP)
        {
            gameState = GameState.RUNNING;
            trial--;
            if (trial == 0)
            {
                gameState = GameState.GAME_OVER;
            }
            else
            {
                ThrowDisk();
            }
        }
        
    }

    void ThrowDisk()
    {
        DiskFactory df = Singleton<DiskFactory>.Instance;
        GameObject disk = df.GetDisk(round);
        float y = UnityEngine.Random.Range(0f, 4f);
        Vector3 position = new Vector3(-disk.GetComponent<DiskData>().direction.x * 7, y, 0);
        disk.transform.position = position;
        disk.SetActive(true);
        actionManager.StartThrow(disk);
    }

    public void LoadResources()
    {
        
        GameObject greensward = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("prefabs/greensward"));
    }


    public void hit(Vector3 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);
        //Return the ray's hit
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];

            if (hit.collider.gameObject.GetComponent<DiskData>() != null)
            {
                scoreRecorder.AddRecord(round);
                DiskFactory df = Singleton<DiskFactory>.Instance;
                df.FreeDisk(hit.collider.gameObject);
                setGameState(GameState.ROUND_END);
            }

        }
    }

    

    public void setGameState(GameState gs)
    {
        gameState = gs;
    }

    public int getRound()
    {
        return round;
    }

    public int getScore()
    {
        return scoreRecorder.score;
    }

    public int getTrial()
    {
        
        return trial;
    }

    public GameState getGameState()
    {
        return gameState;
    }

    public ActionMode getMode()
    {
        return mode;
    }

    public void setMode(ActionMode m)
    {

        if (m == ActionMode.KINEMATIC)
        {
            this.gameObject.AddComponent<CCActionManager>();
        }
        else
        {
            this.gameObject.AddComponent<PhysicActionManager>();
        }

    }
}