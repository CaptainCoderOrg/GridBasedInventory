using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CaptainCoder.Inventory.UnityEngine
{
    public class GridSlotElement : VisualElement
    {
        
        public GridSlotElement(int cellSize) : this()
        {
            Init(cellSize);
        }

        public GridSlotElement()
        {
            AddToClassList("grid-slot");
        }

        public int CellSize { get; set; }

        private void Init(int cellSize) {
            CellSize = cellSize;
            style.width = cellSize;
            style.height = cellSize;
        }

        public new class UxmlFactory : UxmlFactory<GridSlotElement, UxmlTraits> { }

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            private UxmlIntAttributeDescription _cellSize = new () { name = "cell-size", defaultValue = 32 };

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var slot = ve as GridSlotElement;
                slot.Init(_cellSize.GetValueFromBag(bag, cc));
            }
        }

    }
}