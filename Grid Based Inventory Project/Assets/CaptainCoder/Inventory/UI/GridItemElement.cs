using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CaptainCoder.Inventory.UnityEngine
{
    public class GridItemElement<T> : VisualElement where T : class, IGridableItem
    {
        private bool IsSelected = false;
        private readonly GridElement _parent;
        public GridItemElement(Core.Position position, T item, GridElement parent)
        {
            Item = item;
            _parent = parent;
            pickingMode = PickingMode.Ignore;
            Image img = new()
            {
                image = item.Sprite.texture,
                pickingMode = PickingMode.Ignore
            };
            AddToClassList("item-container");
            style.top = position.Row * parent.CellSize;
            style.left = position.Col * parent.CellSize;
            style.width = item.Size.Columns * parent.CellSize;
            style.height = item.Size.Rows * parent.CellSize;
            Add(img);
        }

        public T Item { get; init; }

        public void Select()
        {
            IsSelected = true;
            _parent.OnPointerEntered += HandleMouseMove;
        } 

        public void UnSelect()
        {
            IsSelected = false;
            _parent.OnPointerEntered -= HandleMouseMove;
        }

        private void HandleMouseMove(GridSlotElement slot)
        {
            if (!IsSelected) { return; }
            style.top = slot.Position.Row * _parent.CellSize;
            style.left = slot.Position.Col * _parent.CellSize;
        }

        // private void HandleClick(GridSlotElement slot)
        // {
        //     if (!IsSelected) { return; }
        //     // TODO: Ensure item can fit here
        //     IsSelected = false;
        //     _parent.OnPointerEntered -= HandleMouseMove;
        //     _parent.OnClicked -= HandleClick;
        // }
    }
}