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
    private PristsAndDevilsState start;
    private PristsAndDevilsState end;
    public CoastController coastController =  new CoastController("both");
    public int leftPriests = 3;
    public int leftDevils = 3;
    public int rightPriests = 0;
    public int rightDevils = 0;
    public bool boat_pos = true;

    private string tips = "";

    void Start()
    {
        action = Director.getInstance().sceneController as UserAction;
        style = new GUIStyle();
        style.fontSize = 15;
        style.alignment = TextAnchor.MiddleLeft;
        style2 = new GUIStyle();
        style2.fontSize = 30;
        style2.alignment = TextAnchor.MiddleCenter;
        end = new PristsAndDevilsState(0, 0, 3, 3, false, null);
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
        GUI.Label(new Rect(Screen.width / 2 - 270, Screen.height / 2 - 165, 100, 50), tips, style);
        if (GUI.Button(new Rect(Screen.width / 2 - 170, 20, 100, 50), "Tips", buttonStyle))
        {
            int[] arr = action.getNum();
            leftPriests = arr[0];
            leftDevils = arr[1];
            rightPriests = arr[2];
            rightDevils = arr[3];
            Debug.Log(arr[4]);
            if (arr[4] == 0) { boat_pos = true; }
            else { boat_pos = false; }
            start = new PristsAndDevilsState(leftPriests, leftDevils, rightPriests, rightDevils, boat_pos, null);
            Debug.Log(start.leftPriests+ " " + start.leftDevils + " " + start.rightPriests + " " + start.rightDevils + " " + start.boat_pos);
            Debug.Log(end.leftPriests + " " + end.leftDevils + " " + end.rightPriests + " " + end.rightDevils + " " + end.boat_pos);
            //bug
            PristsAndDevilsState temp = PristsAndDevilsState.BFS(start, end);
            leftPriests = temp.leftPriests;
            leftDevils = temp.leftDevils;
            rightPriests = temp.rightPriests;
            rightDevils = temp.rightDevils;

            tips = "try to make\nleftPriests : " + leftPriests + "\nleftDevils : " + leftDevils
                + "\nrightPriests : " + rightPriests + "\nrightDevils : " + rightDevils;
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 170, 80, 100, 50), "Hide Tips", buttonStyle))
        {
            tips = "";
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
