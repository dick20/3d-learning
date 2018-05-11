using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class PatrolFactory : MonoBehaviour
{
    private GameObject patrol = null;                              //巡逻兵
    private List<GameObject> used = new List<GameObject>();        //正在被使用的巡逻兵
    private Vector3[] vec = new Vector3[9];                        //保存每个巡逻兵的初始位置

    public List<GameObject> GetPatrols()
    {
        int[] pos_x = { -11, -1, 8 };
        int[] pos_z = { -3, 6, -13 };
        int index = 0;
        //生成不同的巡逻兵初始位置
        for(int i=0;i < 3;i++)
        {
            for(int j=0;j < 3;j++)
            {
                vec[index] = new Vector3(pos_x[i], 0, pos_z[j]);
                index++;
            }
        }
        for(int i=0; i < 9; i++)
        {
            patrol = Instantiate(Resources.Load<GameObject>("Prefabs/Patrol"));
            patrol.transform.position = vec[i];
            patrol.AddComponent<PatrolData>();
            patrol.GetComponent<PatrolData>().sign = i + 1;
            patrol.GetComponent<PatrolData>().start_position = vec[i];
            used.Add(patrol);
        }
        
        return used;
    }

    //停止巡逻兵的动画
    public void StopPatrol()
    {
        for (int i = 0; i < used.Count; i++)
        {
            used[i].gameObject.GetComponent<Animator>().SetBool("run", false);
        }
    }
}
