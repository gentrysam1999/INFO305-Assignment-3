﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    // Start is called before the first frame update
    public int height = 172;
    public int weight = 60;
    public float runRecord = 39.1276538f;
    public float runSpeedRecord = 0.0f; // meters per second
    public float runDistanceRecord = 0.0f; // meters
    public float squatRecord = 30.0f;
    public float squatMaxRecord = 0.0f; // amount of squats
    public float walkRecord = 10.0f;
    public float stillRecord = 10.0f;
    public string gender;
    public int age;
    public float time;
    public GameObject settingsObj;
    public GameObject menuObj;
    public GameObject homeObj;
    public GameObject navObj;
    public GameObject statsObj;
    public GameObject openWorkout;
    public GameObject schedWorkout;
    public GameObject stopButton;
    public GameObject startButton;
  
    void Awake(){
        loadApp();

        homeObj.SetActive(true);
        settingsObj.SetActive(true);
        menuObj.SetActive(false);
        navObj.SetActive(false);
        statsObj.SetActive(false);
        openWorkout.SetActive(false);
        schedWorkout.SetActive(false);
        
    }
    public void saveApp(){
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if(File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        GameData data = new GameData(height, weight, runRecord, runSpeedRecord, runDistanceRecord, squatRecord, squatMaxRecord, walkRecord, stillRecord);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }
    public void loadApp(){
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;
 
        if(File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            //Debug.LogError("File not found");
            saveApp();
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData) bf.Deserialize(file);
        file.Close();

        height = data.height;
        weight = data.weight;
        runRecord = data.runRecord;
        runSpeedRecord = data.runSpeedRecord;
        runDistanceRecord = data.runDistanceRecord;
        squatRecord = data.squatRecord;
        squatMaxRecord = data.squatMaxRecord;
        walkRecord = data.walkRecord;
        stillRecord = data.stillRecord;

        Debug.Log(data.height);
        Debug.Log(data.weight);
        Debug.Log(data.runRecord);
        Debug.Log(data.runSpeedRecord);
        Debug.Log(data.runDistanceRecord);
        Debug.Log(data.squatRecord);
        Debug.Log(data.squatMaxRecord);
        Debug.Log(data.walkRecord);
        Debug.Log(data.stillRecord);
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
    public void openStats(){
        if(statsObj.activeSelf){
            statsObj.SetActive(false);
        }else{
            statsObj.SetActive(true);
        }
    }

    public void startOpenWorkout(){
        openWorkout.GetComponent<WorkoutCalc>().height = height;
        openWorkout.GetComponent<WorkoutCalc>().weight = weight;
        homeObj.SetActive(false);
        openWorkout.SetActive(true);
        navObj.SetActive(true);
        stopButton.SetActive(true);
        startButton.SetActive(false);
    }
    public void stopOpenWorkout(){
        //just temp for now
        openWorkout.SetActive(false);
        schedWorkout.SetActive(false);
        stopButton.SetActive(false);
        startButton.SetActive(true);
    }
    public void startSchedWorkout(){
        schedWorkout.GetComponent<WorkoutCalc>().height = height;
        schedWorkout.GetComponent<WorkoutCalc>().weight = weight;
        homeObj.SetActive(false);
        schedWorkout.SetActive(true);
        navObj.SetActive(true);
    }



}
