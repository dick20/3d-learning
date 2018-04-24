using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

//定义飞碟运动的动作，继承了SSAction的动作基类
public class CCMoveAction : SSAction {
    public float a;        //重力加速度
    public float v_x;      //水平运动速度
    public Vector3 dir;    //运动方向
    public float time;     //运动时间

    public static CCMoveAction GetSSAction()
    {
        CCMoveAction action = ScriptableObject.CreateInstance<CCMoveAction>();
        return action;
    }
    // Use this for initialization
    public override void Start () {
        enable = true;
        a = 9.8f;
        time = 0;
        v_x = gameobject.GetComponent<DiskComponent>().speed;
        dir = gameobject.GetComponent<DiskComponent>().direction;
    }

    // Update is called once per frame
    public override void Update () {
        if (gameobject.activeSelf)
        {
            time += Time.deltaTime;
            //竖直运动 v_y = a * time
            transform.Translate(Vector3.down * a * time * Time.deltaTime);
            //水平运动 v_x = v_x
            transform.Translate(dir * v_x * Time.deltaTime);
            //飞碟落地情况，将信息回调
            if (this.transform.position.y < -5)
            {
                this.destroy = true;
                this.enable = false;
                this.callback.SSActionEvent(this);
            }
        }
    }
}
