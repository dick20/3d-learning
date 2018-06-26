using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

//巡逻兵碰撞器脚本，用于判断是否追踪玩家
public class PatrolCollide : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.tag);
        if (collider.gameObject.tag == "Player")
        {
            this.gameObject.transform.parent.GetComponent<PatrolData>().player = collider.gameObject;
            this.gameObject.transform.parent.GetComponent<PatrolData>().follow_player = true;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            this.gameObject.transform.parent.GetComponent<PatrolData>().player = null;
            this.gameObject.transform.parent.GetComponent<PatrolData>().follow_player = false;
        }
    }
}
