using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class UserGUI : MonoBehaviour {
    private IUserAction action;
    void Start ()
    {
        action = Director.getInstance().sceneController as IUserAction;
    }

    void Update()
    {
        float translationX = Input.GetAxis("Horizontal");
        float translationZ = Input.GetAxis("Vertical");
        //移动玩家
        action.playerMove(translationX, translationZ);
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 5, 200, 50), "分数:");
        GUI.Label(new Rect(55, 5, 200, 50), action.getScore().ToString());
        if(action.getGameover())
        {
            GUI.Label(new Rect(Screen.width / 2-40, Screen.width / 2 - 200, 100, 100), "Game over!\nYour score is " + action.getScore().ToString());
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.width / 2 - 150, 100, 40), "restart"))
            {
                action.restart();
                return;
            }
        }
    }
}
