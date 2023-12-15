using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool victory;
    public bool alreadyVictory = true;
    public GameObject correctPanel;
    public GameObject gameCanvas;


    void start()
    {

    }

    void Update()
    {
        victory = gameCanvas.GetComponent<PauseMenu>().isVictory;
        if (victory && alreadyVictory)
        {
            correctPanel.SetActive(true);
            TriggerDialogue();
            alreadyVictory = false;
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueSystem>().startDialogue(dialogue);
    }
}
