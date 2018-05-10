using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolFactory : MonoBehaviour {

    List<PatrolData> used = new List<PatrolData>();
    List<PatrolData> free = new List<PatrolData>();

	public GameObject GetPatrol(Vector3 pos,PatrolDirection d)
    {
        GameObject patrol = null;
        if (free.Count == 0)
        { 
            patrol = Instantiate<GameObject>(Resources.Load<GameObject>("prefabs/FreeVoxelGirlPrefab 1"));
            
            patrol.AddComponent<PatrolData>();
        }
        else
        {
            patrol = free[0].gameObject;
            free.Remove(free[0]);
        }
        patrol.transform.position = pos;
        patrol.SetActive(true);
        patrol.GetComponent<PatrolData>().direction = (PatrolDirection)(((int)d+3)%4);
        patrol.GetComponent<PatrolData>().initDirection = (PatrolDirection)(((int)d + 3) % 4);
        patrol.GetComponent<PatrolData>().target = pos;
        patrol.GetComponent<PatrolData>().initTarget = pos;
        used.Add(patrol.GetComponent<PatrolData>());
        return patrol;
    }

    public void RestartAll()
    {
        foreach(PatrolData p in used)
        {
            p.target = p.initTarget;
            p.direction = p.initDirection;
        }
    }
}
