using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance { get; private set; }

    public GameObject dialoguePanel;
    public GameObject dialogueImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    [SerializeField] private Queue<string> sentences;

    //Deactivates the ball when dialogue starts and activates it when it ends
    public GameObject ball;

    /// <summary>
    /// Singleton
    /// </summary>
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this);

        sentences = new Queue<string>();

    }

    /// <summary>
    /// Gets all necessary visual parts and adds the onclick event to the dialogue panel
    /// </summary>
    void Start()
    {

        if (dialoguePanel == null) dialoguePanel = GameObject.FindGameObjectWithTag("DialogueBox");
        AddEventToDialoguePanel();

        if (nameText == null) nameText = GameObject.FindGameObjectWithTag("NameTextbox").GetComponent<TextMeshProUGUI>();
        if (dialogueText == null) dialogueText = GameObject.FindGameObjectWithTag("DialogueTextbox").GetComponent<TextMeshProUGUI>();
        dialoguePanel.SetActive(false);

        if (dialogueImage == null) dialogueImage = GameObject.FindGameObjectWithTag("DialogueImage");
        dialogueImage.SetActive(false);


    }

    /// <summary>
    /// Activates all necessary visual parts and starts trhe dialogue. 
    /// Also deactivates the ball if it is in scene
    /// </summary>
    /// <param name="dialogue"></param>
    public void StartDialogue(Dialogue dialogue)
    {
        if (ball != null) ball.SetActive(false);
        if (dialoguePanel != null) dialoguePanel.SetActive(true);
        if (dialogueImage != null) dialogueImage.SetActive(true);
        if (nameText != null) nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    /// <summary>
    /// Displays next sentence when player clicks the dialogue panel
    /// </summary>
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

    /// <summary>
    /// Event to add as an onClick to the dialogue panel
    /// </summary>
    /// <param name="eventData"></param>
    private void DisplayNextSentenceEvent(BaseEventData eventData)
    {
        DisplayNextSentence();
    }

    /// <summary>
    /// Adds the display next sentence method as an event when clicking the dialogue box
    /// Does it like this because if done in the editor, it loses the reference when changing scenes 
    /// </summary>
    void AddEventToDialoguePanel()
    {
        EventTrigger nextEventTrigger = dialoguePanel.AddComponent<EventTrigger>();
        EventTrigger.Entry clickEvent = new EventTrigger.Entry()
        {
            eventID = EventTriggerType.PointerClick
        };
        clickEvent.callback.AddListener(DisplayNextSentenceEvent);
        nextEventTrigger.triggers.Add(clickEvent);

    }

    /// <summary>
    /// Types the sentence with a small delay between each character
    /// </summary>
    /// <param name="sentence"></param>
    /// <returns></returns>
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;

            yield return null; //Waits a frame
        }

    }

    /// <summary>
    /// Ends dialogue.
    /// Deactivates visuals
    /// Activates ball if it exists
    /// </summary>
    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        dialogueImage.SetActive(false);
        if (ball != null) ball.SetActive(true);
        
    }

    /// <summary>
    /// Called when the dialogue is finished, given the ball so the gameplay starts when the dialogue ends 
    /// </summary>
    public void SetObjectActive(GameObject objectToActivate)
    {
        objectToActivate.SetActive(true);
    }

}
