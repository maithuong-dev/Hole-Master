using UnityEngine;

public class SmartDetector : MonoBehaviour
{
    public Ball ball; 
    [SerializeField] private AudioSource smashBreakableSource;
    [SerializeField] private AudioSource smashUnbreakableSource;

    private void OnTriggerEnter(Collider other)
    {
        if (!ball.isSmashing){
            ball.Bounce();
            return;
        }

        if (other.CompareTag("Breakable"))
        {
            Debug.Log("Hit Breakable Object!");
            SoundManager.Instance.PlaySFX(smashBreakableSource);
            
            ScoreManager.Instance.AddScore(1);
            
            other.transform.parent.GetComponent<StackController>().ShatterAllParts();
        }
        else if (other.CompareTag("Unbreakable"))
        {
            ScoreManager.Instance.OnGameOver();
            ball.Lose();
            Debug.Log("Hit Unbreakable Object!");
            SoundManager.Instance.PlaySFX(smashUnbreakableSource);
        }
        else if (other.CompareTag("Done") && ball.isWin == false)
        {
            Debug.Log("Level Completed!");
            
            ScoreManager.Instance.OnLevelComplete();
            
            ball.Win();
        }
    }
}