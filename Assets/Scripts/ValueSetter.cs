using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class ValueSetter : MonoBehaviour
{
    public GameObject heightText;
    public GameObject heightSlider;
    public int height = 150;
    public int weight = 50;

    public void SetHeight()
    {
        float sliderValue = heightSlider.GetComponent<PinchSlider>().SliderValue;

    }

    public void SetWeight()
    {
        
    }
}
