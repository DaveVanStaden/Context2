using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager _dialogueManager;
    public Dialogue dialogue;

    private bool colliderPlayer;

    private void Update()
    {
        if (colliderPlayer)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TriggerDialogue();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                _dialogueManager.DisplayNextSentence(dialogue);
            } 
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            colliderPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            colliderPlayer = false;
            _dialogueManager.EndDialogue();
        }
    }
}
