using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isInRange = false;
    public bool itemGet = false;
    public bool isWrongItem = false;
    public GameObject wrongCanvas;
    //Define the CharacterController
    public CharacterController cc;

    //public float jumpSpeed;
    public float moveSpeed = 10f;
    public float jumpSpeed = 5f;
    private float horizontalMove, verticalMove;
    private Vector3 dir;
    public PauseMenu pauseMenu;

    public float gravity = 9.81f;
    private Vector3 velocity;
    public Transform groundCheck;
    public float checkRadius = 0.4f;
    public LayerMask groundLayer;
    public bool isGround;

    void Start()
    {
        //variable of Component
        cc = transform.GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            itemGet = true;
        }
        else if (isWrongItem && Input.GetKeyDown(KeyCode.E))
        {
            wrongCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void CloseWindow()
    {
        wrongCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Move()
    {
        ////Horizontal Input
        //float x = Input.GetAxisRaw("Horizontal");
        ////Vertical Input
        //float z = Input.GetAxisRaw("Vertical");
        isGround = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxis("Vertical") * moveSpeed;

        /*上面的input使用GetAxis()时在松开按键后角色会继续移动一小部分距离，会产生一种“冰面滑动”的效果，
        使用GetAxisRaw()的话则即按即动，即松即停*/
        if (Mathf.Abs(horizontalMove) > 0.1f || Mathf.Abs(verticalMove) > 0.1f)
        {
            ////Control Move Direction
            //Vector3 toward_dir = new Vector3(x, 0, z);

            ////Character direction keep same with Input Direction
            //transform.LookAt(transform.position + toward_dir);

            //cc.SimpleMove(transform.forward * speed);

            dir = transform.forward * verticalMove + transform.right * horizontalMove;
            cc.Move(dir * Time.deltaTime);
        }
        if (Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = jumpSpeed;
        }

        velocity.y -= gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            isInRange = true;
            
        }

        if (other.CompareTag("WrongItem"))
        {
            isWrongItem = true;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            isInRange = false;
           
        }

        if (other.CompareTag("WrongItem"))
        {
            isWrongItem = false;

        }

    }
}
