using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour {

    private IUserAction action;

	// Use this for initialization
	void Start () {
        action = SSDirector.getInstance().currentSceneController as IUserAction;
	}
	
    void onGUI()
    {
       
    }

	// Update is called once per frame
	void Update () {
		
	}
}
