using CaptainCoder.Inventory.UnityEngine;
using UnityEngine;

public class DemoController : MonoBehaviour
{
    [field: SerializeField]
    public ItemData TestItem { get; private set; }
    [field: SerializeField]
    public ItemData TestItem2 { get; private set; }
    [field: SerializeField]
    public ItemData TestItem3 { get; private set; }
    [field: SerializeField]
    public ItemData TestItem4 { get; private set; }
    [field: SerializeField]
    public ItemData TestItem5 { get; private set; }
    [field: SerializeField]
    public InventoryGridController Inventory { get; private set; }

    void Start()
    {
        Inventory.AddItem((1, 2), TestItem);
        Inventory.AddItem((0, 0), TestItem2);
        Inventory.AddItem((1, 4), TestItem3);
        Inventory.AddItem((1, 6), TestItem4);
        Inventory.AddItem((1, 8), TestItem5);
    }
}