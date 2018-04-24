using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Adapter模式，IActionManager接口被物理学动作管理器与动力学动作管理器实现
//这些接口可以查看已经实现的CCActionManager中需要哪些实现
public interface IActionManager {
    void Throw(Queue<GameObject> diskQueue);
    //更改后，无法再直接访问DiskNumber,故需要两个接口函数来访问
    int getDiskNumber();
    void setDiskNumber(int num);
}
