using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CaptainCoder.Inventory.UnityEngine
{
    public class GridRowElement : VisualElement
    {
        public GridRowElement(int row, int columns, int cellSize) : this() => Init(row, columns, cellSize);
        public event System.Action<GridSlotElement> OnPointerEntered;
        public event System.Action<GridSlotElement> OnClicked;
        
        public GridRowElement()
        {
            AddToClassList("grid-row");
        }

        public int Columns { get; set; }
        public int CellSize { get; set; }
        public int Row { get; private set; }

        private void Init(int row, int columns, int cellSize)
        {
            CellSize = cellSize;
            Columns = columns;
            Row = row;
            // TODO: Consider when Init is being called?
            Clear();
            for (int col = 0; col < Columns; col++)
            {
                GridSlotElement slot = new GridSlotElement(cellSize, new Core.Position(row, col));
                Add(slot);
                slot.OnPointerEntered += (slot) => OnPointerEntered?.Invoke(slot);
                slot.OnClicked += (slot) => OnClicked?.Invoke(slot);
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
                var row = ve as GridRowElement;
                row.Init(row.Row, _columns.GetValueFromBag(bag, cc), _cellSize.GetValueFromBag(bag, cc));
            }
        }

    }
}