using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Conductor : MonoBehaviour {
    public static Conductor instance = null;
    public List<Lane> lanes;
    public List<NoteData> entries;
    public float terminalTime;
    public float curTime = 0f;
    public AudioSource music;
    public bool terminate = false;
    bool running = false;

    public int hit = 1;

	void Awake () {
		if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }
	}

    private void Start()
    {
        entries = new List<NoteData>();
    }

    IEnumerator Terminate()
    {
        GenerateReport();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("End");
    }

    void Update () {
        print(curTime);
        if (terminate)
        {
            //StartCoroutine(Terminate());
            GenerateReport();
            SceneManager.LoadScene("End");
        }

		if (BeatmapReader.instance.loaded && !running)
        {
            StartSong();
        }

        else if (BeatmapReader.instance.loaded)
        {
            RunSong();
        }
        
        else 
        {
            BeatmapReader.instance.ReadBeatmap();
        }
	}

    void GenerateReport()
    {
        string json = JsonHelper.ToJson<NoteData>(entries.ToArray());
        print(json);
        System.IO.File.WriteAllText("Assets/report.json", json);
    }

    void RunSong()
    {
        curTime = music.time;
        foreach (Lane l in lanes)
        {
            l.Tic();
        }

        if (curTime >= terminalTime)
        {
            terminate = true;
        }
    }

    void StartSong()
    {
        foreach (Lane l in lanes)
        {
            l.GetNextNote();
        }

        music.clip = SongData.instance.songClip;
        music.Play();

        running = true;
    }
}
