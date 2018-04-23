using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskFactory : MonoBehaviour
{
    private List<DiskData> used = new List<DiskData>();
    private List<DiskData> free = new List<DiskData>();
    private List<Color> c = new List<Color>();

    private void Awake()
    {
        c.Add(Color.black);
        c.Add(Color.blue);
        c.Add(Color.cyan);
        c.Add(Color.gray);
        c.Add(Color.green);
        c.Add(Color.magenta);
        c.Add(Color.red);
        c.Add(Color.white);
        c.Add(Color.yellow);
    }

    public GameObject GetDisk(int round)
    {
        GameObject newDisk = null;
        if (free.Count > 0)
        {
            newDisk = free[0].gameObject;
            free.Remove(free[0]);
        }
        else
        {
            newDisk = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("prefabs/disk"), Vector3.zero, Quaternion.identity);
            newDisk.AddComponent<DiskData>();
        }
        int flag;
        flag = UnityEngine.Random.Range(0, 5);
        newDisk.GetComponent<DiskData>().color = c[(round + flag) % 9];
        newDisk.GetComponent<Renderer>().material.color = c[(round + flag) % 9];
        newDisk.GetComponent<DiskData>().speed = round * 5;
        newDisk.GetComponent<DiskData>().size = getSize(round);
        newDisk.transform.localScale = getSize(round);
        float RanX = UnityEngine.Random.Range(-1f, 1f) < 0 ? -1 : 1;
        newDisk.GetComponent<DiskData>().direction = new Vector3(RanX, 1, 0);
        used.Add(newDisk.GetComponent<DiskData>());
        newDisk.name = newDisk.GetInstanceID().ToString();
        return newDisk;
    }

    public void FreeDisk(GameObject disk)
    {        
        disk.SetActive(false);
        free.Add(disk.GetComponent<DiskData>());
        used.Remove(disk.GetComponent<DiskData>()); 
    }

    private Vector3 getSize(int r)
    {
        if (r == 0)
        {
            return new Vector3(5, 0.1f, 5);
        }
        else if (r == 1)
        {
            return new Vector3(4, 0.1f, 4);
        }
        else if (r == 2)
        {
            return new Vector3(3, 0.1f, 3);
        }
        else if (r == 3)
        {
            return new Vector3(2, 0.1f, 2);
        }
        else
        {
            return new Vector3(1, 0.1f, 1);
        }
    }

}