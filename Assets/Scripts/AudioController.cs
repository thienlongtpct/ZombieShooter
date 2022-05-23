using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource BGMusic;
    void Start()
    {
        int isMusic = PlayerPrefs.GetInt("Music", 1);
        if (isMusic == 0)
        {
            BGMusic.mute = true;
        }
        else
        {
            BGMusic.mute = false;
        }
    }
}
