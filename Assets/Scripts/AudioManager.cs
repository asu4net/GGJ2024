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
        StopAllCoroutines();
        playlist.Clear();
        playlist= newPlaylist;
        PlayPlaylist();
    }

    public void PlayPlaylist()
    {
        for (int i = 0; i < playlist.Count; i++)
        {
            StartCoroutine(Player(i));
        }
    }

    public IEnumerator Player(int index)
    {
        source.clip = playlist[index];
        yield return new WaitWhile(()=>source.isPlaying);
    }
}
