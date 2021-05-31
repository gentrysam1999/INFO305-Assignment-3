using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    // Start is called before the first frame update
    public int height;
    public int weight;
    public string gender;
    public int age;
    public float time;
    public GameObject settingsObj;
    public GameObject menuObj;
    public GameObject homeObj;
    public GameObject navObj;
    public GameObject openWorkout;
    public GameObject schedWorkout;
  
    void Start(){
        homeObj.SetActive(true);
        settingsObj.SetActive(true);
        menuObj.SetActive(false);
        navObj.SetActive(false);
        openWorkout.SetActive(false);
        schedWorkout.SetActive(false);
        
    }

    public void saveSettings(){
        //GameObject settingsObj = GameObject.Find("SetValues");
        height = settingsObj.GetComponent<ValueSetter>().height;
        weight = settingsObj.GetComponent<ValueSetter>().weight;
        settingsObj.SetActive(false);
        menuObj.SetActive(true);
    }
    public void openSettings(){
        //GameObject settingsObj = GameObject.Find("SetValues");
        menuObj.SetActive(false);
        settingsObj.SetActive(true);
    }

    public void openHome(){
        homeObj.SetActive(true);
        navObj.SetActive(false);
    }

    public void startOpenWorkout(){
        openWorkout.GetComponent<WorkoutCalc>().height = height;
        openWorkout.GetComponent<WorkoutCalc>().weight = weight;
        homeObj.SetActive(false);
        openWorkout.SetActive(true);
        navObj.SetActive(true);
    }
    public void stopOpenWorkout(){
        //just temp for now
        openWorkout.SetActive(false);
        schedWorkout.SetActive(false);
    }
    public void startSchedWorkout(){
        schedWorkout.GetComponent<WorkoutCalc>().height = height;
        schedWorkout.GetComponent<WorkoutCalc>().weight = weight;
        homeObj.SetActive(false);
        schedWorkout.SetActive(true);
        navObj.SetActive(true);
    }



}
