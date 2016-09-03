namespace TwoDBuilder.Level.Tile
{
    /// <summary>
    /// The amount of space a tile takes up in terms of the grid and not in pixels
    /// </summary>
    [System.Serializable]
    public class TileSize
    {
        public int Width = 1;
        public int Height = 1;

        public TileSize(int w, int h)
        {
            Width = w;
            Height = h;
        }
    }
}
