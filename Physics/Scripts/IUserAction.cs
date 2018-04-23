
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { START, NEXT_ROUND, GAME_OVER, RUNNING, ROUND_END, DROP }
public enum ActionMode { PHYSIC, KINEMATIC, NOTSET }

public interface IUserAction
{
    
    int getRound();
    int getScore();
    int getTrial();
    GameState getGameState();
    void setGameState(GameState gs);
    void hit(Vector3 pos);
}