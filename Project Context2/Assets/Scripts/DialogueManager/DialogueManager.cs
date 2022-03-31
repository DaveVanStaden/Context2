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
    public GameObject hintText;

    public Animator animator;
    public bool IsTalking;
    public AnimationForester forester;
    public EndingGame gameEnd;
    private bool isPlayer = false;
    private Queue<string> sentences;
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        hintText.gameObject.SetActive(true);
        if (dialogue.IsForester)
        {
            forester.TalkingAnimation();
        }
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
            if (dialogue.IsForester)
            {
                forester.IdleAnimation();
            }

            if (dialogue.isEnding)
            {
                gameEnd.endGame();
            }
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
            yield return new WaitForSeconds(0.01f);
        }
    }
    public void EndDialogue()
    {
        hintText.gameObject.SetActive(false);
        IsTalking = false;
        isPlayer = false;
        nameText.text = "";
        dialogueText.text = "";
        animator.SetBool("isOpen", false);
    }
}
