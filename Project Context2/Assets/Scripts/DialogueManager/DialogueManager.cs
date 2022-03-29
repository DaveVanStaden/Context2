using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Text nameText;

    public Animator animator;
    public bool IsTalking;

    private bool isPlayer = false;
    private Queue<string> sentences;
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        IsTalking = true;
        nameText.text = dialogue.name;
        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence(dialogue);
    }

    public void DisplayNextSentence(Dialogue dialogue)
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        if (isPlayer)
        {
            nameText.text = dialogue.playerName;
            isPlayer = false;
        }
        else
        {
            nameText.text = dialogue.name;
            isPlayer = true;
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = " ";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return 1f;
        }
    }
    public void EndDialogue()
    {
        IsTalking = false;
        isPlayer = false;
        nameText.text = "";
        dialogueText.text = "";
        animator.SetBool("isOpen", false);
    }
}
