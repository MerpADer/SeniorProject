using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetAudio : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;

    private void Start()
    {
        // PlayerPrefs.DeleteAll(); use to test playerprefs

        if (!PlayerPrefs.HasKey("VolumeValue"))
        {
            PlayerPrefs.SetFloat("VolumeValue", 0.5f);
        }

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
