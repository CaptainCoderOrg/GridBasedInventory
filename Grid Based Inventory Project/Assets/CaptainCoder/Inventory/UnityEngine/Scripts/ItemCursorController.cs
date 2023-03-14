using UnityEngine;
using UnityEngine.UIElements;

namespace CaptainCoder.Inventory.UnityEngine
{
    public class GridCursorController<T> : MonoBehaviour where T : class, IGridableItem
    {
        public event System.Action<GridSlotElement, GridElement> OnPointerEntered;
        private VisualElement _container;
        [field: SerializeField]
        public UIDocument TopLayer { get; private set; }
        [field: SerializeField]
        public UIDocument BottomLayer { get; private set; }
        private GridItemElement<T> _selected = null;
        public GridItemElement<T> Selected { get => _selected; set => _selected = value; }

        public void OnPointerEnter(GridSlotElement slot, GridElement grid) => OnPointerEntered?.Invoke(slot, grid);
        private void Awake()
        {
            BottomLayer.rootVisualElement.RegisterCallback<PointerMoveEvent>(OnPointerMove);
            _container = TopLayer.rootVisualElement.Q<VisualElement>("Container");
            Debug.Assert(BottomLayer != null, "BottomLayer in Grid Cursor Controller must be set.");
            Debug.Assert(TopLayer != null, "TopLayer in Grid Cursor Controller must be set.");
        }

        private void OnPointerMove(PointerMoveEvent evt)
        {
            if (_selected == null) { return; }
            _selected.Parent = null;
            _container.Add(_selected);
            _selected.style.left = evt.position.x;
            _selected.style.top = evt.position.y;
        }
    }
}