using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : MonoBehaviour {
    public int value;
    public int response;
    // Use this for initialization

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
            response = value;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
            response = value;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        response = 0;
    }
}
