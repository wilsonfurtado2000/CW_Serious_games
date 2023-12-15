using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public Animator objectAnimator;
    public bool isPlayer = false;
    public GameObject item;

    public Material newMaterial; 
    public Material oldMaterial; 

    public GameObject bottom; 
    public GameObject up; 

    public Material[] bottomMaterial;

    public Material[] upMaterial;

    public Vector3 itemOffet;
    public Quaternion itemRotation;
    private string objTag;

    public GameObject hintsCanvas;
    private bool alreadyOpened = false;



    void Start()
    {
        bottomMaterial = bottom.GetComponent<Renderer>().materials;
        objTag = gameObject.tag;

        upMaterial = up.GetComponent<Renderer>().materials;

        if (bottomMaterial.Length == 3 )
        {
            Debug.Log("1");
        }
        else
        {
            Debug.Log("0");
        }
    }

    void Update()
    {
        if (!alreadyOpened)
        {
            if (isPlayer)
            {
                bottomMaterial[1] = newMaterial;
                upMaterial[0] = newMaterial;
                bottom.GetComponent<Renderer>().materials = bottomMaterial;
                up.GetComponent<Renderer>().materials = upMaterial;
                if (Input.GetKeyDown(KeyCode.E))
                {

                    // Play animation
                    if (objectAnimator != null)
                    {
                        objectAnimator.SetTrigger("PlayAnimation");
                    }
                    alreadyOpened = true;

                    // hide object
                    //gameObject.SetActive(false);
                }

            }
            else
            {
                bottomMaterial[1] = oldMaterial;
                upMaterial[0] = oldMaterial;
                bottom.GetComponent<Renderer>().materials = bottomMaterial;
                up.GetComponent<Renderer>().materials = upMaterial;
            }
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        // when player in
        if (other.CompareTag("Player"))
        {
            isPlayer = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // when player leave
        if (other.CompareTag("Player"))
        {
            isPlayer = false;
        }
    }
    public void OnAnimationEnd()
    {
        // 当第3个动画播放完毕时，隐藏物体
        //gameObject.SetActive(false);
        //if (objTag != "Empty")
        //{
        //    Instantiate(item, transform.position+itemOffet, itemRotation);
        //}
        hintsCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseHints()
    {
        hintsCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
