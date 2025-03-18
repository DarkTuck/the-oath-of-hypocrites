using UnityEngine;
using System.Threading.Tasks;

public class DialogScript : MonoBehaviour
{
    private int _meter;
    [SerializeField] private int speed;
    private DialogList dialogList;


    async void SayLine(int index)
    {
        try
        {
            DialogAbstract line = dialogList.GetLine(index);
            line.SayLine();
            await Wait();
            _meter+=line.effect;
            line.Answer();
            await Wait();
            dialogList.RemoveLine(line);
        }
        catch
        {
            Debug.LogError("Something went wrong");
        }
    }

    private async Task Wait() {
        await Task.Delay(speed*1000);
    }
}
