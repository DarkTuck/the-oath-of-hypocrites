using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogList", menuName = "Scriptable Objects/DialogList")]
public class DialogList : ScriptableObject
{
    [SerializeField]private List<DialogAbstract> lines;

    public void AddLine(DialogAbstract dialog)
    {
        lines.Add(dialog);
    }

    public void RemoveLine(DialogAbstract dialog)
    {
        lines.Remove(dialog);
    }
    public DialogAbstract GetLine(int index)
    {
        return lines[index];
    }
}
