using UnityEngine;
using Ink.Runtime;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] TextAsset inkTextAsset;
    Story _story;
    private int currentChoiceIndex = -1;
    
    private bool dialoguePlaying = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _story= new Story(inkTextAsset.text);
    }
}
