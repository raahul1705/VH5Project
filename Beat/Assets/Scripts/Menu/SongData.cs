using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongData : MonoBehaviour {
    public static SongData instance = null;
    public AudioClip songClip;
    public string song = "";

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
