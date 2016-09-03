using UnityEngine;
using System.Collections;
using TwoDBuilder.Level.Tile;
using TwoDBuilder.Level;

public class GridDrawer : MonoBehaviour
{

    public static Material lineMaterial;
    static void CreateLineMaterial()
    {
        if (!lineMaterial)
        {
            // Unity has a built-in shader that is useful for drawing
            // simple colored things.
            Shader shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader);
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            // Turn on alpha blending
            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            // Turn backface culling off
            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
            // Turn off depth writes
            lineMaterial.SetInt("_ZWrite", 0);
        }
    }

    public Color GridColour = Color.white;

    const float Z_DRAW = -3f;

    public void OnRenderObject()
    {
        CreateLineMaterial();
        lineMaterial.SetPass(0);

        TileSize size = LevelManager.ActiveWorld.GetSize();

        Vector2 origin = LevelManager.ActiveWorld.GetWorldPositionFromGrid(new GridPosition(0,0));
        transform.position = origin;

        GL.PushMatrix();

        GL.MultMatrix(transform.localToWorldMatrix);

        GL.Begin(GL.LINES);

        GL.Color(GridColour);

        for (int x = 0; x < size.Width; x++)
        {
            for (int y = 0; y < size.Height; y++)
            {
                GL.Vertex3(x, y, Z_DRAW);
                GL.Vertex3(x, y+1, Z_DRAW);
                GL.Vertex3(x, y, Z_DRAW);
                GL.Vertex3(x + 1, y, Z_DRAW);
            }
        }

        GL.End();
        GL.PopMatrix();
    }
}
