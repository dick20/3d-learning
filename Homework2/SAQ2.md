# 作业内容

------

## 1、简答并用程序验证
### A. 游戏对象运动的本质是什么？
&emsp;&emsp;游戏对象运动的本质就是坐标的变换，包括世界坐标（绝对坐标）的变换和对象坐标（相对坐标）的变换。每个游戏对象必须有一个Transform组件，我们可以通过改变该组件的属性来让游戏对象运动起来。
    
------
### B. 请用三种方法以上方法，实现物体的抛物线运动。（如，修改Transform属性，使用向量Vector3的方法…）
>* 利用transform方法直接改变position
```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour {
    public int a = 2;
    private void Update()
    {
        this.transform.position += Vector3.right * Time.deltaTime * 1f;
        this.transform.position += Vector3.down * Time.deltaTime * Time.deltaTime * a;
    }
}
```
>* 利用Vector3的MoveTowards方法
```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveup : MonoBehaviour {
    //The target marker
    Vector3 target1 = Vector3.right * 5;
    Vector3 target2 = Vector3.down * 5;
    float speed1 = 1;
    float speed2 = 4;
    // Update is called once per frame
    void Update(){
        float step1 = speed1 * Time.deltaTime;
        float step2 = speed2 * Time.deltaTime * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target1, step1);
        transform.position = Vector3.MoveTowards(transform.position, target2, step2);
    }
}
```
>* 使用Vector3.Lerp()方法
```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour {
    public float Speed = 0.5f;
    Vector3 Target1 = new Vector3(-6, -3, 8);
    //控制物体向Target移动
    void Update()
    {
        gameObject.transform.localPosition = Vector3.Lerp(transform.position, Target1, Speed * Time.deltaTime);
    }
}
```
>* 利用transform.Translate()方法
function Translate (translation : Vector3, relativeTo : Space = Space.Self) : void
物体以relativeTo为参照系，沿着translation运动|translation|的距离。如果relativeTo缺省将以Space.Self为默认值。

------
### C.写一个程序，实现一个完整的太阳系， 其他星球围绕太阳的转速必须不一样，且不在一个法平面上。
![效果图](https://www.zybuluo.com/static/img/logo.png)
```c#
//对于八大行星围绕太阳公转
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour {
    public Transform sun;
    public float speed = 15;
    private float random_x, random_y;

    private void Start()
    {
        random_x = Random.Range(1, 10);
        random_y = Random.Range(10, 60);
    }
    void Update()
    {
        Vector3 axis = new Vector3(random_x, random_y, 0); //围绕哪一条轴旋转
        this.transform.RotateAround(sun.position, axis, speed * Time.deltaTime);
    }
}
```

```c#
//对于地球的自转
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        this.transform.RotateAround(this.transform.position, Vector3.up, 2);
    }
}
```
------
## 2、编程实践
### A. 阅读以下游戏脚本
Priests and Devils

Priests and Devils is a puzzle game in which you will help the Priests and Devils to cross the river within the time limit. There are 3 priests and 3 devils at one side of the river. They all want to get to the other side of this river, but there is only one boat and this boat can only carry two persons each time. And there must be one person steering the boat from one side to the other side. In the flash game, you can click on them to move them and click the go button to move the boat to the other direction. If the priests are out numbered by the devils on either side of the river, they get killed and the game is over. You can try it in many > ways. Keep all priests alive! Good luck!
### B. 程序需要满足的要求：
>* play the game ( http://www.flash-game.net/game/2535/priests-and-devils.html )
>* 列出游戏中提及的事物（Objects）
    &emsp;&emsp;魔鬼，牧师，河流，船，左岸边，右岸边
>* 用表格列出玩家动作表（规则表），注意，动作越少越好
&emsp;&emsp;![列表](https://www.zybuluo.com/static/img/logo.png)
>* 请将游戏中对象做成预制
&emsp;&emsp;![Perfabs](https://www.zybuluo.com/static/img/logo.png)
>* 在 GenGameObjects 中创建 长方形、正方形、球 及其色彩代表游戏中的对象。
&emsp;&emsp;白正方形表示牧师，黑球代表魔鬼，棕色长方体代表船,绿色长方体左右岸，蓝色长方体代表河流。
>* 使用 C# 集合类型 有效组织对象
>* 整个游戏仅 主摄像机 和 一个 Empty 对象， 其他对象必须代码动态生成！！！ 。 整个游戏不许出现 Find 游戏对象， SendMessage 这类突破程序结构的 通讯耦合 语句。 违背本条准则，不给分
>* 请使用课件架构图编程，不接受非 MVC 结构程序
>* 注意细节，例如：船未靠岸，牧师与魔鬼上下船运动中，均不能接受用户事件！
