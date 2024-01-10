using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    public static GameObject soundGameObject;
    public static AudioSource audioSource;
    public enum Sound
    {
        TutorialText_1, TutorialText_2, TutorialText_3, TutorialText_4, Mean1, Mean2, Mean3, Mean4, Mean5, Mean6, Mean7, Mean8, Mean9, Median1, Median2, Median3, Median4, Median5, Median6, Median7, Median8, Median9,
        Mode1, Mode2, Mode3, Mode4, Mode5, Mode6, Mode7, Mode8, Mode9, Variability1, Variability2, Variability3, Variability4, Variability5, Variability6, Variability7, Variability8, Variability9
    }

    public static void PlaySound(Sound sound)
    {        
        if (soundGameObject == null || audioSource == null)
        {
            soundGameObject = new GameObject("Sound");
            audioSource = soundGameObject.AddComponent<AudioSource>();
        }
        if (audioSource.isPlaying)
            audioSource.Stop();
        audioSource.PlayOneShot(GetAudioClip(sound), 1);
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not Found!");
        return null;
    }
}
