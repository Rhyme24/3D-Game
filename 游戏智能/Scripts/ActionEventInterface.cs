using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SSActionEventType:int { Started, Completed}

public interface ISSActionCallback
{
    void SSActionEvent(SSAction source, SSActionEventType events = SSActionEventType.Completed, int intParam = 0, string strParam = null, Object objectParam = null);
}

public interface ISceneController
{
    void LoadResources();
}

public interface boatAction
{
    void boat_move(GameObject obj);
}

public interface devilAction
{
    void devil_move(GameObject obj);
}

public interface priestAction
{
    void priest_move(GameObject obj);
}
