using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    private int level = 1;
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void IncreaseLevel()
    {
        level++;
        PlayerData.Instance.SaveData("Level", level);
    }

    public int GetLevel()
    {
        if (PlayerData.Instance.HasKey("Level"))
        {
            int savedLevel = PlayerData.Instance.LoadData("Level");
            if (savedLevel > level)
            {
                level = savedLevel;
            }
            return level;
        }
        else
        {
            return level;
        }
    }
}
