using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    // Here we change the overal volume of the game
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
