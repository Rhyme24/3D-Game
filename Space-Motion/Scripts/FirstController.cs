using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//游戏中提及的事物:牧师、恶魔、船、河、岸
//玩家动作:点击恶魔、点击牧师、点击船、点击重新开始按钮

public class FirstController : MonoBehaviour, IsceneController, IUserAction, devilAction, priestAction, boatAction
{

    public bool boat_is_right = true;
    public bool boat_left_empty = true;
    public bool boat_right_empty = true;
    List<bool> right_position_empty = new List<bool> ();
    List<bool> left_position_empty = new List<bool>();
    //public bool[] right_position_empty = new bool[6];
    //public bool[] left_position_empty = new bool[6];
    public bool boat_move_to_left;
    public bool boat_move_to_right;
    public GameObject boat_to_be_moved = null;
    public GameObject right_on_boat = null;
    public GameObject left_on_boat = null;
    public int left_devil_count;
    public int left_priest_count;
    public int right_devil_count;
    public int right_priest_count;
    public bool game_over;
    public string left_type = null;
    public string right_type = null;
    public GameObject priest1;
    public GameObject priest2;
    public GameObject priest3;
    public GameObject devil1;
    public GameObject devil2;
    public GameObject devil3;
    public GameObject boat;
    public bool win;
    public float time;

    // the first scripts
    void Awake()
    {
        
        left_devil_count = 0;
        left_priest_count = 0;
        right_priest_count = 3;
        right_devil_count = 3;
        game_over = false;
        int i;
        for (i = 0; i < 6; i++)
        {
            right_position_empty.Add(false);
            left_position_empty.Add(true);
            //right_position_empty[i] = false;
            //left_position_empty[i] = true;
        }
        SSDirector director = SSDirector.getInstance();
        director.setFPS(60);
        director.currentSceneController = this;
        director.currentSceneController.LoadResources();
        boat_move_to_right = false;
        boat_move_to_left = false;
        win = false;
        Debug.Log("left_priest:" + left_priest_count.ToString());
        Debug.Log("left_devil:" + left_devil_count.ToString());
        Debug.Log("right_priest:" + right_priest_count.ToString());
        Debug.Log("right_devil:" + right_devil_count.ToString());
    }

    // loading resources for first scene
    public void LoadResources()
    {
        GameObject left_land = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/land"));
        left_land.name = "left_land";
        left_land.transform.position = new Vector3(-left_land.transform.position.x, left_land.transform.position.y, left_land.transform.position.z);
        GameObject right_land = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/land"));
        left_land.name = "right_land";

        GameObject river = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/river"));
        river.name = "river";

        priest1 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/priest"));
        priest1.name = "priest1";
        priest1.transform.position = new Vector3(6, priest1.transform.position.y, priest1.transform.position.z);
        priest2 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/priest"));
        priest2.name = "priest2";
        priest2.transform.position = new Vector3(7, priest2.transform.position.y, priest2.transform.position.z);
        priest3 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/priest"));
        priest3.name = "priest3";
        priest3.transform.position = new Vector3(8, priest3.transform.position.y, priest3.transform.position.z);

        devil1 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/devil"));
        devil1.name = "devil1";
        devil1.transform.position = new Vector3(9, devil1.transform.position.y, devil1.transform.position.z);
        devil2 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/devil"));
        devil2.name = "devil2";
        devil2.transform.position = new Vector3(10, devil2.transform.position.y, devil2.transform.position.z);
        devil3 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/devil"));
        devil3.name = "devil3";
        devil3.transform.position = new Vector3(11, devil3.transform.position.y, devil3.transform.position.z);

        boat = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/boat"));
        boat.name = "boat";
    }

    public void Restart()
    {
        boat_is_right = true;
        boat_left_empty = true;
        boat_right_empty = true;
        int i;
        for (i = 0; i < 6; i++)
        {
            right_position_empty[i] = false;
            left_position_empty[i] = true;
        }
        boat_move_to_right = false;
        boat_move_to_left = false;
        boat_to_be_moved = null;
        right_on_boat = null;
        left_on_boat = null;
        left_devil_count = 0;
        left_priest_count = 0;
        right_devil_count = 3;
        right_priest_count = 3;
        game_over = false;
        left_type = null;
        right_type = null;
        priest1.transform.position = new Vector3(6, 2.5f, 0);
        priest2.transform.position = new Vector3(7, 2.5f, 0);
        priest3.transform.position = new Vector3(8, 2.5f, 0);
        devil1.transform.position = new Vector3(9, 2.5f, 0);
        devil2.transform.position = new Vector3(10, 2.5f, 0);
        devil3.transform.position = new Vector3(11, 2.5f, 0);
        boat.transform.position = new Vector3(3, 0, 0);
        win = false;
        time = 60;
        StartCoroutine(Timer());
    }

