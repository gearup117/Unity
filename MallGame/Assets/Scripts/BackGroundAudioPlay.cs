using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundAudioPlay : MonoBehaviour
{
    // Start is called before the first frame update
    public void mute()
    {
        var a = GameObject.FindGameObjectWithTag("BackGroundAudio");

        var audio = a.GetComponent<AudioSource>();

        if (audio.volume == 1f)
        {
            audio.volume = 0f;
        }
        else
        {
            audio.volume = 1f;
        }
    }
}
