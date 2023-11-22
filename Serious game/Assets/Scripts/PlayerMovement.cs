using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    //Define the CharacterController
    public CharacterController cc;
    void Start()
    {
        //variable of Component
        cc = transform.GetComponent<CharacterController>();

    }

    void Update()
    {
        move_by_cc();
    }

    void move_by_cc()
    {
        //Horizontal Input
        float x = Input.GetAxisRaw("Horizontal");
        //Vertical Input
        float z = Input.GetAxisRaw("Vertical");

        /*�����inputʹ��GetAxis()ʱ���ɿ��������ɫ������ƶ�һС���־��룬�����һ�֡����滬������Ч����
        ʹ��GetAxisRaw()�Ļ��򼴰����������ɼ�ͣ*/
        if (Mathf.Abs(x) > 0.1f || Mathf.Abs(z) > 0.1f)
        {
            //Control Move Direction
            Vector3 toward_dir = new Vector3(x, 0, z);

            //Character direction keep same with Input Direction
            transform.LookAt(transform.position + toward_dir);

            cc.SimpleMove(transform.forward * speed);
        }
    }
}
