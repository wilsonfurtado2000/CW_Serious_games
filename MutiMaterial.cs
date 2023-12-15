using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutiMaterial : MonoBehaviour
{
    public Material newMaterial; 
    public Material oldMaterial; 
    public bool isPlayer;

    void Start()
    {

    }

    void Update()
    {
        
        if (isPlayer)
        {
            GetComponent<Renderer>().material = newMaterial;
        }
        else
        {
            GetComponent<Renderer>().material = oldMaterial;
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
}
