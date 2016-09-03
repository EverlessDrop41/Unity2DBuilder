using UnityEngine;
using System.Collections;
using System.Linq;
using TwoDBuilder.Level;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{

    private static LevelManager _instance = null;

    public static LevelManager Instance
    {
        get { return _instance; }
    }

    public static World ActiveWorld
    {
        get { return _instance.activeWorld; }
    }

    World activeWorld;

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
    }

    public World MakeNew()
    {
        activeWorld = new World();
        return activeWorld;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(activeWorld.GetGridPositionFromWorld(mouseWorldPos));
        }
    }

    void OnDestroy()
    {
        if (this == _instance)
        {
            _instance = null;
        }
    }
}
