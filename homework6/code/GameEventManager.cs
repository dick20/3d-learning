using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//消息的接收者，firstController调用该类得到信息执行对应的操作
public class GameEventManager : MonoBehaviour
{
    //接收分数增加消息
    public delegate void ScoreEvent();
    public static event ScoreEvent ScoreChange;
    //接收游戏结束消息
    public delegate void GameoverEvent();
    public static event GameoverEvent GameoverChange;

    public void AddScore()
    {
        if (ScoreChange != null)
        {
            ScoreChange();
        }
    }

    public void Gameover()
    {
        if (GameoverChange != null)
        {
            GameoverChange();
        }
    }
}
