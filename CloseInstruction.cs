using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInstruction : MonoBehaviour
{   
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    // Start is called before the first frame update
    public void Close()
    {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
