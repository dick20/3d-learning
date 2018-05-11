using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Com.Mygame;

public class FirstController : MonoBehaviour, IUserAction, SceneController
{
    public PatrolFactory patrol_factory;                 
    public ScoreRecorder recorder;                               
    public PatrolActionManager action_manager;                      
    public int area_sign;
    public GameObject player;                 
    private List<GameObject> patrols;                        
    private bool game_over = false;                
    //实例化组件，加载资源
    void Start()
    {
        Director.getInstance().sceneController = this;
        patrol_factory = Singleton<PatrolFactory>.Instance;
        action_manager = (PatrolActionManager)gameObject.AddComponent<PatrolActionManager>();
        recorder = Singleton<ScoreRecorder>.Instance;
        load();
    }

    //每帧更新玩家位置，通知巡逻兵
    void Update()
    {
        for (int i = 0; i < patrols.Count; i++)
        {
            patrols[i].gameObject.GetComponent<PatrolData>().area_sign = area_sign;
        }
    }
    //订阅模式，分别订阅分数增加与游戏结束消息
    void OnEnable()
    {
        GameEventManager.ScoreChange += AddScore;
        GameEventManager.GameoverChange += Gameover;
    }
    void OnDisable()
    {
        GameEventManager.ScoreChange -= AddScore;
        GameEventManager.GameoverChange -= Gameover;
    }
    void AddScore()
    {
        recorder.addScore();
    }
    void Gameover()
    {
        game_over = true;
        patrol_factory.StopPatrol();
        action_manager.DestroyAllAction();
    }
    public void load()
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/Plane"));
        //player从高处掉落，才能产生碰撞
        player = Instantiate(Resources.Load("Prefabs/Player"), new Vector3(0, 5, 0), Quaternion.identity) as GameObject;
        patrols = patrol_factory.GetPatrols();
        //所有侦察兵移动
        for (int i = 0; i < patrols.Count; i++)
        {
            action_manager.patrolMove(patrols[i]);
        }
    }
    //实现接口的IUserAction的四个函数
    //玩家移动
    public void playerMove(float translationX, float translationZ)
    {
        //游戏未结束
        if(!game_over)
        {
            //设置动画
            if (translationX != 0 || translationZ != 0)
            {
                player.GetComponent<Animator>().SetBool("run", true);
            }
            //移动和旋转
            player.transform.Translate(translationX * 4f * Time.deltaTime, 0, translationZ * 4f * Time.deltaTime);
            player.transform.Rotate(0, translationX * 100f * Time.deltaTime, 0);
            //防止碰撞带来的移动
            if (player.transform.localEulerAngles.x != 0 || player.transform.localEulerAngles.z != 0)
            {
                player.transform.localEulerAngles = new Vector3(0, player.transform.localEulerAngles.y, 0);
            }
            if (player.transform.position.y != 0)
            {
                player.transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z);
            }
        }
    }
    public int getScore()
    {
        return recorder.getScore();
    }
    public bool getGameover()
    {
        return game_over;
    }
    //重置函数
    public void restart()
    {
        SceneManager.LoadScene("Scenes/mySence");
    }
}
