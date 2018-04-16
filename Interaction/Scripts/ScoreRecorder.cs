using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRecorder : System.Object
{
    private int score = 0;
    public void AddScore(int s)
    {
        score = score + s;
    }
    public int getScore()
    {
        return score;
    }
    public void Reset()
    {
        score = 0;
    }
}
