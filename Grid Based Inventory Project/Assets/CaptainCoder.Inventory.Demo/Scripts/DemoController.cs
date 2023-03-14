using CaptainCoder.Inventory.UnityEngine;
using UnityEngine;

public class DemoController : MonoBehaviour
{
    [field: SerializeField]
    public ItemData Belt { get; private set; }
    [field: SerializeField]
    public ItemData Dagger { get; private set; }
    [field: SerializeField]
    public ItemData LeatherArmor { get; private set; }
    [field: SerializeField]
    public ItemData Potion { get; private set; }
    [field: SerializeField]
    public ItemData Shield { get; private set; }
    [field: SerializeField]
    public GameInventoryController TargetInventory { get; private set; }

    void Start()
    {
        TargetInventory.AddItem((1, 2), Belt);
        TargetInventory.AddItem((0, 0), Dagger);
        TargetInventory.AddItem((1, 4), LeatherArmor);
        TargetInventory.AddItem((1, 6), Potion);
        TargetInventory.AddItem((1, 8), Shield);
    }
}