using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //�������Ҫ��������ľ���
    public Vector3 Dir;
    //Ҫ���������
    public GameObject player;
    // Use this for initialization
    void Start()
    {
        //��ȡ���������Ҫ��������֮��ľ���
        Dir = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //�������λ��
        transform.position = player.transform.position - Dir;
    }
}
