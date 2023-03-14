using UnityEngine;

namespace CaptainCoder.Inventory.UnityEngine
{
    public class InventoryGridData<T> : ScriptableObject, IInventoryGridAdapter<T> where T : class, IInventoryItem
    {
        [SerializeField]
        private MutableDimensions _dimensions = new(1, 1);
        private IInventoryGrid<T> _grid;
        public IInventoryGrid<T> InventoryGrid => _grid ??= new SimpleInventoryGrid<T> { GridSize = _dimensions.Freeze() };
    }
}
