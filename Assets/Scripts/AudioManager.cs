using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField]
    private AudioClip mainBGM;
    [SerializeField]
    private float fadeOutSpeed;

    private AudioSource audioSouce;

    private void Awake()
    {
        audioSouce = GetComponentInChildren<AudioSource>();
        if (AudioManager.Instance == null)
            Instance = this;
    }
    private void Start()
    {
        if (audioSouce.clip == null)
        {
            audioSouce.clip = mainBGM;
        }
    }
    private void Update()
    {
        if (!audioSouce.isPlaying )
        {
            ChangeBGM(mainBGM);
            audioSouce.loop = true;
        }
    }
    public void ChangeBGM(AudioClip music)
    {
        audioSouce.clip = music;
        audioSouce.Play();
        audioSouce.loop = false;
    }

    public void EndMusic()
    {
       StartCoroutine( AudioMixer.StartFade(audioSouce, fadeOutSpeed, 0f));
    }



}