    public void devil_move(GameObject obj)
    {
        if (boat_move_to_left || boat_move_to_right || game_over || win)
        {
            return;
        }
        if (boat_is_right)
        {
            if (obj.transform.position.x >= 6)
            {
                if (boat_left_empty)
                {
                    //Debug.Log((int)obj.transform.position.x - 6);
                    right_position_empty[(int)obj.transform.position.x - 6] = true;
                    obj.transform.position = new Vector3(2, 2, 0);
                    boat_left_empty = false;
                    left_on_boat = obj;
                    left_type = "devil";

                }
                else if (boat_right_empty)
                {
                    right_position_empty[(int)obj.transform.position.x - 6] = true;
                    obj.transform.position = new Vector3(4, 2, 0);
                    boat_right_empty = false;
                    right_on_boat = obj;
                    right_type = "devil";
                }
            }
            else if (obj.transform.position.x >= 2 && obj.transform.position.x <= 4)
            {
                if (obj.transform.position.x == 2)
                {
                    boat_left_empty = true;
                    left_on_boat = null;
                    left_type = null;
                }
                else
                {
                    boat_right_empty = true;
                    right_on_boat = null;
                    right_type = null;
                }
                int i;
                for (i = 0; i < 6; i++)
                {
                    if (right_position_empty[i])
                    {
                        obj.transform.position = new Vector3(i + 6, 2.5f, 0);
                        right_position_empty[i] = false;
                        break;
                    }
                }

            }
        }
        else
        {
            if (obj.transform.position.x <= -6)
            {
                if (boat_left_empty)
                {
                    left_position_empty[-(int)obj.transform.position.x - 6] = true;
                    obj.transform.position = new Vector3(-4, 2, 0);
                    boat_left_empty = false;
                    left_on_boat = obj;
                    left_type = "devil";

                }
                else if (boat_right_empty)
                {
                    left_position_empty[-(int)obj.transform.position.x - 6] = true;
                    obj.transform.position = new Vector3(-2, 2, 0);
                    boat_right_empty = false;
                    right_on_boat = obj;
                    right_type = "devil";
                }
            }
            else if (obj.transform.position.x >= -4 && obj.transform.position.x <= -2)
            {
                if (obj.transform.position.x == -4)
                {
                    boat_left_empty = true;
                    left_on_boat = null;
                    left_type = null;
                }
                else
                {
                    boat_right_empty = true;
                    right_on_boat = null;
                    right_type = null;
                }
                int i;
                for (i = 0; i < 6; i++)
                {
                    if (left_position_empty[i])
                    {
                        //Debug.Log((int)obj.transform.position.x - 6);
                        obj.transform.position = new Vector3(-i - 6, 2.5f, 0);
                        left_position_empty[i] = false;
                        break;
                    }
                }

            }
        }
    }

    public void priest_move(GameObject obj)
    {
        if (boat_move_to_left || boat_move_to_right || game_over || win)
        {
            return;
        }
        if (boat_is_right)
        {
            if (obj.transform.position.x >= 6)
            {
                if (boat_left_empty)
                {
                    Debug.Log((int)obj.transform.position.x - 6);
                    right_position_empty[(int)obj.transform.position.x - 6] = true;
                    obj.transform.position = new Vector3(2, 2, 0);
                    boat_left_empty = false;
                    left_on_boat = obj;
                    left_type = "priest";

                }
                else if (boat_right_empty)
                {
                    right_position_empty[(int)obj.transform.position.x - 6] = true;
                    obj.transform.position = new Vector3(4, 2, 0);
                    boat_right_empty = false;
                    right_on_boat = obj;
                    right_type = "priest";
                }
            }
            else if (obj.transform.position.x >= 2 && obj.transform.position.x <= 4)
            {
                if (obj.transform.position.x == 2)
                {
                    boat_left_empty = true;
                    left_on_boat = null;
                    left_type = null;
                }
                else
                {
                    boat_right_empty = true;
                    right_on_boat = null;
                    right_type = null;
                }
                int i;
                for (i = 0; i < 6; i++)
                {
                    if (right_position_empty[i])
                    {
                        obj.transform.position = new Vector3(i + 6, 2.5f, 0);
                        right_position_empty[i] = false;
                        break;
                    }
                }

            }
        }
        else
        {
            if (obj.transform.position.x <= -6)
            {
                if (boat_left_empty)
                {
                    left_position_empty[-(int)obj.transform.position.x - 6] = true;
                    obj.transform.position = new Vector3(-4, 2, 0);
                    boat_left_empty = false;
                    left_on_boat = obj;
                    left_type = "priest";

                }
                else if (boat_right_empty)
                {
                    left_position_empty[-(int)obj.transform.position.x - 6] = true;
                    obj.transform.position = new Vector3(-2, 2, 0);
                    boat_right_empty = false;
                    right_on_boat = obj;
                    right_type = "priest";
                }
            }
            else if (obj.transform.position.x >= -4 && obj.transform.position.x <= -2)
            {
                if (obj.transform.position.x == -4)
                {
                    boat_left_empty = true;
                    left_on_boat = null;
                    left_type = null;
                }
                else
                {
                    boat_right_empty = true;
                    right_on_boat = null;
                    right_type = null;
                }
                int i;
                for (i = 0; i < 6; i++)
                {
                    if (left_position_empty[i])
                    {
                        obj.transform.position = new Vector3(-i - 6, 2.5f, 0);
                        left_position_empty[i] = false;
                        break;
                    }
                }

            }
        }
    }

