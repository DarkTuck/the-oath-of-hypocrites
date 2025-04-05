using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Prototype/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField] List<GameObject> items;
    public List<GameObject> Items => items;

    public void AddItem(GameObject item)
    {
        items.Add(item);
    }
}
