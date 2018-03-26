using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public string calculation = "0";
    public double num = 0;
    public char sign = 'n';
    public bool refresh = true;

    public void calculate()
    {
        double newNum = double.Parse(calculation);
        if(sign == '+')
        {
            num += newNum;
            calculation = num.ToString();
        }
        else if(sign == '-')
        {
            num -= newNum;
            calculation = num.ToString();
        }
        else if (sign == '*')
        {
            num *= newNum;
            calculation = num.ToString();
        }
        else if (sign == '/')
        {
            if(newNum == 0)
            {
                calculation = "ERROR";
                num = 0;
                sign = 'n';
                refresh = true;
                return;
            }
            num /= newNum;
            calculation = num.ToString();
        }
    }


    void OnGUI()
    {


        GUI.Box(new Rect(70, 10, 340, 50), calculation);

        if (GUI.Button(new Rect(70,70,60,40),"1"))
        {
            Debug.Log("1!");
            if(refresh)
            {
                calculation = "1";
                refresh = false;
            }
            else
                calculation += "1";
        }
           

        if (GUI.Button(new Rect(140, 70, 60, 40), "2"))
        {
            Debug.Log("2!");
            if (refresh)
            {
                calculation = "2";
                refresh = false;
            }
            else
                calculation += "2";
        }
            

        if (GUI.Button(new Rect(210, 70, 60, 40), "3"))
        {
            Debug.Log("3!");
            if (refresh)
            {
                calculation = "3";
                refresh = false;
            }
            else
                calculation += "3";
        }
            

        if (GUI.Button(new Rect(70, 120, 60, 40), "4"))
        {
            Debug.Log("4!");
            if (refresh)
            {
                calculation = "4";
                refresh = false;
            }
            else
                calculation += "4";
        }
            

        if (GUI.Button(new Rect(140, 120, 60, 40), "5"))
        {
            Debug.Log("5!");
            if (refresh)
            {
                calculation = "5";
                refresh = false;
            }
            else
                calculation += "5";
        }
            

        if (GUI.Button(new Rect(210, 120, 60, 40), "6"))
        {
            Debug.Log("6!");
            if (refresh)
            {
                calculation = "6";
                refresh = false;
            }
            else
                calculation += "6";
        }
            

        if (GUI.Button(new Rect(70, 170, 60, 40), "7"))
        {
            Debug.Log("7!");
            if (refresh)
            {
                calculation = "7";
                refresh = false;
            }
            else
                calculation += "7";
        }
            

        if (GUI.Button(new Rect(140, 170, 60, 40), "8"))
        {
            Debug.Log("8!");
            if (refresh)
            {
                calculation = "8";
                refresh = false;
            }
            else
                calculation += "8";
        }
            

        if (GUI.Button(new Rect(210, 170, 60, 40), "9"))
        {
            Debug.Log("9!");
            if (refresh)
            {
                calculation = "9";
                refresh = false;
            }
            else
                calculation += "9";
        }
            

        if (GUI.Button(new Rect(70, 220, 95, 40), "0"))
        {
            Debug.Log("0!");
            if (refresh)
            {
                calculation = "0";
                refresh = false;
            }
            else
                calculation += "0";
        }
            

        if (GUI.Button(new Rect(175, 220, 95, 40), "."))
        {
            Debug.Log(".!");
            if(refresh)
            {
                if(calculation == "0")
                {
                    calculation += ".";
                    refresh = false;
                }
                else
                {
                    calculation = "0.";
                    refresh = false;
                }
            }
            else
            {
                calculation += ".";
            }
        }
            

        if (GUI.Button(new Rect(280, 70, 60, 40), "+"))
        {
            Debug.Log("+!");
            
            if(refresh == true)
            {
                return;
            }
            refresh = true;
            if (sign == 'n')
            {
                
                num = double.Parse(calculation);
                sign = '+';
            }
            else
            {
                
                calculate();
                sign = '+';
            }
        }
            

        if (GUI.Button(new Rect(280, 120, 60, 40), "-"))
        {
            Debug.Log("-!");
            
            if (refresh == true)
            {
                return;
            }
            refresh = true;
            if (sign == 'n')
            {
                
                num = double.Parse(calculation);
                sign = '-';
            }
            else
            {
                
                calculate();
                sign = '-';
            }
        }
            

        if (GUI.Button(new Rect(280, 170, 60, 40), "*"))
        {
            Debug.Log("*!");
            
            if (refresh == true)
            {
                return;
            }
            refresh = true;
            if (sign == 'n')
            {
                
                num = double.Parse(calculation);
                sign = '*';
            }
            else
            {
                
                calculate();
                sign = '*';
            }
        }
            

        if (GUI.Button(new Rect(280, 220, 60, 40), "/"))
        {
            Debug.Log("/!");
            
            if (refresh == true)
            {
                return;
            }
            refresh = true;
            if (sign == 'n')
            {
                
                num = double.Parse(calculation);
                sign = '/';
            }
            else
            {
                
                calculate();
                sign = '/';
            }
        }
            

        if (GUI.Button(new Rect(350, 170, 60, 90), "="))
        {
            
            Debug.Log("=!");
            if (refresh)
            {
                sign = 'n';
                return;
            }
            calculate();
            sign = 'n';
            refresh = true;
        }
            

        if (GUI.Button(new Rect(350, 70, 60, 90), "C"))
        {
            Debug.Log("C!");
            refresh = true;
            sign = 'n';
            num = 0;
            calculation = "0";
        }
            
    }

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        
	}

}
