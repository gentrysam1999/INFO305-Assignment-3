using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WorkoutCalc : MonoBehaviour
{
    public GameObject MainCam;
    public int weight = 60;
    public int height = 172;
    private float startTime = 0.0f;
    public float time;
    private int count = 0;
    public string movement;
    private string prevMovement;
    public float caloriesLost;
    public float caloriesLostSlow;
    public List<float> times;
    public bool isRecord = false;
   


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
            if(CheckRecordTime(movement, time)){
                //Do something to let user know that they have achieved a new record
                Debug.Log("new record!");
            }
            // else{
            //     isRecord = false;
            // }
        }else{
            caloriesLostSlow += calorieCalc(prevMovement, weight, time);
            count = 0;
            if(isRecord){
                Debug.Log("new record: /n" + movement + " " + time);
                isRecord = false;
            }
            //Debug.Log(recordTime(time));
        }
        
        prevMovement = movement;
        
    }

    public bool CheckRecordTime(string activity, float time){
        GameObject globObj = GameObject.Find("GlobalObj");
        if (activity == "Jogging"){
            if(time > globObj.GetComponent<GlobalControl>().runRecord){
                isRecord = true;
                globObj.GetComponent<GlobalControl>().runRecord = time;
            }
        }else if(activity == "Squats"){
            if(time > globObj.GetComponent<GlobalControl>().squatRecord){
                isRecord = true;
                globObj.GetComponent<GlobalControl>().squatRecord = time;
            }
        }else if(activity == "Walking"){
            if(time > globObj.GetComponent<GlobalControl>().walkRecord){
                isRecord = true;
                globObj.GetComponent<GlobalControl>().walkRecord = time;
            }
        }
        else if(activity == "Standing Still"){
            if(time > globObj.GetComponent<GlobalControl>().stillRecord){
                isRecord = true;
                globObj.GetComponent<GlobalControl>().stillRecord = time;
            }
        }
        return isRecord;
    }
    public float recordTime(float time)
    {
        times = new List<float>();
        times.Add(time);

        return times.Max();

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

