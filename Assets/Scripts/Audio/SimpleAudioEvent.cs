using System;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Audio Events/Simple")]
public class SimpleAudioEvent : ScriptableObject
{
    [SerializeField]
    private AudioClip[] clips = new AudioClip[10];
    [SerializeField]
    private RangedFloat volume = new RangedFloat(1, 1);

    internal void Play(object audioSource)
    {
        throw new NotImplementedException();
    }

    [SerializeField]
    [MinMaxRange(0,2f)]
    private RangedFloat pitch = new RangedFloat(1, 1);

    [SerializeField]
    [MinMaxRange(0, 1000f)]
    private RangedFloat distance = new RangedFloat(1, 1000);

    [SerializeField]
    private AudioMixerGroup mixer;

    public void Play(AudioSource source)
    {
        if (mixer != null)
            source.outputAudioMixerGroup = mixer;

        int clipIndex = UnityEngine.Random.Range(0, clips.Length);
        source.clip = clips[clipIndex];

        source.pitch = UnityEngine.Random.Range(pitch.minValue, pitch.maxValue);
        source.volume = UnityEngine.Random.Range(volume.minValue, volume.maxValue);

        source.minDistance = distance.minValue;
        source.maxDistance = distance.maxValue;

        source.Play();
    }
    
}
