using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolution : MonoBehaviour {
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
