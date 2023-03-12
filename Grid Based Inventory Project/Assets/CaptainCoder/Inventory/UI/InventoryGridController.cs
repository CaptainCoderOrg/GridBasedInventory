using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

namespace CaptainCoder.Inventory.UnityEngine
{
    [RequireComponent(typeof(UIDocument))]
    public class InventoryGridController<T> : MonoBehaviour where T : class, IGridableItem
    {
        private GridElement _gridElement;
        private VisualElement _container;
        [field: SerializeField]
        public InventoryGridData<T> InventoryData { get; private set; }
        private readonly Dictionary<T, GridItemElement<T>> _itemLookup = new();
        [field: SerializeField]
        public ItemCursorController<T> Cursor { get; private set; }
        [field: SerializeField]
        private Vector2 _position;
        public Vector2 Position
        {
            get => new(_container.style.left.value.value, _container.style.top.value.value);
            set
            {
                _container.style.left = value.x;
                _container.style.top = value.y;
                _position = value;
            }
        }
        private void Awake()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            _container = root.Q<VisualElement>("Container");
            Position = _position;
            _gridElement = root.Q<GridElement>("GridElement");
            _gridElement.UpdateDimensions(InventoryData.InventoryGrid.GridSize);
            _gridElement.OnClicked += HandleClick;
            _gridElement.OnPointerEntered += (slot) => Cursor.OnPointerEnter(slot, _gridElement);
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
            if (Cursor.Selected == null)
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
            Debug.Assert(Cursor.Selected == null, "HandleSelect should only be invoked when nothing is selected.");
            if (InventoryData.InventoryGrid.TryRemoveItemAt(slot.Position, out T item))
            {
                Cursor.Selected = _itemLookup[item];
                _itemLookup.Remove(item);
                Cursor.Selected.Select(Cursor);
            }
        }

        private void HandleUnSelect(GridSlotElement slot)
        {
            Debug.Assert(Cursor.Selected != null, "HandleUnSelect should only be invoked when something is selected.");
            if (InventoryData.InventoryGrid.TrySetItemAt(slot.Position, Cursor.Selected.Item, out T removed))
            {
                _itemLookup[Cursor.Selected.Item] = Cursor.Selected;
                Cursor.Selected.UnSelect(Cursor);
                Cursor.Selected = null;
                if (removed != null)
                {
                    Cursor.Selected = _itemLookup[removed];
                    Cursor.Selected.Select(Cursor);
                    _itemLookup.Remove(removed);
                }
            }
        }

        private void OnValidate()
        {
            if (_container == null) { return; }
            Position = _position;
        }

    }
}
