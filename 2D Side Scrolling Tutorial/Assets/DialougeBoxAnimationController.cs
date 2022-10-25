using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeBoxAnimationController : MonoBehaviour
{
    private Animator dialogueBoxAnim;

    private void Start()
    {
        dialogueBoxAnim = GetComponent<Animator>();
        GetComponent<DialogueManager>().OnDialogueBoxTriggered += OnDialogueTriggered;
    }

    private void OnDialogueTriggered(object sender, DialogueManager.OnDialogueBoxTriggeredEventArgs e)
    {
        dialogueBoxAnim.SetBool("Dialogue", e.showing);
    }
}
