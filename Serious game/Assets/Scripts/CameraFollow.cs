using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //摄像机于要跟随物体的距离
    public Vector3 Dir;
    //要跟随的物体
    public GameObject player;
    // Use this for initialization
    void Start()
    {
        //获取到摄像机于要跟随物体之间的距离
        Dir = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //摄像机的位置
        transform.position = player.transform.position - Dir;
    }
}
