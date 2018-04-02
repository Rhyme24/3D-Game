using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class priestBehaviour : MonoBehaviour {

    private priestAction action;

    // Use this for initialization
    void Start () {
        action = SSDirector.getInstance().currentSceneController as priestAction;
    }

    private void OnMouseDown()
    {
        action.priest_move(this.gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
