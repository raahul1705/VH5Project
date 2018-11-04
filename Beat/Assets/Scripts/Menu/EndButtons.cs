using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButtons : MonoBehaviour {
    public AudioSource source;
    public AudioClip click;
    bool load = false;

    public void LoadMenu()
    {
        if (load) return;
        PlayClick();
        SceneManager.LoadScene("Menu");
        load = true;
    }

    public void LoadSelection()
    {
        if (load) return;
        PlayClick();
        SceneManager.LoadScene("Selection");
        load = true;
    }

    void PlayClick()
    {
        source.PlayOneShot(click);
    }
}
