using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CaptainCoder.Inventory.UnityEngine
{
    public class GridSlotElement : VisualElement
    {        
        public GridSlotElement(int cellSize, Core.Position position) : this() => Init(cellSize, position);
        public event System.Action<GridSlotElement> OnPointerEntered;
        public event System.Action<GridSlotElement> OnClicked;

        public GridSlotElement()
        {
            AddToClassList("grid-slot");
            RegisterCallback<PointerEnterEvent>(OnPointerEnter);
            RegisterCallback<PointerDownEvent>(OnPointerDown);
        }

        public int CellSize { get; set; }
        public Core.Position Position { get; private set; }

        private void Init(int cellSize, Core.Position position) {
            CellSize = cellSize;
            style.width = cellSize;
            style.height = cellSize;
            Position = position;
        }

        private void OnPointerEnter(PointerEnterEvent evt) => OnPointerEntered?.Invoke(this);
        private void OnPointerDown(PointerDownEvent evt) => OnClicked?.Invoke(this);

        public new class UxmlFactory : UxmlFactory<GridSlotElement, UxmlTraits> { }

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            private UxmlIntAttributeDescription _cellSize = new () { name = "cell-size", defaultValue = 32 };

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var slot = ve as GridSlotElement;
                slot.Init(_cellSize.GetValueFromBag(bag, cc), slot.Position);
            }
        }
    }
}