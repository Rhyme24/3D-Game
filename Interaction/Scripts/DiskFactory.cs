using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskFactory : System.Object {

    private List<GameObject> used = new List<GameObject>();
    private List<GameObject> free = new List<GameObject>();
    private List<Color> c = new List<Color>();
    private int count = 0;
    private int flag;
    private static DiskFactory _instance;

    public void GetDisk(int ruler)
    {
       
            GameObject disk;
            if (free.Count == 0)
            {
                disk = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/disk"));
                disk.name = "disk" + count;
                count++;
                used.Add(disk);
            }
            else
            {
                disk = free[0];
                disk.SetActive(true);
                used.Add(disk);
                free.RemoveAt(0);
            }
            flag = UnityEngine.Random.Range(0, 5);
            disk.GetComponent<Renderer>().material.color = c[(ruler + flag) % 9];
            disk.transform.localScale = getSize(ruler);
            disk.transform.position = getPosition(ruler + flag);
            DiskData data = disk.GetComponent(typeof(DiskData)) as DiskData;
            data.speed = ruler + 1;
            data.target = getTarget(ruler + flag);
        
        
    }

    public int GetCount()
    {
        return used.Count;
    }

    private Vector3 getTarget(int ruler)
    {
        if (ruler % 2 == 0)
        {
            return new Vector3(100, 10 + ruler, 60);
        }
        return new Vector3(-100, 10+ruler, 60);
    }

    private Vector3 getPosition(int ruler)
    {
        
            if(ruler % 2 == 0)
            {
                return new Vector3(-10, 0, -6);
            }
            else
            {
                return new Vector3(10, 0, -6);
            }
        
    }

    private Vector3 getSize(int r)
    {
        if(r == 0)
        {
            return new Vector3(5, 0.1f, 5);
        }
        else if(r == 1)
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

    public static DiskFactory GetInstance()
    {
        if (_instance == null)
        {
            _instance = new DiskFactory();
            _instance.c.Add(Color.black);
            _instance.c.Add(Color.blue);
            _instance.c.Add(Color.cyan);
            _instance.c.Add(Color.gray);
            _instance.c.Add(Color.green);
            _instance.c.Add(Color.magenta);
            _instance.c.Add(Color.red);
            _instance.c.Add(Color.white);
            _instance.c.Add(Color.yellow);
        }
        return _instance;
    }

    public void FreeDisk(GameObject disk)
    {
        disk.SetActive(false);
        free.Add(disk);
        used.Remove(disk);
        
    }

    

	// Use this for initialization
	void Start () {
        

    }
}
