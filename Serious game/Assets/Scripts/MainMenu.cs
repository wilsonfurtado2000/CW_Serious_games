using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu;

    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //public void Instruction()
    //{
    //    SceneManager.LoadScene("Instruction");
    //}

    //public void Select()
    //{
    //    SceneManager.LoadScene("Select");
    //}

    public void QuitGame()
    {
        Application.Quit();
    }

}
