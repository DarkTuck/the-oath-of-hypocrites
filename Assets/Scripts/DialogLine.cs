using UnityEngine;

[CreateAssetMenu(fileName = "DialogLine", menuName = "DialogToolkit/NormalLine")]
public class DialogLine : DialogAbstract
{

    public override string SayLine()
    {
        return text;
    }
    public override string Answer()
    {
        return answerText;
    }
}
