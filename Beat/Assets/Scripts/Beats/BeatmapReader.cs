using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using UnityEngine;

public class BeatmapReader : MonoBehaviour {
    string path;
    string fileName = "FireAuraNotes";
    public bool loaded;
    public static BeatmapReader instance;

    public List<Lane> lanes;

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

    void Start () {
        path = "Beatmaps/";
        fileName = SongData.instance.song;
        path = Path.Combine(path, fileName);
	}

    public void ReadBeatmap()
    {
        TextAsset data = Resources.Load(path) as TextAsset;
        string[] lines = data.text.Split('\n');
        string[] split;
        float time = 0f;
        int noteIndex;
        string type = "";

        foreach (string s in lines)
        {
            if (!s.Equals("-"))
            {
                if (fileName == "FireAuraNotes")
                {
                    split = s.Split(' ');
                    noteIndex = Int32.Parse(split[0]);
                    time = float.Parse(split[1], CultureInfo.InvariantCulture.NumberFormat);
                    Note note = new Note();
                    note.HitTime = time;
                    note.type = "";
                    print(time + " " + noteIndex);
                    lanes[noteIndex].notes.Enqueue(note);
                }

                else
                {
                    split = s.Split(' ');
                    noteIndex = Int32.Parse(split[0]);
                    time = float.Parse(split[2], CultureInfo.InvariantCulture.NumberFormat);
                    Conductor.instance.terminalTime = time;
                    type = split[1];
                    Note note = new Note();
                    note.HitTime = time;
                    note.type = type;
                    print(time + " " + noteIndex + " " + type);
                    lanes[noteIndex].notes.Enqueue(note);
                }
            }
        }

        print(Conductor.instance.terminalTime);

        loaded = true;
    }

    public class Note
    {
        public float HitTime { get; set; }
        public int Lane { get; set; }
        public string type = "";
    }


}

