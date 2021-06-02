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
    public float totalTime;
    private int count = 0;
    public string movement;
    public float speed;
    public float squats;
    public float distance;
    private string prevMovement;
    public float caloriesLost;
    public float caloriesLostSlow;
    public List<float> times;
    public bool isTimeRecord = false;
    public bool isAmountRecord = false;
    public bool isDistanceRecord = false;
    public GameObject timeText;
    public GameObject calorieText;
    public GameObject workoutTimeText;
    public GameObject headsetTextObj;
    private string headsetText;

   


    // Start is called before the first frame update
    void Start()
    {
        prevMovement = MainCam.GetComponent<MoveThreshCheck>().moveString;
        totalTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        headsetText = "";
        if(this.gameObject.activeSelf){
            totalTime += Time.deltaTime;
        }else{
            totalTime = 0.0f;
        }
        
        movement = MainCam.GetComponent<MoveThreshCheck>().moveString;
        speed = 40 * MainCam.GetComponent<MoveThreshCheck>().zPos; //Zpos is forward distance in 0.025 secs, 0.025*40 = 1 second
        squats = MainCam.GetComponent<MoveThreshCheck>().squatCount;
        if (prevMovement == movement){
            if (count == 0){
                time = startTime;
            }else{
                time += Time.deltaTime;
            } 
            caloriesLost += calorieCalc(movement, weight, Time.deltaTime);
            count+=1;
            CheckRecordTime(movement, time);
            if(movement == "Jogging"){
                CheckRecordAmount(movement, speed);
                CheckRecordDistance(movement, distance);
                distance += MainCam.GetComponent<MoveThreshCheck>().zPos;
            }
            if(movement == "Squats"){
                CheckRecordAmount(movement, squats);
            }
            CheckRecordDistance(movement, time);

            if(isTimeRecord){
                //Do something to let user know that they are achieving a new record e.g. "Keep Going"
                Debug.Log("new time record!");
                headsetText += ("New " + prevMovement + " Time Keep Going!\n");
            }
            if(isAmountRecord){
                //Do something to let user know that they are achieving a new record e.g. "Keep Going"
                Debug.Log("new amount record!");
                headsetText += ("New " + prevMovement + " Max Keep Going!\n");
            }
            if(isDistanceRecord){
                //Do something to let user know that they are achieving a new record e.g. "Keep Going"
                Debug.Log("new distance record!");
                headsetText += ("New " + prevMovement + " Distance Keep Going!\n");
            }
        }else{
            caloriesLostSlow += calorieCalc(prevMovement, weight, time);
            count = 0;
            if(isTimeRecord){
                //set record
                Debug.Log("new record: /n" + prevMovement + " " + time);
                isTimeRecord = false;
            }
            if(isAmountRecord && prevMovement == "Squats"){
                //set record
                Debug.Log("new record: /n" + prevMovement + " " + (int)squats);
                squats = 0.0f;
                isAmountRecord = false;
            }else if(isAmountRecord && prevMovement == "Joggin"){
                //set record
                Debug.Log("new record: /n" + prevMovement + " " + speed);
                isAmountRecord = false;
            }
            if(isDistanceRecord){
                //set record
                Debug.Log("new record: /n" + prevMovement + " " + distance);
                distance = 0.0f;
                isDistanceRecord = false;
            }
            
            //Debug.Log(recordTime(time));
        }
        timeText.GetComponent<TextMesh>().text = totalTime.ToString("0.000");
        calorieText.GetComponent<TextMesh>().text = caloriesLost.ToString("0.00");
        workoutTimeText.GetComponent<TextMesh>().text = time.ToString("0.000");
        headsetTextObj.GetComponent<TextMesh>().text = headsetText;
        prevMovement = movement;
        
    }

    public void CheckRecordTime(string activity, float time){
        GameObject globObj = GameObject.Find("GlobalObj");
        if (activity == "Jogging"){
            if(time > globObj.GetComponent<GlobalControl>().runRecord){
                isTimeRecord = true;
                globObj.GetComponent<GlobalControl>().runRecord = time;
            }
        }else if(activity == "Squats"){
            if(time > globObj.GetComponent<GlobalControl>().squatRecord){
                isTimeRecord = true;
                globObj.GetComponent<GlobalControl>().squatRecord = time;
            }
        }else if(activity == "Walking"){
            if(time > globObj.GetComponent<GlobalControl>().walkRecord){
                isTimeRecord = true;
                globObj.GetComponent<GlobalControl>().walkRecord = time;
            }
        }
        else if(activity == "Standing Still"){
            if(time > globObj.GetComponent<GlobalControl>().stillRecord){
                isTimeRecord = true;
                globObj.GetComponent<GlobalControl>().stillRecord = time;
            }
        }
    }
    public void CheckRecordAmount(string activity, float value){
        GameObject globObj = GameObject.Find("GlobalObj");
        if (activity == "Jogging"){
            if(value > globObj.GetComponent<GlobalControl>().runSpeedRecord){
                isAmountRecord = true;
                globObj.GetComponent<GlobalControl>().runSpeedRecord = value;
            }
        }else if(activity == "Squats"){
            if(value > globObj.GetComponent<GlobalControl>().squatMaxRecord){
                isAmountRecord = true;
                globObj.GetComponent<GlobalControl>().squatMaxRecord = value;
            }
        }
    }
    public void CheckRecordDistance(string activity, float value){
        GameObject globObj = GameObject.Find("GlobalObj");
        if (activity == "Jogging"){
            if(value > globObj.GetComponent<GlobalControl>().runDistanceRecord){
                isDistanceRecord = true;
                globObj.GetComponent<GlobalControl>().runDistanceRecord = value;
            }
        }
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

