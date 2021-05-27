using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using System;

public class ValueSetter : MonoBehaviour
{
    public GameObject heightText;
    public GameObject heightSlider;
    public GameObject weightText;
    public GameObject weightSlider;

    public int height = 150;
    public int weight = 50;

    public void SetHeight()
    {
        float sliderValue = heightSlider.GetComponent<PinchSlider>().SliderValue;
        int heightToAdd = (int) Math.Round(sliderValue * 50);
        height = 150 +  (heightToAdd);
        heightText.GetComponent<TextMesh>().text = ("Height: " + height +"cm");

    }

    public void SetWeight()
    {
        float sliderValue = weightSlider.GetComponent<PinchSlider>().SliderValue;
        int weightToAdd = (int)Math.Round(sliderValue * 50);
        weight = 50 + (weightToAdd);
        weightText.GetComponent<TextMesh>().text = ("Weight: " + weight + "kg");
    }
}
