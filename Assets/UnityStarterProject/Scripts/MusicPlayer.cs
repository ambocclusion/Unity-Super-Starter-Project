using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip music;
    public float volume = .6f;

    private void Start()
    {
        AudioManager.SoundParams s = new AudioManager.SoundParams(volume, true, "");
        AudioManager.Instance.PlayMusic(music, s);
    }
}
