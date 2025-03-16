using UnityEngine;

[CreateAssetMenu(fileName = "DialogBoostedLine", menuName = "Scriptable Objects/DialogBoostedLine")]
public class DialogBoostedLine : DialogAbstract
{
    [SerializeField]private string alternetiveAnswer;
    bool isBoosted;
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
        return isBoosted ? alternetiveAnswer : answerText;
    }
}
