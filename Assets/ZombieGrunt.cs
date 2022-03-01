using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGrunt : MonoBehaviour
{
    [SerializeField]
    private SimpleAudioEvent audioEvent;
    private AudioSource audioSource;

    [SerializeField]
    private float soundDelayMin = 2f;

    [SerializeField]
    private float soundDelayMax = 2f;

    private float soundDelay;
    private float soundTimer;

    private bool CanGrunt { get { return soundTimer > soundDelay; } }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        soundTimer += Time.deltaTime;
        if (CanGrunt)
            PlayRandomZombieSound();
    }


    private void PlayRandomZombieSound()
    {

        soundTimer = 0;
        soundDelay = Random.Range(soundDelayMin, soundDelayMax);
        audioEvent.Play(audioSource);

    }
}
