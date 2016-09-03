using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using TwoDBuilder.Level.Tile;

namespace TwoDBuilder.Level
{
    public class World
    {
        Grid<BaseTile> BaseLevel = new Grid<BaseTile>(name: "BaseGrid");

        Grid<BaseTile> ItemLevel = new Grid<BaseTile>(
            name: "ItemGrid", 
            depth: 1,
            defaultTileResource: TileResourceFileNames.TRANSPARENT_TILE);

        public GridPosition center = new GridPosition(5, 5);

        public void Initialize(int rows = 10, int columns = 10)
        {
            center = new GridPosition(rows / 2, columns / 2);
            BaseLevel.Initialize(rows, columns);
            ItemLevel.Initialize(rows, columns);
        }

        public GridPosition GetGridPositionFromWorld(Vector2 WorldPosition)
        {
            GridPosition pos = new GridPosition();
            pos.X = Mathf.FloorToInt(WorldPosition.x);
            pos.Y = Mathf.FloorToInt(WorldPosition.y);
            return pos;
        }

        public Vector2 GetWorldPositionFromGrid(GridPosition pos)
        {
            return new Vector2(pos.X, pos.Y);
        }

		public BaseTile PlaceTile (GridPosition atPosition, string tileResource = TileResourceFileNames.DEFAULT_TILE)
        {
			return BaseLevel.PlaceTile<BaseTile>(atPosition, tileResource);
        }

        public TileSize GetSize()
        {
            return BaseLevel.GetSize();
        }
    }
}
