using UnityEngine;
using UnityEngine.Networking;
using Com.Mygame;

public class PlayerControl_for_network : NetworkBehaviour
{
    private IUserAction action;
    private int score = 0;
    [SyncVar]
    public bool is_move = true; // 判断是否停止接收移动信号

    void Update()
    {
        if(Director.getInstance().sceneController == null)
        {
            Cmdgetmove();
        }
        else
        {
            is_move = !Director.getInstance().sceneController.getGameover();
        }
        if (!isLocalPlayer || !is_move)
            return;
        var x = Input.GetAxis("Horizontal") * 0.1f;
        var z = Input.GetAxis("Vertical") * 0.1f;
        transform.Translate(x, 0, z);
    }
    void Start()
    {
        if(isLocalPlayer)
            action = Director.getInstance().sceneController as IUserAction;
    }

    [Command]
    public void Cmdgetmove()
    {
        // This [Command] code is run on the server!
        is_move = !Director.getInstance().sceneController.getGameover();
    }
    [Command]
    public void Cmdgetscore()
    {
        // This [Command] code is run on the server!
        score = Director.getInstance().sceneController.getScore();
    }

    [Command]
    public void Cmdgetrestart()
    {
        // This [Command] code is run on the server!
        Director.getInstance().sceneController.restart();
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 5, 200, 50), "分数:");
        if(action != null)
        {
            GUI.Label(new Rect(55, 5, 200, 50), action.getScore().ToString());
            if (action.getGameover())
            {
                GUI.Label(new Rect(Screen.width / 2 - 40, Screen.width / 2 - 200, 100, 100), "Game over!\nYour score is " + action.getScore().ToString());
                if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.width / 2 - 150, 100, 40), "restart"))
                {
                    action.restart();
                    return;
                }
            }
        }
        else
        {
            Cmdgetscore();
            GUI.Label(new Rect(55, 5, 200, 50), score.ToString());
            if (!is_move)
            {
                GUI.Label(new Rect(Screen.width / 2 - 40, Screen.width / 2 - 200, 100, 100), "Game over!\nYour score is " + score.ToString());
                if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.width / 2 - 150, 100, 40), "restart"))
                {
                    Cmdgetrestart();
                    return;
                }
            }
        }
        
    }
}
