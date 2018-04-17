﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class FirstController : MonoBehaviour, SceneController, IUserAction
{
    public CCActionManager actionManager;
    public ScoreRecorder scoreRecorder;
    public Queue<GameObject> diskQueue = new Queue<GameObject>();
    private int diskNumber;
    private int currentRound = -1;
    public int round = 3;
    private float time = 0;
    private GameState gameState = GameState.START;

    //鼠标点击事件
    public void hit(Vector3 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if (hit.collider.gameObject.GetComponent<DiskComponent>() != null)
            {
                scoreRecorder.setScore(hit.collider.gameObject);
                /*如果飞碟被击中，那么就移到地面之下，由工厂负责回收 */
                hit.collider.gameObject.transform.position = new Vector3(0, -6, 0);
            }
        }
    }
    //飞碟飞行动作
    void ThrowDisk()
    {
        if (diskQueue.Count != 0)
        {
            GameObject disk = diskQueue.Dequeue();
            /*确定飞碟出现的位置 */
            Vector3 position = new Vector3(0, 0, 0);
            float y = UnityEngine.Random.Range(0f, 4f);
            position = new Vector3(-disk.GetComponent<DiskComponent>().direction.x * 7, y, 0);
            disk.transform.position = position;
            disk.SetActive(true);
        }

    }

    void Awake()
    {
        Director director = Director.getInstance();
        director.sceneController = this;
        diskNumber = 10;
        this.gameObject.AddComponent<ScoreRecorder>();
        this.gameObject.AddComponent<DiskFactory>();
        scoreRecorder = Singleton<ScoreRecorder>.Instance;
        director.sceneController.load();
    }
    int[] point = new int[4] { 1, 5, 15, 30 };
    int num = 0;
    private void Update()
    {
        //游戏结束
        if (scoreRecorder.getScore() <= point[num] && gameState == GameState.ROUND_FINISH)
        {
            //再次初始化
            currentRound = -1;
            round = 3;
            time = 0;
            num = 0;
            gameState = GameState.GAME_OVER;
            scoreRecorder.Reset();
        }
        if (scoreRecorder.getScore() >= 30 && gameState == GameState.ROUND_FINISH)
        {       
            //再次初始化
            currentRound = -1;
            round = 3;
            time = 0;
            num = 0;
            scoreRecorder.Reset();
            gameState = GameState.WIN;
        }
            //回合结束
        if (actionManager.DiskNumber == 0 && gameState == GameState.RUNNING)
        {
            gameState = GameState.ROUND_FINISH;
        }
        //回合开始
        if (actionManager.DiskNumber == 0 && gameState == GameState.ROUND_START)
        {
            currentRound = (currentRound + 1) % round;
            num++;
            DiskFactory df = Singleton<DiskFactory>.Instance;
            for (int i = 0; i < diskNumber; i++)
            {
                diskQueue.Enqueue(df.GetDisk(currentRound));
            }
            actionManager.Throw(diskQueue);
            actionManager.DiskNumber = 10;
            gameState = GameState.RUNNING;
        }
        if (time > 0.5)
        {
            ThrowDisk();
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
        }
        Debug.Log(num);
    }
    //游戏资源的加载
    public void load()
    {

    }
    public void GameOver()
    {
        setGameState(GameState.GAME_OVER);
    }
    public int GetScore()
    {
        return scoreRecorder.getScore();
    }

    public GameState getGameState()
    {
        return gameState;
    }

    public void setGameState(GameState gs)
    {
        gameState = gs;
    }
}

