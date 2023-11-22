using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public float startTime = 60f;
    public Text timerText;
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject continueUI;

    public GameObject failedUI;
    //public GameObject Target;
    public GameObject Victory;

    //public AudioSource victoryAudio;
    //public AudioSource failtureAudio;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "Time:"+ startTime.ToString("0");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                continueUI.SetActive(true);
                Continue();
            }
            else
            {

                Pause();
            }
        }

        //TimeDown control
        startTime -= Time.deltaTime;
        timerText.text = "Time:" + startTime.ToString("0");
        if(startTime <= 10f)
        {
            timerText.color = Color.red;
        }

        if (startTime <= 0f)
        {
            timerText.text = "0";
            //failtureAudio.Play();
            pauseMenuUI.SetActive(true);
            failedUI.SetActive(true);
            //Time.timeScale = 0.0f;

            continueUI.SetActive(false);
        }

        //if (!Target)
        //{
        //    //failtureAudio.Play();
        //    pauseMenuUI.SetActive(true);
        //    failedUI.SetActive(true);
        //    //Time.timeScale = 0.0f;

        //    continueUI.SetActive(false);
        //}

        //if(GameManager.score >= 20)
        //{
        //    //victoryAudio.Play();
        //    Tovictory();
        //}
    }

    public void Continue()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;

    }

    public void Restart()
    {

        //pauseMenuUI.SetActive(false);


        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }

    public void MainMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }

    //public void Tovictory()
    //{
        
    //    Victory.SetActive(true);
    //    Time.timeScale = 0.0f;
    //}

    //public void ToNextLevel()
    //{
    //    Time.timeScale = 1.0f;
    //    SceneManager.LoadScene("Level2");
    //    GameManager.score = 0;
    //}

    public void QuitGame()
    {
        Application.Quit();
    }
}
