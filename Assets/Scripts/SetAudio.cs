using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetAudio : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;

    private void Start()
    {
        LoadValues();
    }

    public void SaveValues()
    {
        float volumeVal = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeVal);

        LoadValues();
    }

    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;

        AudioListener.volume = volumeValue;
    }

}
