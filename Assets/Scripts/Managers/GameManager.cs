using UnityEngine;
using System.Collections;
using TwoDBuilder.Level;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance = null;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    // Use this for initialization
    void Awake()
    {
        //Check if instance already exists
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        if (LevelManager.Instance == null)
        {
            MakeLevelManager();
        }

        World level = LevelManager.Instance.MakeNew();
        level.Initialize(10, 10);
        Camera.main.transform.position = new Vector3(level.center.X, level.center.Y, Camera.main.transform.position.z);
    }

    void MakeLevelManager()
    {
        GameObject lm = new GameObject("LevelManager");
        lm.AddComponent<LevelManager>();
        PlaceInWorld(lm, Vector3.zero, Quaternion.identity);
    }

    public GameObject PlaceInWorld(GameObject obj, Vector3 Position, Quaternion Rotation)
    {
        return Instantiate(obj, Position, Rotation) as GameObject;
    }

    void OnDestroy()
    {
        if (this == _instance)
        {
            _instance = null;
        }
    }
}
