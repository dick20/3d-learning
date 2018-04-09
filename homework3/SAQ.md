# 作业内容

------
## 操作与总结
### 1.参考 Fantasy Skybox FREE 构建自己的游戏场景
>* 在主摄像机加入Skybox组件后，拖动已经实现的天空材料，由此生成天空盒。
>* 加入一个Plane与一个Cube游戏对象。
>* 增加多一个摄像头，实现Cube的俯视图，需要注意的是调整摄像头的Depth大于-1，且将视图的大小和位置调整至右下角。

实现效果如下图所示：

![show1](https://github.com/dick20/3d-learning/blob/master/homework3/image/图片1.png)
![show2](https://github.com/dick20/3d-learning/blob/master/homework3/image/图片2.png)

### 2.写一个简单的总结，总结游戏对象的使用
+ 具体上来说，所有游戏对象都有Active属性，Name属性，Tag属性等。每个游戏对象 (GameObject) 还包含一个变换transform组件。我们可以通过这个组件来使游戏对象改变位置，旋转和缩放。我们还可以添加许许多多不同的组件或脚本来增加游戏对象的功能。
+ 细节上来说，主要包括以下几大类
  + 常见游戏对象<br />
如正方体，球体，平面等等，还有空对象，不显示却是最常用的对象之一。
  + Camera 摄像机<br />
它是观察游戏世界的窗口，Projection属性包括正交视图与透视视图。Viewport Rect:属性是控制摄像机呈现结果对应到屏幕上的位置以及大小。屏幕坐标系：左下角是(0, 0)，右上角是(1, 1)。Depth属性是当多个摄像机同时存在时，这个参数决定了呈现的先后顺序，值越大越靠后呈现。
  + skyboxes 天空盒<br />
天空是一个球状贴图，通常用 6 面贴图表示。
使用方法有两步，第一为在摄像机添加天空组件。Component 加入skybox组件，第二为直接拖入天空材料（Material）。
  + 光源Light<br />
灯光类型（type）包括平行光（类似太阳光），聚光灯（spot），点光源（point），区域光（area，仅烘培用）。
  + 地形构造工具Terrain<br />
属性解释如图所示：
![show3](https://github.com/dick20/3d-learning/blob/master/homework3/image/图片3.png)
  + 声音audio<br />
将声音素材拖入摄像机就可以成为背景音乐。可以设置是否重复，音量等属性
  + 游戏资源库<br />
从商店中查找所需资源后，import packages后就可以在resource中自由使用这些资源。

---
