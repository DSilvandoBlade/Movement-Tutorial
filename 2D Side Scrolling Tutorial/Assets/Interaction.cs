using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    [SerializeField] private SpriteRenderer interactionPopup;
    [SerializeField] private bool canInteract = false;

    [SerializeField] private DialogueClass dialogue;

    [SerializeField] private InputAction interactButton;

    #region Input Action Region

    private void OnEnable()
    {
        interactButton.Enable();
    }

    private void OnDisable()
    {
        interactButton.Disable();
    }

    #endregion

    private void Update()
    {
        if (canInteract && interactButton.triggered)
        {
            Debug.Log("DONE IT");
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canInteract = true;
            interactionPopup.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canInteract = false;
            interactionPopup.enabled = false;
        }
    }
}
