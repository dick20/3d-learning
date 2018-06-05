using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControll : MonoBehaviour
{
    //移动玩家
    void Update()
    {
        float translationX = Input.GetAxis("Horizontal");
        float translationZ = Input.GetAxis("Vertical");
        this.transform.Translate(translationX * 4f * Time.deltaTime, 0, translationZ * 4f * Time.deltaTime);
        //this.transform.Rotate(0, translationX * 100f * Time.deltaTime, 0);
       
    }
}
