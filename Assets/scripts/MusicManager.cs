using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip backgroundMusic;

    [Header("Volume")]
    public float menuVolume = 0.5f;
    public float gameVolume = 0.2f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.volume = menuVolume;
            audioSource.Play();
        }
    }

    public void SetMenuVolume()
    {
        if (audioSource != null)
            audioSource.volume = menuVolume;
    }

    public void SetGameVolume()
    {
        if (audioSource != null)
            audioSource.volume = gameVolume;
    }
}