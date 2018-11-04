using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionButtons : MonoBehaviour {
    public AudioSource source;
    public AudioClip click;
    public Button selection1, selection2, selection3;
    public AudioClip song1, song2, song3;
    bool load = false;

    void OnEnable()
    {
        //Register Button Events
        selection1.onClick.AddListener(() => LoadLevel("FireAuraNotes", song1));
        selection2.onClick.AddListener(() => LoadLevel("Linus&LucyNotes", song2));
        selection3.onClick.AddListener(() => LoadLevel("OdeToJoyNotes2", song3));
    }

    public void LoadLevel(string songFile, AudioClip song)
    {
        if (load) return;
        PlayClick();
        SongData.instance.song = songFile;
        SongData.instance.songClip = song;
        SceneManager.LoadScene("Level");
        load = true;
    }

    public void LoadBack()
    {
        if (load) return;
        PlayClick();
        SceneManager.LoadScene("Menu");
        load = true;
    }

    void PlayClick()
    {
        source.PlayOneShot(click);
    }
}
