using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCMoveToAction : SSAction {

    public Vector3 target;

    public static CCMoveToAction GetSSAction(Vector3 target)
    {
        CCMoveToAction action = ScriptableObject.CreateInstance<CCMoveToAction>();
        action.target = target;
        return action;
    }

	// Use this for initialization
	public override void Start () {
		
    }

    // Update is called once per frame
    public override void Update () {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, Time.deltaTime * 2);
        if (this.transform.position == target)
        {
            this.destroy = true;
            this.callback.SSActionEvent(this);
        }
    }
}
