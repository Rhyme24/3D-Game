using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IsceneController {
    void LoadResources();
    void Restart();
}

public interface IUserAction
{


}

public interface devilAction
{
    void devil_move(GameObject obj);
}

public interface priestAction
{
    void priest_move(GameObject obj);
}

public interface boatAction
{
    void boat_move(GameObject obj);
}
