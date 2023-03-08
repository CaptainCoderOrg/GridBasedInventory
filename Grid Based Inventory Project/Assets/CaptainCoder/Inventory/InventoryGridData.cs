using UnityEngine;

namespace CaptainCoder.Inventory.UnityEngine
{
    
    public class InventoryGridData<T> : ScriptableObject, IHasInventoryGrid<T> where T : class, IInventoryItem
    {
        [SerializeField]
        private MutableDimensions _dimensions = new (1,1);

        private IInventoryGrid<T> _grid;
        public IInventoryGrid<T> InventoryGrid => _grid;

        void OnEnable()
        {
            // Null coalescing assignment operator
            _grid ??= new SimpleInventoryGrid<T>(_dimensions.Freeze());
            // if (_grid == null)
            // {
            //     _grid = new SimpleInventoryGrid<ItemData>(_dimensions.Freeze());
            // }
        }
    }
}
