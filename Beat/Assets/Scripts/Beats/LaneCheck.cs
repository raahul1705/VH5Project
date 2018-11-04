using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneCheck : MonoBehaviour {
    public int laneNum;
    Lane lane;
    public int response = 0;
    public bool inHitBox;
    public bool input;
    public List<HitTrigger> triggers;

    [Header("DATA")]
    public float hitTime, actualTime, difference;
    public int previousLane, curLane, nextLane, hit;
    public string noteType;


    [Header("AESTHETIC")]
    public Material highlight;
    bool changing = false;
    public Material normal;
    public GameObject highlightPanel;
    public ParticleSystem burst;

	// Use this for initialization
	void Start () {
        lane = GetComponent<Lane>();
        normal = highlightPanel.GetComponent<Renderer>().material;
        burst = highlightPanel.GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckHitBoxes();
        CheckInput();
	}

    void CheckHitBoxes()
    {
        response = 0;

        foreach (HitTrigger h in triggers)
        {
            response += h.response;
        }

        inHitBox = (response > 0);

    }

    void CheckInput()
    {
        GetInput();
        HighlightInput();
        if (inHitBox && input)
        {
            switch (response)
            {
                case 1:
                    print("BAD" + " " + response);
                    break;
                case 3:
                    print("BAD" + " " + response);
                    break;
                case 2:
                    print("OK" + " " + response);
                    break;
                case 6:
                    print("GOOD" + " " + response);
                    break;
                case 4:
                    print("PERFECT" + " " + response);
                    break;
                default:
                    print("MISS" + " " + response);
                    break;
            }

            HandleNote();


            foreach (HitTrigger h in triggers)
            {
                h.response = 0;
            }
        }
    }

    public void HandleNote()
    {
        BeatmapReader.Note n = lane.playQueue.Dequeue();
        actualTime = n.HitTime;
        hitTime = Conductor.instance.curTime;
        difference = actualTime - hitTime;
        curLane = laneNum;
        noteType = n.type;

        NoteData entry = new NoteData();
        entry.actualTime = actualTime;
        entry.hitTime = hitTime;
        entry.difference = difference;
        entry.currentLane = curLane;
        entry.previousLane = previousLane;
        entry.hit = Conductor.instance.hit;
        entry.type = noteType;

        Conductor.instance.entries.Add(entry);

        GameObject obj = lane.objectQueue.Dequeue();
        obj.SetActive(false);
        StartCoroutine(KillNote());
        

        previousLane = curLane;
        Conductor.instance.hit = 1;

        if (Mathf.Abs(actualTime - Conductor.instance.terminalTime) < 0.1f)
        {
            Conductor.instance.terminate = true;
        }
    }

    IEnumerator KillNote()
    {
        burst.Play();
        yield return new WaitForSeconds(0.5f);
        burst.Stop();
    }

    void HighlightInput()
    {
        if (input && !changing)
        {
            highlightPanel.GetComponent<Renderer>().material = highlight;
            StartCoroutine(FadeHighlight());
        }
    }

    IEnumerator FadeHighlight()
    {
        changing = true;
        yield return new WaitForSeconds(0.5f);
        highlightPanel.GetComponent<Renderer>().material = normal;
        changing = false;
    }

    void GetInput()
    {
        switch (laneNum) {
            case 1:
                input = InputHandler.instance.l1Down;
                break;
            case 2:
                input = InputHandler.instance.l2Down;
                break;
            case 3:
                input = InputHandler.instance.l3Down;
                break;
            case 4:
                input = InputHandler.instance.l4Down;
                break;
            default:
                input = InputHandler.instance.l5Down;
                break;
        }

        
    }
}
