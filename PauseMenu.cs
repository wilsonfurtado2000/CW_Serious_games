using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public float startTime = 0f;
    public Text timerText;
    public static bool GameIsPaused = false;
    public bool isVictory = false;
    //private bool isCursorLocked = true;
    public bool isStart = false;
    public GameObject mute;
    public GameObject muted;

    public GameObject pauseMenuUI;
    public GameObject pauseText;
    public GameObject continueUI;

    public GameObject failedUI;
    //public GameObject Target;
    public GameObject Victory;
    public PlayerMovement playerMovement;

    //public AudioSource victoryAudio;
    //public AudioSource failtureAudio;

    // Start is called before the first frame update
    void Start()
    {
        
        timerText.text = "Time:"+ startTime.ToString("0");
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {   
        if(GameIsPaused)
        {
            CursorUnlock();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !isVictory)
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
        
        startTime += Time.deltaTime;
        //int hour = (int)startTime / 3600;
        int minute = (int)startTime / 60;
        int second = (int)startTime % 60;
        timerText.text = string.Format("{0:D2}:{1:D2}", minute, second);
        
        //if(startTime <= 10f)
        //{
        //    timerText.color = Color.red;
        //}

        //if (startTime <= 0f)
        //{
        //    timerText.text = "0";
        //    //failtureAudio.Play();
        //    pauseMenuUI.SetActive(true);
        //    pauseText.SetActive(false);
        //    failedUI.SetActive(true);
        //    //Time.timeScale = 0.0f;

        //    continueUI.SetActive(false);
        //}

        if(playerMovement.itemGet)
        {
            CursorUnlock();
            isVictory = true;

        }

    }
    void CursorLock()
    {
        
        //isCursorLocked = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void CursorUnlock()
    {

        //isCursorLocked = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void MuteAllSound()
    {
        muted.SetActive(true);
        AudioListener.volume = 0;
        mute.SetActive(false);
    }

    public void UnMuteAllSound()
    {
        //mute.interactable = true;
        //AudioListener.volume = 1;
        //muted.interactable = false;
        mute.SetActive(true);
        AudioListener.volume = 1;
        muted.SetActive(false);
    }

    public void Continue()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
        CursorLock();

    }
    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void Restart()
    {

        //pauseMenuUI.SetActive(false);


        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        CursorLock();
    }

    public void Pause()
    {   
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
        CursorUnlock();
    }

    public void MainMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");

    }

    //public void toVictory()
    //{
    //    CursorLock();

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
