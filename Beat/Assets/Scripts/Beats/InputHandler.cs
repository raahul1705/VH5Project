using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {
    public bool l1Down, l2Down, l3Down, l4Down, l5Down;
    public KeyCode l1 = KeyCode.A;
    public KeyCode l2 = KeyCode.S;
    public KeyCode l3 = KeyCode.D;
    public KeyCode l4 = KeyCode.J;
    public KeyCode l5 = KeyCode.K;

    public static InputHandler instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        l1Down = Input.GetKeyDown(l1);
        l2Down = Input.GetKeyDown(l2);
        l3Down = Input.GetKeyDown(l3);
        l4Down = Input.GetKeyDown(l4);
        l5Down = Input.GetKeyDown(l5);
	}
}
