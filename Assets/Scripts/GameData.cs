using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class GameData
{
    public int height;
    public int weight;
    public float runRecord;
    public float squatRecord;
    public float walkRecord;
    public float stillRecord;

    public GameData(int heightInt, int weightInt, float runRecordF, float squatRecordF, float walkRecordF, float stillRecordF)
    {
        height = heightInt;
        weight = weightInt;
        runRecord = runRecordF;
        squatRecord = squatRecordF;
        walkRecord = walkRecordF;
        stillRecord = stillRecordF;
    }
}
