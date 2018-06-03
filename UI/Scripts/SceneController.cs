using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

    enum Talking_person  {LEFT,RIGHT};

    private List<string> dialogs;
    public Button leftBtn;
    public Button rightBtn;

    public Text leftText;
    public Text rightText;

    private Talking_person tp;
    private int dia_count;
    private bool scroll;
    private List<string> dia = new List<string>();

	// Use this for initialization
	void Start () {
        dialogs = new List<string>();
        dialogs.Clear();
        dialogs.Add("既然我回来了，就把你们安排得明明白白的");
        dialogs.Add("你为什么不放大");
        dialogs.Add("下路一直叫我去我怎么去啊，对面酒桶一直进我野区");
        dialogs.Add("这个人思想出了问题");


        Animator Ani = leftBtn.GetComponent<Animator>();
        Ani.SetTrigger("big");
        
        leftBtn.gameObject.transform.localScale = new Vector3(0, 0,0);
        Debug.Log(dialogs[0]);
        dia_count = 0;
        if (dialogs[dia_count].Length > 12)
        {
            leftText.text = dialogs[dia_count].Substring(0, 12);
            for (int i = 0; i < dialogs[dia_count].Length - 12; i++)
            {
                /*scroll = false;
                
                leftText.text = dialogs[dia_count].Substring(i + 1, 12);*/
                dia.Add(dialogs[dia_count].Substring(i + 1, 12));
            }
            StartCoroutine(BubbleOut());
        }
        else
        {
            leftText.text = dialogs[dia_count];
        }
        
        tp = Talking_person.LEFT;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator BubbleOut()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(DialogScroll());
    }

    IEnumerator DialogScroll()
    {
        yield return new WaitForSeconds(1.0f);
        if(tp == Talking_person.LEFT)
            leftText.text = dia[0];
        else
            rightText.text = dia[0];
        dia.Remove(dia[0]);
        if(dia.Count>0)
        {
            StartCoroutine(DialogScroll());
        }
    }

    private void Next()
    {
        if(tp == Talking_person.LEFT)
        {
            Animator Ani = leftBtn.GetComponent<Animator>();
            Ani.SetTrigger("small");
            Animator Ani2 = rightBtn.GetComponent<Animator>();
            Ani2.SetTrigger("big");

            dia_count = (dia_count + 1) % dialogs.Count;
            tp = Talking_person.RIGHT;
            if (dialogs[dia_count].Length > 12)
            {
                rightText.text = dialogs[dia_count].Substring(0, 12);
                for (int i = 0; i < dialogs[dia_count].Length - 12; i++)
                {
                    dia.Add(dialogs[dia_count].Substring(i + 1, 12));
                }
                StartCoroutine(BubbleOut());
            }
            else
            {
                rightText.text = dialogs[dia_count];
            }



        }
        else
        {
            Animator Ani = rightBtn.GetComponent<Animator>();
            Ani.SetTrigger("small");
            Animator Ani2 = leftBtn.GetComponent<Animator>();
            Ani2.SetTrigger("big");

            dia_count = (dia_count + 1) % dialogs.Count;
            tp = Talking_person.LEFT;
            if (dialogs[dia_count].Length > 12)
            {
                leftText.text = dialogs[dia_count].Substring(0, 12);
                for (int i = 0; i < dialogs[dia_count].Length - 12; i++)
                {
                    dia.Add(dialogs[dia_count].Substring(i + 1, 12));
                }
                StartCoroutine(BubbleOut());
            }
            else
            {
                leftText.text = dialogs[dia_count];
            }
        }
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(650, 350, 60, 40), ">"))
        {
            Next();
        }
        
    }
}
