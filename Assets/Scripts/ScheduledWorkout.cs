using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduledWorkout : MonoBehaviour
{
    public GameObject MainCam;
    public float time;
    public ArrayList workOut = new ArrayList();
    public int workOutCount;
    private string movement;
    private int moveNum;
    private int squatCount;


    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        // layout: exercise, time/amount, check for done(1 = not done, 0 = done)
        // exercise: 
        // 1 = stand still
        // 2 = walking
        // 3 = running
        // 4 = squats
        int[] exercise1 = new int[] {1, 30, 1};
        workOut.Add(exercise1);
        int[] exercise2 = new int[] {2, 10, 1};
        workOut.Add(exercise2);
        int[] exercise3 = new int[] {1, 30, 1};
        workOut.Add(exercise3);
        int[] exercise4 = new int[] {2, 10, 1};
        workOut.Add(exercise4);
        int[] exercise5 = new int[] {1, 10, 1};
        workOut.Add(exercise5);

        workOutCount = 0;
        squatCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        squatCount = MainCam.GetComponent<MoveThreshCheck>().squatCount;
        movement = this.gameObject.GetComponent<WorkoutCalc>().movement;
        moveNum = MainCam.GetComponent<MoveThreshCheck>().moveNum;
        var a = workOut[workOutCount];
        int[] b = (int[])a;
        
        if(moveNum == b[0]){
            time += Time.deltaTime;
        }else{
            //give encouragement or tell user what they should be doing
        }
        if(time >= b[1] && b[0] != 4){
            workOutCount += 1;
            time = 0;
            squatCount = 0;
        }else if(squatCount >= b[1] && b[0] == 4){
            workOutCount += 1;
            time = 0;
            squatCount = 0;
        }
        
        
        //running 30 secs
        //walk 10
        //running 30
        //walk 10
        //10 squats
    }
}
