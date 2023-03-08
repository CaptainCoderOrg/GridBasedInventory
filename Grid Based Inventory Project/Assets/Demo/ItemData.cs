using UnityEngine;
using CaptainCoder.Inventory;
using CaptainCoder.Inventory.UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 0)]
public class ItemData : ScriptableObject, IInventoryItem
{
    [SerializeField]
    private MutableDimensions _size = new(1, 1);
    public Dimensions Size => new(_size.Rows, _size.Cols);
    void OnValidate()
    {
        if (_size.Rows < 1)
        {
            _size.Rows = 1;
            Debug.LogError("Rows must be positive.");
        }
        if (_size.Cols < 1)
        {
            _size.Cols = 1;
            Debug.LogError("Cols must be positive");
        }
    }
}
