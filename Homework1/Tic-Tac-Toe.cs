using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public GUISkin guiSkin;
    private int turn = 1;
    int[][] space = new int[3][] {new int[3], new int[3], new int[3]};
    // Use this for initialization
    void Start () {
        Debug.Log("start game!");
	}
    private void reset()
    {
        turn = 1;
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                space[i][j] = 0;
            }
        }
        Debug.Log("reset is running");
    }
    //0表示未分出胜负，1表示玩家O获胜，-1表示玩家X获胜
    private int gameOver()
    {
        //横线
        for (int i = 0; i < 3; i++)
        {
            if(space[i][0] != 0 && space[i][0] == space[i][1] && space[i][1] == space[i][2])
            {
                return space[i][0];
            }
        }
        //纵线
        for (int i = 0; i < 3; i++)
        {
            if(space[0][i] != 0 && space[0][i] == space[1][i] && space[1][i] == space[2][i])
            {
                return space[0][i];
            }
        }
        //斜线
        if(space[1][1] != 0 && space[0][0] == space[1][1] && space[1][1] == space[2][2])
        {
            return space[1][1];
        }
        else if(space[1][1] != 0 && space[2][0] == space[1][1] && space[1][1] == space[0][2])
        {
            return space[1][1];
        }
        return 0; //尚未分出胜负
    }
    void OnGUI()
    {
        GUI.skin = guiSkin;
        GUI.Box(new Rect(200, 30, 320, 370), "Tic-Tac-Toe");
        if (GUI.Button(new Rect(310, 365, 100, 35), "Reset"))
            reset();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if(space[i][j] == 1)
                {
                    GUI.Button(new Rect(210+i * 100, 60+j * 100, 100, 100), "O");
                }
                else if(space[i][j] == 2)
                {
                    GUI.Button(new Rect(210+i * 100, 60+j * 100, 100, 100), "X");
                }

                if (GUI.Button(new Rect(210+i * 100, 60+j * 100, 100, 100), ""))
                { 
                    if(gameOver() == 0)
                    {
                        if(turn == 1)
                        {
                            space[i][j] = 1;
                            turn = 2;
                        }
                        else
                        {
                            space[i][j] = 2;
                            turn = 1;
                        }
                    }
                }
            }
        }
        if (gameOver() == 0)
        {
            GUI.Box(new Rect(310, 0, 100, 27), "Draw!");
        }
        else if(gameOver() == 1)
        {
            GUI.Box(new Rect(310, 0, 100, 27), "O win!");
        }
        else if(gameOver() == 2)
        {
            GUI.Box(new Rect(310, 0, 100, 27), "X win!");
        }
    }
}
