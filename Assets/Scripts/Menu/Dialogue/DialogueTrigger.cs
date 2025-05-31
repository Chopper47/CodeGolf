using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] bool triggerOnLoad;
    public Dialogue dialogue;

    private void Start()
    {
        if (triggerOnLoad) TriggerDialogue();
    }

    /// <summary>
    /// Triggers the dialogue. If you're in a level (ball is in scene), it deactivates it so the gameplay only works after dialogue ends
    /// </summary>
    public void TriggerDialogue()
    {
        if (FindObjectOfType<DialogueManager>() != null)
        {
            DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();

            if (FindObjectOfType<BallMovement>() != null)
            {
                BallMovement ball = FindObjectOfType<BallMovement>();
                dialogueManager.ball = ball.gameObject;
            }

            dialogueManager.StartDialogue(dialogue);
        }
    }
}
