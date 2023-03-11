using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


namespace CaptainCoder.Inventory.UnityEngine
{
    public class GridElement : VisualElement
    {
        public GridElement()
        {
            AddToClassList("grid");
        }

        public int Rows { get; set; }
        public int Columns { get; set; }
        public int CellSize { get; set; }

        public void UpdateDimensions(Dimensions newSize) => Init(newSize.Rows, newSize.Columns, CellSize);

        private void Init(int rows, int columns, int cellSize)
        {
            Rows = rows;
            Columns = columns;
            CellSize = cellSize;
            Clear();
            for (int r = 0; r < Rows; r++)
            {
                Add(new GridRowElement(columns, cellSize));
            }
        }

        public sealed new class UxmlFactory : UxmlFactory<GridElement, UxmlTraits> { }

        public sealed new class UxmlTraits : VisualElement.UxmlTraits
        {
            UxmlIntAttributeDescription _columns = new () { name = "columns", defaultValue = 10 };
            UxmlIntAttributeDescription _rows = new () { name = "rows", defaultValue = 4 };
            UxmlIntAttributeDescription _cellSize = new () { name = "cell-size", defaultValue = 32 };

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var grid = ve as GridElement;
                int AsInt(UxmlIntAttributeDescription e) => e.GetValueFromBag(bag, cc);
                grid.Init(AsInt(_rows), AsInt(_columns), AsInt(_cellSize));
            }
        }

    }
}
