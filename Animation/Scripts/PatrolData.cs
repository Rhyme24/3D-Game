using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum state : int { PATROL, CATCH }
public enum PatrolDirection : int { RIGHT, DOWN, LEFT, UP }

public class PatrolData : MonoBehaviour {

	
    public state patrolState;
    public PatrolDirection direction;
    public PatrolDirection initDirection;
    public Vector3 target;
    public Vector3 initTarget;
    public float speed = 1f;
    public float catchSpeed = 2f;
    public GameObject player;

    private void Start()
    {
        patrolState = state.PATROL;
    }

    private void Update()
    {
        if(patrolState == state.PATROL)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position,
                target, speed * Time.deltaTime);
            if(transform.position == target)
            {
                direction= (PatrolDirection)(((int)direction + 1) % 4);
                if(direction == PatrolDirection.RIGHT)
                {
                    target = new Vector3(target.x+6, target.y, target.z);
                }
                else if(direction == PatrolDirection.DOWN)
                {
                    target = new Vector3(target.x, target.y, target.z-6);
                }
                else if (direction == PatrolDirection.UP)
                {
                    target = new Vector3(target.x, target.y, target.z + 6);
                }
                else if (direction == PatrolDirection.LEFT)
                {
                    target = new Vector3(target.x-6, target.y, target.z);
                }
            }
        }
        else if(patrolState == state.CATCH)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, 
                player.transform.position, catchSpeed * Time.deltaTime);
            if(this.transform.position == player.transform.position)
            {
                Singleton<GameEventManager>.Instance.GameOver();
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            player = collider.gameObject;
            patrolState = state.CATCH;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            patrolState = state.PATROL;

            Singleton<GameEventManager>.Instance.PlayerEscape();
        }
    }
}
