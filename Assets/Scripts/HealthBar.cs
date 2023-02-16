using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] Slider redSlider;
    [SerializeField] Slider red_WhiteSlider;

    // the whiteSlider starting value when WhiteHealthDecay starts
    private float redStartingWhiteValue;

    public void SetMaxHealth(int health, int armor)
    {
        redSlider.maxValue = health;
        redSlider.value = health;

        red_WhiteSlider.maxValue = health;
        red_WhiteSlider.value = health;
    }

    public void SetHealth(int health)
    {
        // identifing if the slider val changed
        float startRedSliderVal = redSlider.value;

        redSlider.value = health;

        //runs if hp changed
        if (startRedSliderVal != redSlider.value)
        {
            redStartingWhiteValue = red_WhiteSlider.value;
            InvokeRepeating(nameof(redWhiteHealthDecay), 0.3f, .01f);
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

}
