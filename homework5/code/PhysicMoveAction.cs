using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class PhysicMoveAction : SSAction {
    //bool enableEmit = true;//使力作用一次，不想产生变加速运动  
    Vector3 force;//力  
    float startX;//起始位置
    public SceneController sceneControler = (SceneController)Director.getInstance().sceneController;
    public static PhysicMoveAction GetSSAction()
    {
        PhysicMoveAction action = ScriptableObject.CreateInstance<PhysicMoveAction>();
        return action;
    }
    public override void Start()
    {
        //初始化发射位置以及射出的力度
        force = new Vector3(2 * Random.Range(-1, 1), -2.5f * Random.Range(0.5f, 2), -1 + 2 * Random.Range(0.5f, 2));//力的大小  
    }
    public override void Update()
    {
        if (gameobject.activeSelf)
        {
            //将CCMoveAction中的transform改为刚体，加上力
            Debug.Log(this.transform.position.y);
            //如果物件没有刚体属性，则为它加上刚体属性
            if(gameobject.GetComponent<Rigidbody>() == null)
                gameobject.AddComponent<Rigidbody>();
            gameobject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameobject.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
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
