using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public event EventHandler<OnDialogueBoxTriggeredEventArgs> OnDialogueBoxTriggered;
    public class OnDialogueBoxTriggeredEventArgs : EventArgs
    {
        public bool showing;
    }

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Queue<string> sentences = new Queue<string>();

    public void StartDialogue(DialogueClass dialogue)
    {
        nameText.text = dialogue.Name;
        sentences.Clear();
        OnDialogueBoxTriggered?.Invoke(this, new OnDialogueBoxTriggeredEventArgs { showing = true });
        foreach (string sentance in dialogue.Sentance)
        {
            sentences.Enqueue(sentance);
        }

        DisplayNextSentance();
    }

    public void DisplayNextSentance()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        sentences.Clear();
        OnDialogueBoxTriggered?.Invoke(this, new OnDialogueBoxTriggeredEventArgs { showing = false });
        Debug.Log("Dialogue Finished");
    }
}
