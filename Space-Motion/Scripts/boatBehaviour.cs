using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatBehaviour : MonoBehaviour {

    public boatAction action;

	// Use this for initialization
	void Start () {
        action = SSDirector.getInstance().currentSceneController as boatAction;
	}

    private void OnMouseDown()
    {
        action.boat_move(this.gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
