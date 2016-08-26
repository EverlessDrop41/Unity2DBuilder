using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwoDBuilder.Level.Tile;

namespace TwoDBuilder.Level
{
    public class World
    {
        Grid<BaseTile> BaseLevel = new Grid<BaseTile>(name: "BaseGrid");

        Grid<BaseTile> ItemLevel = new Grid<BaseTile>(
            name: "ItemGrid", 
            depth: 1,
            defaultTileResource: TileResourceFileNames.TransparrentTile);

        public GridPosition center = new GridPosition(5, 5);

        public void Initialize(int rows = 10, int columns = 10)
        {
            center = new GridPosition(rows / 2, columns / 2);
            BaseLevel.Initialize(rows, columns);
            ItemLevel.Initialize(rows, columns);
        }
    }
}
