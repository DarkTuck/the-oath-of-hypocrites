using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "DialogBoostedLine", menuName = "DialogToolkit/BoostedLine")]
public class DialogBoostedLine : DialogAbstract
{
    [SerializeField]private string alternativeAnswer;
    private bool _isBoosted;
    public override string SayLine()
    {
        return text;
    }

    public void BoostLine(int value)
    {
        effect+=value;
    }

    public override string Answer()
    {
        return _isBoosted ? alternativeAnswer : answerText;
    }
}
