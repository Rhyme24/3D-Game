using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicActionManager : MonoBehaviour, IActionManager, ISSActionCallback
{
    public FirstController sceneController;

    private Dictionary<int, SSAction> actions = new Dictionary<int, SSAction>();      
    private List<SSAction> waitingAdd = new List<SSAction>();        
    private List<int> waitingDelete = new List<int>();        

    protected void Start()
    {
        sceneController = (FirstController)Director.getInstance().currentSceneController;
        sceneController.actionManager = this;

    }

    // Update is called once per frame  
    protected void FixedUpdate()
    {
        
        foreach (SSAction ac in waitingAdd) actions[ac.GetInstanceID()] = ac;
        waitingAdd.Clear();
 
        foreach (KeyValuePair<int, SSAction> kv in actions)
        {
            SSAction ac = kv.Value;
            if (ac.destroy)
            {
                waitingDelete.Add(ac.GetInstanceID());
            }
            else if (ac.enable)
            {
                ac.FixedUpdate();
            }
        }

        foreach (int key in waitingDelete)
        {
            SSAction ac = actions[key];
            actions.Remove(key);
            DestroyObject(ac);
        }
        waitingDelete.Clear();
    }

    public void RunAction(GameObject gameobject, SSAction action, ISSActionCallback manager)
    {
        action.gameobject = gameobject;
        action.transform = gameobject.transform;
        action.callback = manager;
        waitingAdd.Add(action);
        action.Start();
    }


    public void SSActionEvent(SSAction source,
        SSActionEventType events = SSActionEventType.Competeted,
        int intParam = 0,
        string strParam = null,
        UnityEngine.Object objectParam = null)
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
        /*CCFlyActionFactory cf = Singleton<CCFlyActionFactory>.Instance;
        foreach (GameObject tmp in diskQueue)
        {
            RunAction(tmp, cf.GetSSAction(), (ISSActionCallback)this);
        }*/
        RunAction(disk, CCFlyAction.GetSSAction(disk.GetComponent<DiskData>().speed, disk.GetComponent<DiskData>().direction), (ISSActionCallback)this);
    }

}