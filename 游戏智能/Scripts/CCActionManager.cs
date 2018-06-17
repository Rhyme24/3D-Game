using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCActionManager : SSActionManager, ISSActionCallback {

    public FirstController sceneController;
    public CCMoveToAction boatToLeft, boatToRight, leftToRight, leftToLeft, rightToRight, rightToLeft;

	// Use this for initialization
	protected new void Start () {
        sceneController = (FirstController)SSDirector.getInstance().currentSceneController;
        sceneController.actionManager = this;
        boatToLeft = CCMoveToAction.GetSSAction(new Vector3(-3, 0, 0));
        boatToRight = CCMoveToAction.GetSSAction(new Vector3(3, 0, 0));
        leftToRight = CCMoveToAction.GetSSAction(new Vector3(2, 2, 0));
        leftToLeft = CCMoveToAction.GetSSAction(new Vector3(-4, 2, 0));
        rightToRight = CCMoveToAction.GetSSAction(new Vector3(4, 2, 0));
        rightToLeft = CCMoveToAction.GetSSAction(new Vector3(-2, 2, 0));
    }
	
	// Update is called once per frame
	protected new void Update () {
        base.Update();
	}

    #region ISSActionCallback implementation
    public void SSActionEvent(SSAction source, SSActionEventType events = SSActionEventType.Completed, int intParam = 0, string strParam = null, Object objectParam = null)
    {
        
        if(source.transform.tag == "boat")
        {
            sceneController.boat_move_to_left = false;
            sceneController.boat_move_to_right = false;
            sceneController.game_over_judge();
            Debug.Log("callback");
        }
        
    }
    #endregion
}
