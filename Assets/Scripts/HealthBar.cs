using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] Slider redSlider;
    [SerializeField] Slider whiteSlider;

    // the whiteSlider starting value when WhiteHealthDecay starts
    private float startingWhiteValue;

    public void SetMaxHealth(int health)
    {
        redSlider.maxValue = health;
        redSlider.value = health;
        whiteSlider.maxValue = health;
        whiteSlider.value = health;
    }

    public void SetHealth(int health)
    {
        redSlider.value = health;
        startingWhiteValue = whiteSlider.value;
        InvokeRepeating(nameof(WhiteHealthDecay), 0.3f, .01f);
    }

    void WhiteHealthDecay()
    {
        if (whiteSlider.value <= redSlider.value)
        {
            CancelInvoke();
        }
        float min = redSlider.value;
        float decayVal = (startingWhiteValue - min) / 100;
        whiteSlider.value -= decayVal;
    }

}
