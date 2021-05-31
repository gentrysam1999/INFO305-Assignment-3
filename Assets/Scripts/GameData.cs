using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class GameData
{
    public int height;
    public int weight;
    public float runRecord;
    public int squatRecord;

    public GameData(int heightInt, int weightInt, float runRecordF, int squatRecordInt)
    {
        height = heightInt;
        weight = weightInt;
        runRecord = runRecordF;
        squatRecord = squatRecordInt;
    }
}
