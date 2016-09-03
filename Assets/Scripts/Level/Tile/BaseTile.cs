using System;
using UnityEngine;

namespace TwoDBuilder.Level.Tile
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BaseTile : MonoBehaviour
    {
        public GridPosition Position = new GridPosition(0,0);
        public TileSize Size;// = new TileSize(1,1);

        //public WorldGrid grid;
        public Texture2D TileTexture;

        SpriteRenderer _sr;

        public string tileResourceFile;

        public BaseTile(string tileResourceFile = TileResourceFileNames.DEFAULT_TILE)
        {
            this.tileResourceFile = tileResourceFile;
        }

        public void Start()
        {
            _sr = GetComponent<SpriteRenderer>();

            if (TileTexture == null)
            {
                TileTexture = Resources.Load<Texture2D>(tileResourceFile);

                if (TileTexture == null)
                {
                    Debug.LogError("Default tile sprite not found");
                    Debug.Break();
                }
            }

            float heightPixelsPerUnit = TileTexture.height / Size.Height;
            float widthPixelsPerUnit = TileTexture.width / Size.Width;
            float pixelsPerUnit = heightPixelsPerUnit > widthPixelsPerUnit ? heightPixelsPerUnit : widthPixelsPerUnit;

            _sr.sprite = Sprite.Create(
                TileTexture,
                new Rect(0, 0, TileTexture.width, TileTexture.height),
                Vector2.zero,
                pixelsPerUnit
            );
        }
    }
}
