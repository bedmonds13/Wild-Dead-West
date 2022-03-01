using System;
using System.Collections;
using UnityEngine;

public static class AudioMixer 
{
    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        Debug.Log("Startig fade");
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }

        audioSource.volume = 1;
        audioSource.Stop();
        yield break;
    }
}
