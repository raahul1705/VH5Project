using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour {
    public Queue<BeatmapReader.Note> notes;
    public Queue<BeatmapReader.Note> playQueue;
    public Queue<GameObject> objectQueue;

    public BeatmapReader.Note previous, next;

    BeatmapReader.Note curNote;
    public float spawnOffset = 1f;
    Spawner spawner;

    private void Start()
    {
        notes = new Queue<BeatmapReader.Note>();
        print("INIT" + notes);
        playQueue = new Queue<BeatmapReader.Note>();
        objectQueue = new Queue<GameObject>();
        spawner = GetComponent<Spawner>();
    }

    public void Tic()
    {

        //if (notes.Count < 0) return;
        if (curNote != null) print(curNote.HitTime);
        if (curNote != null && Mathf.Abs(Conductor.instance.curTime - (curNote.HitTime - spawnOffset)) < 0.1)
        {
            playQueue.Enqueue(curNote);
            objectQueue.Enqueue(spawner.SpawnNote());
            GetNextNote();
        }
        
    }

    public BeatmapReader.Note GetNextNote()
    {
        if (notes.Count != 0)
            curNote = notes.Dequeue();
        else
            curNote = null;
        return curNote;
    }
}
