using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class GameData
{
    public int height;
    public int weight;
    public float runRecord;
    public float runSpeedRecord;
    public float runDistanceRecord;
    public float squatRecord;
    public float squatMaxRecord;
    public float walkRecord;
    public float stillRecord;

    public GameData(int heightInt, int weightInt, float runRecordF, float runSpeedRecordF, float runDistanceRecordF, float squatRecordF, float squatMaxRecordF, float walkRecordF, float stillRecordF)
    {
        height = heightInt;
        weight = weightInt;
        runRecord = runRecordF;
        runSpeedRecord = runSpeedRecordF;
        runDistanceRecord = runDistanceRecordF;
        squatRecord = squatRecordF;
        squatMaxRecord = squatMaxRecordF;
        walkRecord = walkRecordF;
        stillRecord = stillRecordF;
    }
}
