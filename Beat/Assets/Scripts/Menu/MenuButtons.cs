using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {
    public AudioSource source;
    public AudioClip click;
    bool load = false;

    public void ExitGame()
    {
        if (load) return;
        PlayClick();
        Application.Quit();
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
