using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//玩家碰撞器脚本，用于判断游戏是否结束
public class PlayerCollide : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Animator>().SetBool("run", false);
            this.GetComponent<Animator>().SetBool("run", false);
            other.gameObject.GetComponent<Animator>().SetTrigger("death");
            this.GetComponent<Animator>().SetTrigger("attack");
            //发布游戏结束消息
            Singleton<GameEventManager>.Instance.Gameover();
        }
    }
}
