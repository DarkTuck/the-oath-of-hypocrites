using UnityEngine;

public abstract class DialogAbstract : ScriptableObject
{
    public abstract string SayLine();
    public abstract string Answer();
    public int effect;
    [SerializeField]private protected string text,answerText;

    public void AddLine()
    {
        Debug.Log("Add Line");
    }
}