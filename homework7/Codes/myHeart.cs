using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myHeart : MonoBehaviour
{
    private ParticleSystem particleSys;  // 粒子系统
    private ParticleSystem.Particle[] particleArr;  // 粒子数组  
    private Particle[] particles; // 粒子位置数组

    public Gradient colorGradient; // 粒子颜色改变器

    public int count = 10000;       // 粒子数量  
    public float size = 0.03f;      // 粒子大小  
    public float minRadius = 5.0f;  // 最小半径  
    public float maxRadius = 12.0f; // 最大半径  
    public bool clockwise = true;   // 顺时针|逆时针  
    public float speed = 2f;        // 速度  
    public float pingPong = 0.02f;  // 游离范围

    //粒子类，包括半径，角度，时间，相当于一个极坐标。
    public class Particle
    {
        public float x_pos = 0f, z_pos = 0f, time = 0f;
        public Particle(float x, float y, float z)
        {
            x_pos = x;
            z_pos = y;
            time = z;
        }
    }

    //初始化粒子数组，通过脚本控制粒子系统
    void Start()
    {
        particleArr = new ParticleSystem.Particle[count];
        particles = new Particle[count];

        // 初始化粒子系统  
        particleSys = this.GetComponent<ParticleSystem>();
        particleSys.startSpeed = 0;            // 粒子位置由程序控制  
        particleSys.startSize = size;          // 设置粒子大小
        particleSys.loop = false;              // 设置粒子不循环
        particleSys.maxParticles = count;      // 设置最大粒子量  
        particleSys.Emit(count);               // 发射粒子
        particleSys.GetParticles(particleArr);

        RandomlySpread();   // 初始化各粒子位置
    }
    void RandomlySpread()
    {
        for (int i = 0; i < count; ++i)
        {
            // 随机每个粒子的位置
            float x_pos = Random.Range(-5.0f, 5.0f);
            float z_pos = Random.Range(-5.0f, 5.0f);
            float angle = Random.Range(0.0f, 360.0f);
            float theta = angle / 360 * Mathf.PI;

            // 随机每个粒子的游离起始时间  
            float time = Random.Range(0.0f, 360.0f);

            particles[i] = new Particle(x_pos, z_pos, time);

            particleArr[i].position = new Vector3(0f, 0f, 0f);
        }
        particleSys.SetParticles(particleArr, particleArr.Length);
    }
    // Update is called once per frame
    private int tier = 10;  // 速度差分层数
    void Update()
    {
        for (int i = 0; i < count; i++)
        {
            /*if (clockwise)  // 顺时针旋转  
                particles[i].angle -= (i % tier + 1) * (speed / particles[i].radius / tier);
            else            // 逆时针旋转  
                particles[i].angle += (i % tier + 1) * (speed / particles[i].radius / tier);

            // 保证angle在0~360度*/
            //particles[i].angle = (360.0f + particles[i].angle) % 360.0f;
            float theta = Random.Range(0.0f, 360.0f) / 180 * Mathf.PI;

            particleArr[i].position = new Vector3(16 * Mathf.Sin(theta) * Mathf.Sin(theta) * Mathf.Sin(theta) + Random.Range(-1f, 1f), 0f,
                13 * Mathf.Cos(theta) - 5 * Mathf.Cos(theta * 2) - 2 * Mathf.Cos(theta * 3) - Mathf.Cos(4 * theta) + Random.Range(-1f, 1f));
            // 粒子在半径方向上游离  
            particles[i].time += Time.deltaTime;
            particles[i].x_pos += Mathf.PingPong(particles[i].time / minRadius / maxRadius, pingPong) - pingPong / 2.0f;
            particles[i].z_pos += Mathf.PingPong(particles[i].time / minRadius / maxRadius, pingPong) - pingPong / 2.0f;

            particleArr[i].color = colorGradient.Evaluate(Random.value);
        }

        particleSys.SetParticles(particleArr, particleArr.Length);
    }
}
