using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicClass : MonoBehaviour
{
    AudioSource _as;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _as = GetComponent<AudioSource>();
        _as.Play();
    }

    public void PlayMusic()
    {
        if (_as.isPlaying) return;
        _as.Play();
    }
    public void StopMusic()
    {
        _as.Stop();
    }
}
