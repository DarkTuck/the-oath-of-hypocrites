using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using NaughtyAttributes;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class DisplayImage : MonoBehaviour
{
    [SerializeField] GameObject displayImage;
    [SerializeField] TextMeshProUGUI displayText;
    [SerializeField] string text;
    [SerializeField] bool showNext;
    [SerializeField][ShowIf("showNext")] GameObject secondImage;
    [SerializeField]UnityEvent onPress;
    Actions actions;

    async Task GenerateActions()
    {
        actions = new Actions();
    }
    public async void ShowImage()
    {
        if (displayImage != null)
        {
            displayImage.SetActive(true);
        }
        if (displayText != null)
        {
            displayText.text = text;
            displayText.gameObject.SetActive(true);
        }
        await GenerateActions();
        EnableInput();
    }

    void EnableInput()
    {
        actions.Player.Interact.Enable();
        actions.Player.Interact.performed += HideImageInput;
    }

    void DisableInput()
    {
        actions.Player.Interact.Disable();
        actions.Player.Interact.performed -= HideImageInput;
    }

    void HideImageInput(InputAction.CallbackContext context)
    {
        HideImage();
    }
   public void HideImage()
    {
        DisableInput();
        if (displayImage != null)
        {
            displayImage.SetActive(false);
        }
        if (displayText != null)
        {
            displayText.gameObject.SetActive(false);
        }
        onPress.Invoke();
        actions.Player.Interact.Disable();
        actions.Player.Interact.performed -= HideImageInput;
        
        if(showNext) secondImage.SetActive(true);
        
    }
    
}
