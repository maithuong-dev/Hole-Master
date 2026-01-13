using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private int score = 0;
    private int bestScore = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        bestScore = PlayerData.Instance.LoadData("BestScore");
        score = PlayerData.Instance.LoadData("CurrentSessionScore"); 
    }

    public void AddScore(int amount)
    {
        score += amount;

        if (score > bestScore)
        {
            bestScore = score;
            PlayerData.Instance.SaveData("BestScore", bestScore);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public int GetBestScore()
    {
        return bestScore;
    }

    public void OnLevelComplete()
    {
        PlayerData.Instance.SaveData("CurrentSessionScore", score);
    }

    public void OnGameOver()
    {
        PlayerData.Instance.SaveData("CurrentSessionScore", 0);
    }
}