using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystick : MonoBehaviour {

    public float speedX = 5f;
    public float speedY = 5f;
    public float rotate_speed = 1500f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float translationY = Input.GetAxis("Vertical") * speedY;
        float translationX = Input.GetAxis("Horizontal") * speedX;
        translationX *= Time.deltaTime;
        translationY *= Time.deltaTime;
        transform.Translate(translationX,0 , translationY);
        transform.Rotate(0, translationX * rotate_speed * Time.deltaTime, 0);
        if (transform.localEulerAngles.x != 0 || transform.localEulerAngles.z != 0)
        {
            transform.localEulerAngles = new Vector3(0,transform.localEulerAngles.y, 0);
        }
        if (transform.position.y != 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }

}
