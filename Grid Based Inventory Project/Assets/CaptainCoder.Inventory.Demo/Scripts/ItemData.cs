using UnityEngine;
using CaptainCoder.Inventory;
using CaptainCoder.Inventory.UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 0)]
public class ItemData : ScriptableObject, IGridableItem
{
    [field: SerializeField]
    public string Name { get; private set; }
    [SerializeField]
    private MutableDimensions _size = new(1, 1);
    [field: SerializeField]
    public Sprite Sprite { get; private set; }
    
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
