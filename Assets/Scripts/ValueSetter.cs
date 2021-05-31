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
    public GameObject bMIText;

    public int height = 150;
    public int weight = 50;
    public float bMI = 0;

    public void Start()
    {
        GameObject glob = GameObject.Find("GlobalObj");
        int height = glob.GetComponent<GlobalControl>().height;
        int weight = glob.GetComponent<GlobalControl>().weight;
        heightSlider.GetComponent<PinchSlider>().SliderValue = ((float)height-150)/50;
        weightSlider.GetComponent<PinchSlider>().SliderValue = ((float)weight-30)/90;
    }
    public void SetHeight()
    {
        float sliderValue = heightSlider.GetComponent<PinchSlider>().SliderValue;
        int heightToAdd = (int) Math.Round(sliderValue * 50);
        height = 150 +  (heightToAdd);
        heightText.GetComponent<TextMesh>().text = ("Height: " + height +"cm");
        SetBMI();
    }

    public void SetWeight()
    {
        float sliderValue = weightSlider.GetComponent<PinchSlider>().SliderValue;
        int weightToAdd = (int)Math.Round(sliderValue * 90);
        weight = 30 + (weightToAdd);
        weightText.GetComponent<TextMesh>().text = ("Weight: " + weight + "kg");
        SetBMI();
    }

    public void SetBMI()
    {
        float heightAdj = (float)height/100;
        //Debug.Log(heightAdj);
        //Debug.Log(weight);
        //Debug.Log(weight/(heightAdj*heightAdj));
        bMI = ((float)weight/(heightAdj*heightAdj));
        
        bMIText.GetComponent<TextMesh>().text = ("BMI: " + Math.Round(bMI, 1));
    }
}
