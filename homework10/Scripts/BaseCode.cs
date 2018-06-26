using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

namespace Com.Mygame
{
    //导演类，单例模式
    public class Director : System.Object
    {
        private static Director D_instance;
        public SceneController sceneController { get; set; }

        public static Director getInstance()
        {
            if (D_instance == null)
                D_instance = new Director();
            return D_instance;
        }
    }
    //场景控制器，被FirstController类所继承来加载资源预设
    public interface SceneController
    {
        void load();
        bool getGameover();
        int getScore();
        void restart();
    }
    //用户界面接口
    public interface IUserAction
    {
        //通过键盘输入移动玩家
        void playerMove(float translationX, float translationZ);
        //得到分数
        int getScore();
        //得到游戏结束标志
        bool getGameover();
        //重新开始
        void restart();
    }
    //动作回调接口
    public interface ISSActionCallback
    {
        void SSActionEvent(SSAction source, int intParam = 0, GameObject objectParam = null);
    }
    //巡逻兵的属性
    public class PatrolData : MonoBehaviour
    {
        public int area_sign = -1;            //当前玩家Player所在区域标志
        public GameObject player;             //Player游戏对象
        public int sign;                      //标志巡逻兵在哪一块区域
        public bool follow_player = false;    //跟随玩家标志
        public Vector3 start_position;        //巡逻兵的初始位置     
    }

}


