using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUserAction  {

    GameState getGameState();
    int getScore();
    void setGameState(GameState state);
    void restart();
    void addScore();
}
