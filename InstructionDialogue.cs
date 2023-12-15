using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class InstructionDialogue : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public float textSpeed = 0.05f;
    public Button continueButton; 

    public Animator animator;
    public GameObject panel;
    public GameObject picture;
    public Dialogue levelDialogue;
    private Queue<string> sentences;



    void Start()
    {
        sentences = new Queue<string>();
        startDialogue(levelDialogue);

    }

    //void Update()
    //{

    //    if (Input.GetKeyDown(KeyCode.Return) && !isEnterPressed)
    //    {
    //        isEnterPressed = true;
    //        TriggerButtonClick();
    //    }

    //    if (Input.GetKeyUp(KeyCode.Return))
    //    {
    //        isEnterPressed = false;
    //    }
    //}

    //public void TriggerButtonClick()
    //{

    //    if (continueButton != null && continueButton.IsInteractable())
    //    {

    //        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);

    //        continueButton.onClick.Invoke();

    //        ExecuteEvents.Execute(continueButton.gameObject, pointerEventData, ExecuteEvents.pointerClickHandler);
    //    }
    //}

    public void startDialogue(Dialogue dialogue)
    {

        animator.SetBool("isOpen", true);

        UnityEngine.Debug.Log("Starting conversation" + dialogue.name);

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

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void EndDialogue()
    {
        panel.SetActive(false);
        animator.SetBool("isOpen", false);
        picture.SetActive(true);
    }
}
