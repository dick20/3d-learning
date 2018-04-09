using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class UserGUI : MonoBehaviour {
    private UserAction action;
    public int status = 0; // -1表示失败，1表示成功
    GUIStyle style;
    GUIStyle style2;
    GUIStyle buttonStyle;
    public bool show = false;

    void Start()
    {
        action = Director.getInstance().sceneController as UserAction;
        style = new GUIStyle();
        style.fontSize = 15;
        style.alignment = TextAnchor.MiddleLeft;
        style2 = new GUIStyle();
        style2.fontSize = 30;
        style2.alignment = TextAnchor.MiddleCenter;
    }

    void OnGUI()
    {
        if (status == -1)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 65, 100, 50), "Gameover!", style2);   
        }
        else if (status == 1)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 65, 100, 50), "You win!", style2);  
        }
        buttonStyle = new GUIStyle("button");
        buttonStyle.fontSize = 15;
        if (GUI.Button(new Rect(Screen.width / 2 - 50, 20, 100, 50), "Restart", buttonStyle))
        {
            status = 0;
            action.restart();
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, 80, 100, 50), "Rule", buttonStyle))
        {
            show = true;
        }
        if (show)
        {
            GUI.Label(new Rect(Screen.width / 2 + 70, 20, 100, 100), "游戏规则：\n白色正方体为牧师，黑色球体为魔鬼。\n" +
            "船只最多能容纳两人，有人在船上才可开船\n" +
            "当某一岸恶魔数量大于牧师数量，游戏失败！\n" +
            "牧师与恶魔全部渡过河流，游戏胜利！\n", style);
        }
    }
}
