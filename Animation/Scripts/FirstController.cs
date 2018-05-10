using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState:int { GAMEOVER,RUNNING,RESTART}

public class FirstController : MonoBehaviour, ISceneController, IUserAction {

    PatrolFactory df = null;
    GameState gamestate;
    private GameObject player;
    private int score;

    void Awake()
    {
        SSDirector director = SSDirector.GetInstance();
        director.CurrentScenceController = this;
        df = Singleton<PatrolFactory>.Instance;
        director.CurrentScenceController.LoadResources();
        gamestate = GameState.RUNNING;
        score = 0;

        this.gameObject.AddComponent<UserGUI>();
        this.gameObject.AddComponent<GameEventManager>();
    }

    public void LoadResources()
    {
        //产生迷宫
        GameObject maze = Instantiate<GameObject>(Resources.Load<GameObject>("prefabs/maze"));
        maze.name = "maze";

        //产生玩家
        player = Instantiate<GameObject>(Resources.Load<GameObject>("prefabs/FreeVoxelGirlBlackhairPrefab 1"));
        player.name = "player";
        player.transform.position = new Vector3(0, 0, 2);
        
        df.GetPatrol(new Vector3(-13,0,8), PatrolDirection.RIGHT);
        df.GetPatrol(new Vector3(3, 0, 8), PatrolDirection.DOWN);
        df.GetPatrol(new Vector3(13, 0, 2),PatrolDirection.LEFT);
        df.GetPatrol(new Vector3(-13, 0, -8),PatrolDirection.UP);
        df.GetPatrol(new Vector3(-3, 0, -2),PatrolDirection.RIGHT);
        df.GetPatrol(new Vector3(13, 0, -2),PatrolDirection.DOWN);
    }

    void OnEnable()
    {
        GameEventManager.OnScoreAction += addScore;
        GameEventManager.OnGameOver += SetGameOver;
    }

    void OnDisable()
    {
        GameEventManager.OnScoreAction -= addScore;
        GameEventManager.OnGameOver -= SetGameOver;
    }

    public GameState getGameState()
    {
        return gamestate;
    }

    public int getScore()
    {
        return score;
    }

    public void SetGameOver()
    {
        gamestate = GameState.GAMEOVER;
    }

    public void setGameState(GameState state)
    {
        gamestate = state;
    }

    public void restart()
    {
        player.transform.position = new Vector3(0, 0, 2);
        gamestate = GameState.RUNNING;
        df.RestartAll();
        
        score = -1;
    }

    public void addScore()
    {
        
        score++;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
