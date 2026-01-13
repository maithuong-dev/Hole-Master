using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;
    public GameObject VolumeButtonOn;
    public GameObject VolumeButtonOff;
    public GameObject WinPanel;
    public GameObject LosePanel;
    public TextMeshProUGUI LevelText2;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI BestScoreText;
    public TextMeshProUGUI CurrentScoreText;
    public TextMeshProUGUI ScoreText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void Update()
    {
        UpdateScore();
        UpdateLevelText();
    }

    public void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void TurnVolumeOn()
    {
        VolumeButtonOn.SetActive(true);
        VolumeButtonOff.SetActive(false);
        SoundManager.Instance.SetMasterVolume(1f);
    }

    public void TurnVolumeOff()
    {
        VolumeButtonOn.SetActive(false);
        VolumeButtonOff.SetActive(true);
        SoundManager.Instance.SetMasterVolume(0f);
    }

    public void ShowWinPanel()
    {
        if (LevelText != null)
        {
            LevelText.text = "Level " + LevelManager.Instance.GetLevel().ToString();
        }

        WinPanel.SetActive(true);
    }

    public void ShowLosePanel()
    {
        if (ScoreText != null)
        {
            ScoreText.text = CurrentScoreText.text;
        }
        if (BestScoreText != null)
        {
            BestScoreText.text = ScoreManager.Instance.GetBestScore().ToString();
        }

        LosePanel.SetActive(true);
    }

    public void UpdateScore()
    {
        if (CurrentScoreText != null)
        {
            CurrentScoreText.text = ScoreManager.Instance.GetScore().ToString();
        }
    }

    public void UpdateLevelText()
    {
        if (LevelText2 != null)
        {
            LevelText2.text = "Level " + LevelManager.Instance.GetLevel().ToString();
        }
    }
}
