using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;

    [HideInInspector]
    public List<AudioClip> playlist;

    public void LoadPlaylist(List<AudioClip> newPlaylist)
    {
        playlist.Clear();
        playlist= newPlaylist;
    }

    public void PlayPlaylist()
    {
        for (int i = 0; i < playlist.Count; i++)
        {
            source.clip = playlist[i];
        }
    }
}
