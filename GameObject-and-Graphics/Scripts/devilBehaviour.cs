using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devilBehaviour : MonoBehaviour
{

    private devilAction action;

    // Use this for initialization
    void Start()
    {
        action = SSDirector.getInstance().currentSceneController as devilAction;
    }

    private void OnMouseDown()
    {
        action.devil_move(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}