using UnityEngine;
using System.Collections;
using TwoDBuilder.Level;

public class LevelManager : MonoBehaviour {

    private static LevelManager _instance = null;

    public static LevelManager Instance
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
    }

    public World MakeNew()
    {
        return new World();
    }

    void OnDestroy()
    {
        if (this == _instance)
        {
            _instance = null;
        }
    }
}