    public void boat_move(GameObject boat)
    {
        if (boat_move_to_left || boat_move_to_right || game_over || win)
        {
            //Debug.Log(boat_move_to_left);
            //Debug.Log(boat_move_to_right);
            return;
        }
        if (left_type != null || right_type != null)
        {
            if (boat_is_right)
            {
                boat_to_be_moved = boat;
                boat_move_to_left = true;
                boat_is_right = false;
                if (left_type == "devil")
                {
                    left_devil_count++;
                    right_devil_count--;
                }
                else if (left_type == "priest")
                {
                    left_priest_count++;
                    right_priest_count--;
                }
                if (right_type == "devil")
                {
                    left_devil_count++;
                    right_devil_count--;
                }
                else if (right_type == "priest")
                {
                    left_priest_count++;
                    right_priest_count--;
                }
            }
            else
            {
                boat_to_be_moved = boat;
                boat_move_to_right = true;
                boat_is_right = true;
                if (left_type == "devil")
                {
                    left_devil_count--;
                    right_devil_count++;
                }
                else if (left_type == "priest")
                {
                    left_priest_count--;
                    right_priest_count++;
                }
                if (right_type == "devil")
                {
                    left_devil_count--;
                    right_devil_count++;
                }
                else if (right_type == "priest")
                {
                    left_priest_count--;
                    right_priest_count++;
                }
            }
        }
        Debug.Log("left_priest:" + left_priest_count.ToString());
        Debug.Log("left_devil:" + left_devil_count.ToString());
        Debug.Log("right_priest:" + right_priest_count.ToString());
        Debug.Log("right_devil:" + right_devil_count.ToString());
    }

    public void game_over_judge()
    {
        if ((right_devil_count > right_priest_count && right_priest_count != 0) || (left_devil_count > left_priest_count && left_priest_count != 0))
        {
            game_over = true;
            time = 0;
        }
        else if(left_priest_count == 3 && left_devil_count == 3)
        {
            win = true;
            time = 0;
        }
    }

    // Use this for initialization
    void Start()
    {
        time = 60;
        StartCoroutine(Timer());
    }

    public IEnumerator Timer()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            print(time);
            time--;
        }
        game_over = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (boat_move_to_left && boat_to_be_moved != null)
        {
            this.boat_to_be_moved.transform.position = Vector3.MoveTowards(this.boat_to_be_moved.transform.position, new Vector3(-3, 0, 0), Time.deltaTime * 2);
            if (left_on_boat != null)
                this.left_on_boat.transform.position = Vector3.MoveTowards(this.left_on_boat.transform.position, new Vector3(-4, 2, 0), Time.deltaTime * 2);
            if (right_on_boat != null)
                this.right_on_boat.transform.position = Vector3.MoveTowards(this.right_on_boat.transform.position, new Vector3(-2, 2, 0), Time.deltaTime * 2);
            if (this.boat_to_be_moved.transform.position == new Vector3(-3, 0, 0))
            {
                boat_move_to_left = false;
                game_over_judge();
            }
        }
        if (boat_move_to_right && boat_to_be_moved != null)
        {
            this.boat_to_be_moved.transform.position = Vector3.MoveTowards(this.boat_to_be_moved.transform.position, new Vector3(3, 0, 0), Time.deltaTime * 2);
            if (left_on_boat != null)
                this.left_on_boat.transform.position = Vector3.MoveTowards(this.left_on_boat.transform.position, new Vector3(2, 2, 0), Time.deltaTime * 2);
            if (right_on_boat != null)
                this.right_on_boat.transform.position = Vector3.MoveTowards(this.right_on_boat.transform.position, new Vector3(4, 2, 0), Time.deltaTime * 2);
            if (this.boat_to_be_moved.transform.position == new Vector3(3, 0, 0))
            {
                boat_move_to_right = false;
                game_over_judge();
            }
        }

    }

    void OnGUI()
    {
        
        GUI.Box(new Rect(Screen.width/2-75, 10, 150, 40), "Left Time: \n" + time.ToString());

        if (game_over)
        {
            GUI.Window(0, new Rect(Screen.width / 2 - Screen.width / 12, Screen.height / 2 - Screen.height / 12, Screen.width / 6, Screen.height / 6), game_over_window, "Game Over!");
        }
        if(win)
        {
            GUI.Window(0, new Rect(Screen.width / 2 - Screen.width / 12, Screen.height / 2 - Screen.height / 12, Screen.width / 6, Screen.height / 6), win_window, "You Win!");
        }
    }

    void game_over_window(int id)
    {
        if (GUI.Button(new Rect(Screen.width /24, Screen.height / 24 + 5, Screen.width / 12, Screen.height / 12), "Restart"))
        {
            Debug.Log("Restart");

            Restart();
        }

    }

    void win_window(int id)
    {
        if (GUI.Button(new Rect(Screen.width / 24, Screen.height / 24 + 5, Screen.width / 12, Screen.height / 12), "Restart"))
        {
            Debug.Log("Restart");

            Restart();
        }
    }
}

