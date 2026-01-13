using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Save to PlayerPrefs
    public void SaveData(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    // Load from PlayerPrefs
    public int LoadData(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    //Check if key exists
    public bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }

    // Don't destroy on load
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}