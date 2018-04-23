using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCFlyAction : SSAction
{
    public float acceleration;
    public float horizontalSpeed;
    public Vector3 direction;
    public float time;

    public static CCFlyAction GetSSAction(float speed, Vector3 d)
    {
        CCFlyAction action = ScriptableObject.CreateInstance<CCFlyAction>();
        action.acceleration = 9.8f;
        action.horizontalSpeed = speed;
        action.time = 0;
        action.direction = d;
        action.enable = true;
        return action;
    }

    public override void Start()
    {
        
    }

    // Update is called once per frame  
    public override void Update()
    {
        if (gameobject.activeSelf)
        {
            time += Time.deltaTime;
            //Debug.Log(time);
            transform.Translate(Vector3.down * acceleration * time * Time.deltaTime);
            transform.Translate(direction * horizontalSpeed * Time.deltaTime);

            if (this.transform.position.y < -4)
            {
                this.destroy = true;
                this.enable = false;
                this.callback.SSActionEvent(this);
            }
        }

    }

    public override void FixedUpdate()
    {
        if (gameobject.activeSelf)
        {
            time += Time.deltaTime;
            //Debug.Log(time);
            transform.Translate(Vector3.down * acceleration * time * Time.deltaTime);
            transform.Translate(direction * horizontalSpeed * Time.deltaTime);

            if (this.transform.position.y < -4)
            {
                this.destroy = true;
                this.enable = false;
                this.callback.SSActionEvent(this);
            }
        }

    }
}