using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivator : MonoBehaviour {
    public Lane lane;
    public LaneCheck laneCheck;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
            Conductor.instance.hit = 0;
            laneCheck.HandleNote();
        }
    }
}
