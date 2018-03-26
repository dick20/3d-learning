# 一、简答题
------
## 1.解释游戏对象（GameObjects）和资源（Assets）的区别与联系。
**游戏对象：** 游戏中的每个对象都是一个游戏对象。然而，游戏对象自己不做任何事。他们需要专有属性，才可以成为一个角色，一个环境，或一个特殊效果。游戏对象是一种容器。根据你要创建的对象性质，添加不同的组件组合到游戏对象中。想象一个游戏对象是一口锅，组件是不同的作料，它们构成了你的游戏食谱。游戏对象更加像是多个资源的整理合并起来的具体表现。

**资源：** 游戏会用到的资源，比如，模型文件，贴图文件，声音文件，脚本文件等等。资源可以作为模板，可实例化成游戏中具体的对象。资源之中可以包含多个游戏对象的类别，当需要使用时可直接添加到场景处。资源是可以被多个对象使用的，本身也可以进行实例化。对比起对象，资源更像是集成的可扩展的模板包。

------
## 2.下载几个游戏案例，分别总结资源、对象组织的结构（指资源的目录组织结构与游戏对象树的层次结构）
![structure of objects](https://www.zybuluo.com/static/img/logo.png)
![assets](https://www.zybuluo.com/static/img/logo.png)

查看了几个游戏案例后，资源的目录组织结构基本包括Prefabs预设，resources动态加载的资源文件，Scenes场景文件，Scenes场景文件，Scripts脚本代码文件，Sounds音效文件，Textures所有的贴图等等...而游戏对象树类似于多个父子继承关系，一个游戏对象往往是包括了多个子对象。

------
## 3.编写一个代码，使用 debug 语句来验证 MonoBehaviour 基本行为或事件触发的条件。基本行为包括 Awake() Start() Update() FixedUpdate() LateUpdate()常用事件包括 OnGUI() OnDisable() OnEnable()

```c#   
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class NewBehaviourScript1 : MonoBehaviour {
 
    void Awake()
    {
        Debug.Log("Awake!");
    }
    void Start()
    {
        Debug.Log("Start!");
    }
 
    void Update()
    {
        Debug.Log("Update!");
    }
    void FixedUpdate()
    {
        Debug.Log("FixedUpdate!");
    }
    void LateUpdate()
    {
        Debug.Log("LateUpdate!");
    }
    void Reset()
    {
        Debug.Log("Reset!");
    }
    void OnGUI()
    {
        Debug.Log("onGUI!");
    }
    void OnDisable()
    {
        Debug.Log("onDisable!");
    }
    void OnDestroy()
    {
        Debug.Log("onDestroy!");
    }
}
```
###解释：
> * **Awake：**用于在游戏开始之前初始化变量或游戏状态。在脚本整个生命周期内它仅被调用一次.Awake在所有对象被初始化之后调用。
> * **Start：**仅在Update函数第一次被调用前调用。Start在behaviour的生命周期中只被调用一次。
> * **FixedUpdate：**固定帧更新，更新频率默认为0.02s。
> * **Update：**正常帧更新，用于更新逻辑，每一帧都执行。FixedUpdate比较适用于物理引擎的计算，因为是跟每帧渲染有关。Update就比较适合做控制。
> * **LateUpdate：**在所有Update函数调用后被调用，和fixedupdate一样都是每一帧都被调用执行，这可用于调整脚本执行顺序。
> * **OnGUI：**在渲染和处理GUI事件时调用。这意味着OnGUI也是每帧执行一次。
> * **Reset：**在用户点击检视面板的Reset按钮或者首次添加该组件时被调用。
> * **OnDisable：**当物体被销毁时 OnDisable将被调用，并且可用于任意清理代码。脚本被卸载时，OnDisable将被调用，OnEnable在脚本被载入后调用。
> * **OnDestroy：**当MonoBehaviour将被销毁时，这个函数被调用。OnDestroy只会在预先已经被激活的游戏物体上被调用。

### 效果截图如下
![3](https://www.zybuluo.com/static/img/logo.png)
![4](https://www.zybuluo.com/static/img/logo.png)

------
##4.查找脚本手册，了解GameObject，Transform，Component 对象

### A.分别翻译官方对三个对象的描述（Description)
> * **GameObject:** 游戏中的每个对象都是一个游戏对象(GameObject)。然而，游戏对象(GameObjects)本身不做任何事情。它们需要特殊属性(special properties)才能成为一个角色、一种环境或者一种特殊效果。
> * **Transform：**变换(Transforms)是每个游戏对象(GameObject)的关键组件(Component)。它们决定游戏对象 (GameObject)的位置、旋转方式及缩放。
> * **Reset：**在游戏中，组件(Components)就是对象和行为的螺栓与螺母，它们是每个游戏对象 (GameObject)的功能零件。

### B.描述下图中table对象（实体）的属性、table的Transform的属性、table的部件。本题目要求是把可视化图形编程界面与 Unity API 对应起来，当你在Inspector面板上每一个内容，应该知道对应 API。

![5](https://www.zybuluo.com/static/img/logo.png)

&emsp; table 的对象是GameObject，第一个选择框是 activeSelf属性，第二个选择框是Transform属性，第三个选择框是Mesh Filter筛网过滤器属性，第四个选择框是Box Collider属性，第五个选择框是Mesh Renderer筛网渲染器属性，第六个选择框是Default-Material属性。
&emsp; 其中table的Transform属性有Position X为0、Y为0、Z为0，Rotation X为0、Y为0、Z为0，Scale X为1、Y为1、Z为1。

### C.用 UML 图描述 三者的关系（请使用 UMLet 14.1.1 stand-alone版本画图）

![6](https://www.zybuluo.com/static/img/logo.png)

------
## 5.整理相关学习资料，编写简单代码验证以下技术的实现：
### A.查找对象
* 通过对象名称**public static GameObject Find(string name)**;通过名字寻找对象并返回它，只返回active GameObject，如果没有GameObject，则返回null。如果名称内包含“/”字符，会当做是hierarchy中的一个路径名。

```c#   
void Awake()
    {
        Debug.Log("Awake!");
    }
    void Start()
    {
        Debug.Log("Start!");
        var cube = GameObject.Find("chair1");
        if (cube != null)
        {
            Debug.Log("find chir1");
        }
}
```
![7](https://www.zybuluo.com/static/img/logo.png)

* 通过标签获取单个游戏对象**public static GameObject FindWithTag(string tag))**返回一个用tag做标识的活动的对象，如果没有找到则为null。
* 通过标签获取多个游戏对象**public static GameObject[] FindGameObjectsWithTag(string tag)**;返回一个用tag做标识的游戏对象的数组，如果没有找到对象则返回空数组。
* 通过类型获取单个游戏对象**public static GameObject[] FindObjectOfType(string type)**;返回第一个类型为type的活动的对象，如果没有找到则为null。
* 通过类型获取多个游戏对象 返回一个类型为type的游戏对象的数组，如果没有找到对象则返回空数组。**public static GameObject[] FindObjectsOfType(string type)**;

### B.添加子对象
```c#   
public static GameObject CreatePrimitive(PrimitiveType type);
void Start()
    {
        Debug.Log("Start!");
        var cube = GameObject.Find("Cube");
        if (cube != null)
        {
            Debug.Log("find chir1");
        }
        GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
        temp.transform.parent = cube.transform;
        temp.transform.position = new Vector3(2, 1, 1);
}
```
![8](https://www.zybuluo.com/static/img/logo.png)

### C.遍历对象树
```c#   
foreach (Transform child in transform) {
            Debug.Log(child.position);
        }
```
![9](https://www.zybuluo.com/static/img/logo.png)

### D.清除所有子对象
```c#   
foreach (Transform child in transform) {
    Destroy(child.gameObject);
}
```

------
## 6.资源预设（Prefabs）与 对象克隆 (clone)
### A.预设（Prefabs）有什么好处？
&emsp;预设是一个非常容易复用的类模板，可以迅速方便创建大量相同属性的对象、操作简单，代码量少，减少出错概率。
###B.预设与对象克隆(clone or copy or Instantiate of Unity Object)关系？
&emsp;预设可以使修改的复杂度降低，一旦需要修改所有相同属性的对象，只需要修改预设即可，所有通过预设实例化的对象都会做出相应变化。而克隆只是复制一个一模一样的对象，这个对象独立于原来的对象，在修改的过程中不会影响原有的对象，这样不方便整体改动。
### C.制作 table 预制，写一段代码将 table 预制资源实例化成游戏对象
```c#   
 void Start()
    {
        Debug.Log("Start!");
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = "a cube";
        cube.transform.position = new Vector3(0, 1, 2);
        cube.transform.parent = this.transform;
    }
```

------
## 7. 尝试解释组合模式（Composite Pattern / 一种设计模式），使用 BroadcastMessage() 方法 向子对象发送消息
&emsp;**组合模式（Composite Pattern）**，又叫部分整体模式，是用于把一组相似的对象当作一个单一的对象。组合模式依据树形结构来组合对象，用来表示部分以及整体层次。这种类型的设计模式属于结构型模式，它创建了对象组的树形结构。这种模式创建了一个包含自己对象组的类。该类提供了修改相同对象组的方式。组合模式是将对象组合成树形结构以表示“部分-整体”的层次结构，它使得用户对单个对象和组合对象的使用具有一致性。
```c#   
void test()
{
    Debug.Log("test_for_BroadcastMessage!!");
}
void Start()
{
    this.BroadcastMessage("test");
}
```
------
