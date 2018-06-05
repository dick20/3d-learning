using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testHP : MonoBehaviour {

    public int HP = 1000;
    public Slider HPStrip;    //添加血条Slider的引用

    void Start()
    {
        HPStrip.value = HPStrip.maxValue = HP;    //初始化血条
    }

    void Update()
    {
        if (this.transform.position.z < 9)
        {
            HPStrip.value--;
        }
        else
        {
            HPStrip.value++;
        }
    }
}
