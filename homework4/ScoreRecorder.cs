using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRecorder : MonoBehaviour {

    private int score;

    void Start()
    {
        score = 0;
    }

    public int getScore()
    {
        return score;
    }

    public void addScore(int i)
    {
        score += i;
    }

    public void reset()
    {
        score = 0;
    }
}
