using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoteData {
    public float actualTime;
    public float hitTime;
    public float difference;
    public int currentLane;
    public int previousLane;
    public int hit;
    public string type;
}
