using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] Slider redSlider;
    [SerializeField] Slider red_WhiteSlider;

    [SerializeField] Slider orangeSlider;
    [SerializeField] Slider orange_WhiteSlider;

    // the whiteSlider starting value when WhiteHealthDecay starts
    private float redStartingWhiteValue;
    private float orangeStartingWhiteValue;

    public void SetMaxHealth(int health, int armor)
    {
        redSlider.maxValue = health;
        redSlider.value = health;

        red_WhiteSlider.maxValue = health;
        red_WhiteSlider.value = health;

        orangeSlider.maxValue = armor;
        orangeSlider.value = armor;

        orange_WhiteSlider.maxValue = armor;
        orange_WhiteSlider.value = armor;
    }

    public void SetHealth(int health, int armor)
    {
        // identifing if the slider val changed
        float startRedSliderVal = redSlider.value;

        redSlider.value = health;
        orangeSlider.value = armor;

        //runs if hp changed
        if (startRedSliderVal != redSlider.value)
        {
            redStartingWhiteValue = red_WhiteSlider.value;
            InvokeRepeating(nameof(redWhiteHealthDecay), 0.3f, .01f);
        }
        //runs if armor changed
        else
        {
            orangeStartingWhiteValue = orange_WhiteSlider.value;
            InvokeRepeating(nameof(orangeWhiteHealthDecay), 0.3f, .01f);
        }
    }

    void redWhiteHealthDecay()
    {
        if (red_WhiteSlider.value <= redSlider.value)
        {
            CancelInvoke();
        }
        float min = redSlider.value;
        float decayVal = (redStartingWhiteValue - min) / 100;
        red_WhiteSlider.value -= decayVal;
    }

    void orangeWhiteHealthDecay()
    {
        if (orange_WhiteSlider.value <= orangeSlider.value)
        {
            CancelInvoke();
        }
        float min = orangeSlider.value;
        float decayVal = (orangeStartingWhiteValue - min) / 100;
        orange_WhiteSlider.value -= decayVal;
    }

}
