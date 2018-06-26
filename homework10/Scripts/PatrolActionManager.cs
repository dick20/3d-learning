using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class PatrolActionManager : SSActionManager, ISSActionCallback
{
    //巡逻兵巡逻
    private PatrolMoveAction patrolmove;                            
    public void patrolMove(GameObject patrol)
    {
        patrolmove = PatrolMoveAction.GetSSAction(patrol.transform.position);
        this.RunAction(patrol, patrolmove, this);
    }
    //停止所有动作
    public void DestroyAllAction()
    {
        foreach (KeyValuePair<int, SSAction> kv in actions)
        {
            SSAction ac = kv.Value;
            ac.destroy = true;
        }
    }
    //根据传入参数来选择执行不同的动作
    public void SSActionEvent(SSAction source, int intParam = 0, GameObject objectParam = null)
    {
        if (intParam == 0)
        {
            //侦查兵跟随玩家
            PatrolFollowAction follow = PatrolFollowAction.GetSSAction(objectParam.gameObject.GetComponent<PatrolData>().player);
            this.RunAction(objectParam, follow, this);
        }
        else
        {
            //侦察兵按照初始位置开始继续巡逻
            PatrolMoveAction move = PatrolMoveAction.GetSSAction(objectParam.gameObject.GetComponent<PatrolData>().start_position);
            this.RunAction(objectParam, move, this);
            //玩家逃脱
            Singleton<GameEventManager>.Instance.AddScore();
        }
    }
}
