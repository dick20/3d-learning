using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class PatrolMoveAction : SSAction
{
    private enum Dirction {  WEST, NORTH, EAST, SOUTH};
    private Dirction dirction = Dirction.WEST;  //移动的方向
    private PatrolData data;                    //巡逻兵的数据
    private float pos_x, pos_z;                 //巡逻兵移动前的初始坐标
    private float move_length;                  //巡逻兵移动的长度
    private bool is_turn = true;
    
    public override void Start()
    {
        data = this.gameobject.GetComponent<PatrolData>();
    }
    public override void Update()
    {
        patrolMove();
        //巡逻兵跟随，销毁该动作
        if (data.follow_player && data.area_sign == data.sign)
        {
            this.destroy = true;
            this.callback.SSActionEvent(this,0,this.gameobject);
        }
    }
    //返回一个动作，继承SSAction
    public static PatrolMoveAction GetSSAction(Vector3 location)
    {
        PatrolMoveAction action = CreateInstance<PatrolMoveAction>();
        action.pos_x = location.x;
        action.pos_z = location.z;
        //设定移动矩形的边长
        action.move_length = Random.Range(3, 5);
        return action;
    }
    //按照随机矩形轨迹运动
    void patrolMove()
    {
        if (is_turn)
        {
            switch (dirction)
            {
                case Dirction.EAST:
                    pos_x -= move_length;
                    break;
                case Dirction.NORTH:
                    pos_z += move_length;
                    break;
                case Dirction.WEST:
                    pos_x += move_length;
                    break;
                case Dirction.SOUTH:
                    pos_z -= move_length;
                    break;
            }
            is_turn = false;
        }
        this.transform.LookAt(new Vector3(pos_x, 0, pos_z));
        //比较两点的距离
        float distance = Vector3.Distance(transform.position, new Vector3(pos_x, 0, pos_z));
        //巡逻兵移动
        if (distance > 0.9)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(pos_x, 0, pos_z), 1.5f * Time.deltaTime);
        }
        //巡逻兵改变方向
        else
        {
            dirction = dirction + 1;
            if(dirction > Dirction.SOUTH)
            {
                dirction = Dirction.WEST;
            }
            is_turn = true;
        }
    }
}
