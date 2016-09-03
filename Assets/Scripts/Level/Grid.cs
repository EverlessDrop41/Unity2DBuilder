using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using TwoDBuilder.Level.Tile;
using System;

namespace TwoDBuilder.Level
{
    public class Grid<DefaultTileType> where DefaultTileType : BaseTile
    {
        List<List<GameObject>> _grid;
        public float depth = 0f;
        public string name = "Grid";
        public string defaultTileResource;

		public Grid(string name = "Grid", float depth = 0f, string defaultTileResource = TileResourceFileNames.DEFAULT_TILE) {
            this.name = name;
            this.depth = depth * -1;
            this.defaultTileResource = defaultTileResource;
        }

        public void Initialize(int rows = 10, int columns = 10)
        {
            System.Diagnostics.Stopwatch generatorTimer = new System.Diagnostics.Stopwatch();
            generatorTimer.Start();
            _grid = new List<List<GameObject>>(rows);
            for (int r = 0; r < rows; r++)
            {
                _grid.Add(new List<GameObject>(columns));
                for (int c = 0; c < columns; c++)
                {
                    GameObject go = new GameObject(string.Format("{0}.Tile: {1}:{2}", name, r, c));
                    DefaultTileType tile = go.AddComponent<DefaultTileType>();
                    tile.tileResourceFile = defaultTileResource;
                    tile.Size = new TileSize(1, 1);
                    tile.Position = new GridPosition(r, c);
                    go.transform.position = new Vector3(r, c, depth);
                    go.transform.parent = LevelManager.Instance.transform;
                    _grid[r].Add(go);
                }
            }
            generatorTimer.Stop();
            Debug.LogFormat("Grid Creation Time: {0} seconds", generatorTimer.Elapsed.TotalSeconds);
        }

		public TileType PlaceTile<TileType>(GridPosition atPosition, string tileSpriteName = TileResourceFileNames.DEFAULT_TILE) where TileType : BaseTile
        {
            var oldTile = _grid[atPosition.X][atPosition.Y];
			string oldTileName = oldTile.name;
            
			UnityEngine.Object.Destroy(oldTile);

			GameObject obj = new GameObject(oldTileName);
			TileType t = obj.AddComponent<TileType>();
			t.tileResourceFile = tileSpriteName;
			t.Position = atPosition;
			t.Size = new TileSize (1, 1);
			obj.transform.position = new Vector3 (atPosition.X, atPosition.Y, depth);
			obj.transform.parent = LevelManager.Instance.transform;
            _grid[atPosition.X][atPosition.Y] = obj;

			return t;
        }

        public GameObject GetGameObjectAtPoint(GridPosition position)
        {
            return _grid[position.X][position.Y];
        }

        public Tile GetTile<Tile>(GridPosition position) where Tile : BaseTile
        {
            
            //TODO: Add checks for safer usage
            return _grid[position.X][position.Y].GetComponent<Tile>();
        }

        public TileSize GetSize()
        {
            int width = _grid.Count;
            int height = _grid[0].Count;
            return new TileSize(width, height);
        }
    }
}
