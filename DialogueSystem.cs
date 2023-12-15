using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public float textSpeed = 0.05f;
    public Button continueButton;

    public Animator animator;

    public Dialogue correctDialogue;
    public GameObject correctPanel;


    private Queue<string> sentences;
    public bool victory;
    public PauseMenu pauseMenu;
    private bool alreadyVictory = false;



    void Start()
    {
        pauseMenu = GameObject.Find("GameCanvas").GetComponent<PauseMenu>();
        sentences = new Queue<string>();

    }

    void Update()
    {
        if (!alreadyVictory && pauseMenu.isVictory)
        {
            correctPanel.SetActive(true);
            startDialogue(correctDialogue);
            alreadyVictory = true;

        }
    }



    public void startDialogue(Dialogue dialogue)
    {

        animator.SetBool("isOpen", true);

        //UnityEngine.Debug.Log("Starting conversation" + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (var sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {   

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }


    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            // yield return null;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void EndDialogue()
    {
        if(SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        animator.SetBool("isOpen", false);
    }
}
