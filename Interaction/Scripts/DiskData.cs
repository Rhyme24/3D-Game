using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskData : MonoBehaviour {

    public Vector3 target;
    public float speed;
    public diskAction action;

    // Use this for initialization
    void Start () {
        action = SSDirector.getInstance().currentSceneController as diskAction;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fired Pressed");
            Debug.Log(Input.mousePosition);

            Vector3 mp = Input.mousePosition; //get Screen Position

            //create ray, origin is camera, and direction to mousepoint
            Camera ca = Camera.main; //cam.GetComponent<Camera> ();
            Ray ray = ca.ScreenPointToRay(Input.mousePosition);

            //Return the ray's hit
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                print(hit.transform.gameObject.name);
                if (hit.collider.gameObject.tag.Contains("Finish"))
                { //plane tag
                    Debug.Log("hit " + hit.collider.gameObject.name + "!");
                }
                //消失
                action.Boomshakalaka(this.gameObject);
            }
        }
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime * 2);
        if(this.transform.position == target)
        {
            
            action.Drop(this.gameObject);
        }
    }
}
