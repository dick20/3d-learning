using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class ScoreRecorder : MonoBehaviour
{
    public FirstController sceneController;
    public int score = 0;      
    
    void Start()
    {
        sceneController = (FirstController)Director.getInstance().sceneController;
        sceneController.recorder = this;
    }
    public int getScore()
    {
        return score;
    }
    public void addScore()
    {
        score++;
    }
}

