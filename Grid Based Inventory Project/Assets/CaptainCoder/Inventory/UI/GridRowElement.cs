using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CaptainCoder.Inventory.UnityEngine
{
    public class GridRowElement : VisualElement
    {
        public GridRowElement(int columns, int cellSize) : this() => Init(columns, cellSize);
        
        public GridRowElement()
        {
            AddToClassList("grid-row");
        }

        public int Columns { get; set; }
        public int CellSize { get; set; }

        private void Init(int columns, int cellSize)
        {
            CellSize = cellSize;
            Columns = columns;
            // TODO: Consider when Init is being called?
            Clear();
            for (int i = 0; i < Columns; i++)
            {
                Add(new GridSlotElement(cellSize));
            }
        }


        public new class UxmlFactory : UxmlFactory<GridRowElement, UxmlTraits> { }

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            private UxmlIntAttributeDescription _columns = new() { name = "columns", defaultValue = 10 };
            private UxmlIntAttributeDescription _cellSize = new() { name = "cell-size", defaultValue = 32 };

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var slot = ve as GridRowElement;
                slot.Init(_columns.GetValueFromBag(bag, cc), _cellSize.GetValueFromBag(bag, cc));
            }
        }

    }
}