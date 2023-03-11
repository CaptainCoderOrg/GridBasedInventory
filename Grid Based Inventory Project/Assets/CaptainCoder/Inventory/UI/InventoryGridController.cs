using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CaptainCoder.Inventory.UnityEngine
{
    [RequireComponent(typeof(UIDocument))]
    public class InventoryGridController<T> : MonoBehaviour where T : class, IInventoryItem
    {
        private GridElement _gridElement;
        [field: SerializeField]
        public InventoryGridData<T> InventoryGrid { get; private set; }
        private void Awake()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            _gridElement = root.Q<GridElement>("GridElement");
            _gridElement.UpdateDimensions(InventoryGrid.InventoryGrid.GridSize);

        }
    }
}
