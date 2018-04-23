using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCActionManager : SSActionManager, ISSActionCallback, IActionManager
{

    public FirstController sceneController;
    public List<CCFlyAction> Fly;
    public int DiskNumber = 0;

    protected new void Start()
    {
        sceneController = (FirstController)Director.getInstance().currentSceneController;
        sceneController.actionManager = this;
    }

    protected new void Update()
    {
        base.Update();
    }

    public void SSActionEvent(SSAction source,SSActionEventType events = SSActionEventType.Competeted,int intParam = 0,string strParam = null,UnityEngine.Object objectParam = null)
    {
        if (source is CCFlyAction)
        {
            sceneController.setGameState(GameState.DROP);
            DiskFactory df = Singleton<DiskFactory>.Instance;
            df.FreeDisk(source.gameobject);
        }
    }

    public void StartThrow(GameObject disk)
    {
        RunAction(disk, CCFlyAction.GetSSAction(disk.GetComponent<DiskData>().speed, disk.GetComponent<DiskData>().direction), (ISSActionCallback)this);
    }
}