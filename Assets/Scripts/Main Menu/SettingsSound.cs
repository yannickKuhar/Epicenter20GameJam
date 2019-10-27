using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsSound : MonoBehaviour
{
    public AudioMixer volumeAudio;
    
    void UpdateSoundSettings()
    {
        volumeAudio.SetFloat("Master", this.gameObject.GetComponent<Scrollbar>().value);
    }
}
