using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

namespace CaptainCoder.Inventory.UnityEngine
{
    [RequireComponent(typeof(UIDocument))]
    public class InventoryGridController<T> : MonoBehaviour where T : class, IGridableItem
    {
        private GridElement _gridElement;
        [field: SerializeField]
        public InventoryGridData<T> InventoryData { get; private set; }
        [field: SerializeField]
        public T TestItem;
        [field: SerializeField]
        public T TestItem2;
        [field: SerializeField]
        public T TestItem3;
        [field: SerializeField]
        public T TestItem4;
        [field: SerializeField]
        public T TestItem5;

        private readonly Dictionary<T, GridItemElement<T>> _itemLookup = new();
        private GridItemElement<T> _selected = null;
        private void Awake()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            _gridElement = root.Q<GridElement>("GridElement");
            _gridElement.UpdateDimensions(InventoryData.InventoryGrid.GridSize);
            AddItem((1, 2), TestItem);
            AddItem((0, 0), TestItem2);
            AddItem((1, 4), TestItem3);
            AddItem((1, 6), TestItem4);
            AddItem((1, 8), TestItem5);
            _gridElement.OnClicked += HandleClick;
        }

        public bool AddItem(Core.Position position, T item)
        {
            if (!InventoryData.InventoryGrid.TrySetItemAt(position, item)) { return false; }

            GridItemElement<T> element = new(position, item, _gridElement);
            _gridElement.Add(element);
            _itemLookup[item] = element;
            return true;
        }

        private void HandleClick(GridSlotElement slot)
        {
            if (_selected == null)
            {
                HandleSelect(slot);
            }
            else
            {
                HandleUnSelect(slot);
            }
        }

        private void HandleSelect(GridSlotElement slot)
        {
            Debug.Assert(_selected == null, "HandleSelect should only be invoked when nothing is selected.");
            if (InventoryData.InventoryGrid.TryRemoveItemAt(slot.Position, out T item))
            {
                _selected = _itemLookup[item];
                _selected.Select();
            }
        }

        private void HandleUnSelect(GridSlotElement slot)
        {
            Debug.Assert(_selected != null, "HandleUnSelect should only be invoked when something is selected.");
            if (InventoryData.InventoryGrid.TrySetItemAt(slot.Position, _selected.Item, out T removed))
            {
                _selected.UnSelect();
                _selected = null;
                if (removed != null)
                {
                    _selected = _itemLookup[removed];
                    _selected.Select();
                }
            }
        }

    }
}
