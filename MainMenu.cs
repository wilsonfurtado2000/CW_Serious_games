using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject instructionCanvas;

    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Instruction()
    {
        instructionCanvas.SetActive(true);
    }

    public void CloseInstruction()
    {
        instructionCanvas.SetActive(false);
    }

    //public void Select()
    //{
    //    SceneManager.LoadScene("Select");
    //}

    public void QuitGame()
    {
        Application.Quit();
    }

}
