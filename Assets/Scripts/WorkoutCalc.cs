using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkoutCalc : MonoBehaviour
{
    public GameObject MainCam;
    private int weight = 60;
    private int height = 172;
    private float startTime = 0.0f;
    public float time;
    private int count = 0;
    public string movement;
    private string prevMovement;
    public float caloriesLost;
    public float caloriesLostSlow;


    // Start is called before the first frame update
    void Start()
    {
        prevMovement = MainCam.GetComponent<HoloDisplayMove>().movement;
    }

    // Update is called once per frame
    void Update()
    {
        movement = MainCam.GetComponent<HoloDisplayMove>().movement;
        if (prevMovement == movement){
            if (count == 0){
                time = startTime;
            }else{
                time += Time.deltaTime;
            } 
            caloriesLost += calorieCalc(movement, weight, Time.deltaTime);
            count+=1;
        }else{
            caloriesLostSlow += calorieCalc(prevMovement, weight, time);
            count = 0;
        }
        prevMovement = movement;
        
    }
    public float calorieCalc(string activity, int weight, float time){
        float met = 0.0f;
        if (activity == "Jogging"){
            met = 7.0f;
        } else if (activity == "Walking"){
            met = 3.0f;
        } else if (activity == "Squats"){
            met = 5.0f;
        } else if (activity == "Unknown Activity"){
            met = 5.0f;
        } else{
            met = 1.3f; //Standing Still
        }
        float calories = (time/60) * (met * 3.5f * weight) / 200.0f;
        //Debug.Log(calories);
        return calories;
    }
}

