using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaptainCoder.Inventory.UnityEngine
{
    public class ItemCursorController<T> : MonoBehaviour where T : class, IGridableItem
    {
        public event System.Action<GridSlotElement, GridElement> OnPointerEntered;
        private GridItemElement<T> _selected = null;
        public GridItemElement<T> Selected 
        {
            get => _selected;
            set => _selected = value;
        }

        public void OnPointerEnter(GridSlotElement slot, GridElement grid) => OnPointerEntered?.Invoke(slot, grid);
    }
}