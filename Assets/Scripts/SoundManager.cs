using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource bgmSource;

    // Singleton pattern
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // -- Master Volume --
    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    // -- Sound Effects --
    public void PlaySFX(AudioSource source)
    {
        source.PlayOneShot(source.clip);
    }
}
