using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundAudio : MonoBehaviour
{
    public AudioSource backGroundAudio;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    public void mute() {
        if (gameObject.GetComponent<AudioSource>().volume == 1f)
        {
            gameObject.GetComponent<AudioSource>().volume = 0f;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().volume = 1f;
        }
    }
    public void mute1() {
        var a = GameObject.FindGameObjectWithTag("BackGroundAudio");

        var audio = a.GetComponent<AudioSource>();

        if (audio.volume == 1f)
        {
            audio.volume = 0f;
        }
        else {
            audio.volume = 1f;
        }
    }
}
