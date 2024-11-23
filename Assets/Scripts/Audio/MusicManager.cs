using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup background;
    [SerializeField] private AudioMixerGroup ambience;

    [SerializeField] private AudioClip backgroundMusic;
    private AudioSource backgroundMusicSource;

    [SerializeField] private AudioClip ambienceMusic;
    private AudioSource ambienceMusicSource;

    [SerializeField] private AudioClip dialogueMusic;
    private AudioSource dialogueMusicSource;

    public static MusicManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (backgroundMusic != null)
        {
            backgroundMusicSource = gameObject.AddComponent<AudioSource>();
            backgroundMusicSource.clip = backgroundMusic;
            backgroundMusicSource.outputAudioMixerGroup = background;
            backgroundMusicSource.loop = true;
            backgroundMusicSource.Play();
        }

        if (ambienceMusic != null)
        {
            ambienceMusicSource = gameObject.AddComponent<AudioSource>();
            ambienceMusicSource.clip = ambienceMusic;
            backgroundMusicSource.outputAudioMixerGroup = ambience;
            ambienceMusicSource.loop = true;
            ambienceMusicSource.Play();
        }
        
        if (dialogueMusic != null)
        {
            dialogueMusicSource = gameObject.AddComponent<AudioSource>();
            dialogueMusicSource.clip = dialogueMusic;
            backgroundMusicSource.outputAudioMixerGroup = background;
            dialogueMusicSource.loop = true;
        }
    }

    public void OverlayDialogueMusic()
    {
        StartCoroutine(FadeMusic(backgroundMusicSource, dialogueMusicSource));
    }

    public void FadeOutDialogueMusic()
    {
        StartCoroutine(FadeMusic(dialogueMusicSource, backgroundMusicSource));
    }

    private IEnumerator FadeMusic(AudioSource currentClip, AudioSource clipToFadeTo)
    {
        float timeToFade = 1f;
        float timeElapsed = 0;

        clipToFadeTo.volume = 0;
        clipToFadeTo.Play();

        while (timeElapsed < timeToFade)
        {
            currentClip.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
            clipToFadeTo.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        currentClip.Stop();
        currentClip.volume = 0;
    }
}
