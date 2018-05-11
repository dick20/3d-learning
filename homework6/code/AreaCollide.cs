using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

//区域碰撞器脚本。当玩家进入自己的区域,碰撞一发生马上改变sign
public class AreaCollide : MonoBehaviour
{
    public int sign = 0;
    FirstController sceneController = (FirstController) Director.getInstance().sceneController;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            sceneController.area_sign = sign;
        }
    }
}
