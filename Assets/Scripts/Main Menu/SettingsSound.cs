using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsSound : MonoBehaviour
{
    public AudioMixer volumeAudio;
    public Slider volumeSlider;
    
    public void UpdateSoundSettings()
    {
        volumeAudio.SetFloat("Master", -80 + volumeSlider.value * 100);
    }
}
