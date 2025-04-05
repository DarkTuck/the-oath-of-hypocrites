using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using Unity.Multiplayer.Center.Common;
using UnityEngine.InputSystem;

public class InkDialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogPanel;
    [SerializeField] TextMeshProUGUI dialogText;
    [SerializeField] GameObject[] dialogButton;
    [SerializeField] TextMeshProUGUI[] dialogButtonText;
    private static InkDialogManager instance;
    private Story currentStory;
    public bool dialogOpen { get; private set; } = false;
    Actions actions;

    private void Awake()
    {
        actions = new Actions();
        if (instance == null)
        {
            instance = this;    
        }
    }

    void Start()
    {
        dialogPanel.SetActive(false);
    }

    public static void OpenDialog(TextAsset story)
    {
        instance.EnterDialog(story);
    }

    private void EnterDialog(TextAsset inkText)
    {
        actions.Player.Interact.Enable();
        actions.Player.Interact.performed += InputContinueStory;
        currentStory = new Story(inkText.text);
        dialogOpen = true;
        dialogPanel.SetActive(true);
        ContinueStory();

    }

    public static void ChoiceWasMade(int choice)
    {
        instance.currentStory.ChooseChoiceIndex(choice);
        instance.ContinueStory();
    }
    private void ContinueStory()
    {     
        if (currentStory.canContinue)
        {
            dialogText.text=currentStory.Continue();
            DisplayChoice();
        }
        else
        {
            ExitDialogMode();
        }
    }

    private void InputContinueStory(InputAction.CallbackContext context)
    {
        ContinueStory();
    }

    void DisplayChoice()
    {
        List<Choice> curentChoice = currentStory.currentChoices;
        if (curentChoice.Count > dialogButton.Length)
        {
            Debug.LogError("Too many choices");
        }

        for (int i = 0; i <= curentChoice.Count-1; i++)
        {
            dialogButton[i].SetActive(true);
            dialogButtonText[i].text = curentChoice[i].text;

        }

        for (int i = dialogButton.Length-1; i>=curentChoice.Count;i-- )
        {
            dialogButton[i].SetActive(false);
            dialogButtonText[i].text = "";
        }
    }

    void ExitDialogMode()
    {
        dialogPanel.SetActive(false);
        dialogOpen = false;
        dialogText.text = "";
        actions.Player.Interact.Disable();
        actions.Player.Interact.performed -= InputContinueStory;
    }
}