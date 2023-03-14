namespace CaptainCoder.Inventory.UnityEngine
{
    [System.Serializable]
    public struct MutableDimensions
    {
        public int Rows;
        public int Cols;
        public MutableDimensions(int rows, int cols) => (Rows, Cols) = (rows, cols);
        public Dimensions Freeze() => new (Rows, Cols);
    }
}