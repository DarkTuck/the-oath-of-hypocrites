using UnityEngine;

[CreateAssetMenu(fileName = "DialogBoosterLine", menuName = "DialogToolkit/TheBoosterLine")]
public class DialogBoosterLine : DialogAbstract
{
    [SerializeField]DialogBoostedLine dialogBoostedLine;
    [SerializeField]int boostValue;
    
    public override string SayLine()
    {
        dialogBoostedLine.BoostLine(boostValue);
        return text;
    }

    public override string Answer()
    {
        return answerText;
    }
}
