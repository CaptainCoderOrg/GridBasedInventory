using UnityEngine.UIElements;
using UnityEngine;

namespace CaptainCoder.Inventory.UnityEngine
{
    public class GridItemElement<T> : VisualElement where T : class, IGridableItem
    {
        private static int s_SelectedOffset = 3;
        private bool IsSelected = false;

        public GridItemElement(Core.Position position, T item, GridElement parent)
        {
            Item = item;
            Parent = parent;
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

        public GridElement Parent { get; set; }
        public T Item { get; init; }

        public void Select(ItemCursorController<T> controller)
        {
            IsSelected = true;
            BringToFront();
            controller.OnPointerEntered += HandleMouseMove;
            style.top = style.top.value.value + s_SelectedOffset;
            style.left = style.left.value.value + s_SelectedOffset;

        }

        public void UnSelect(ItemCursorController<T> controller)
        {
            IsSelected = false;
            controller.OnPointerEntered -= HandleMouseMove;
            style.top = style.top.value.value - s_SelectedOffset;
            style.left = style.left.value.value - s_SelectedOffset;
        }

        private void HandleMouseMove(GridSlotElement slot, GridElement grid)
        {
            if (!IsSelected) { return; }
            if (Parent != grid)
            {
                Parent?.Remove(this);
                grid.Add(this);
                Parent = grid;
            }
            style.top = slot.Position.Row * Parent.CellSize + s_SelectedOffset;
            style.left = slot.Position.Col * Parent.CellSize + s_SelectedOffset;
        }
    }
}