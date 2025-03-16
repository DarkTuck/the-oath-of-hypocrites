using System;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class DialogScript : MonoBehaviour
{
    private int _meter;
    [SerializeField] private int speed;
    private List<DialogAbstract> _lines;
    public void AddLine(DialogAbstract dialog)
    {
        _lines.Add(dialog);
    }

    async void SayLine(int index)
    {
        try
        {
            _lines[index].SayLine();
            await Wait();
            _meter+=_lines[index].effect;
            _lines[index].Answer();
            await Wait();
        }
        catch (Exception e)
        {
            Debug.LogError("Something went wrong");
        }
    }

    private async Task Wait()
    {
        await Task.Delay(speed*1000);
    }
}
