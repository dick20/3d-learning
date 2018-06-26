using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class PatrolFollowAction : SSAction
{
    private GameObject player;           
    private PatrolData data;
    
    public override void Start()
    {
        data = this.gameobject.GetComponent<PatrolData>();
    }
    public override void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, 2.5f * Time.deltaTime);
        this.transform.LookAt(player.transform.position);
        //玩家逃脱或者不跟随的巡逻情况，销毁该动作
        if (!data.follow_player || data.area_sign != data.sign)
        {
            this.destroy = true;
            this.callback.SSActionEvent(this,1,this.gameobject);
        }
    }
    public static PatrolFollowAction GetSSAction(GameObject player)
    {
        PatrolFollowAction action = CreateInstance<PatrolFollowAction>();
        action.player = player;
        return action;
    }

}
