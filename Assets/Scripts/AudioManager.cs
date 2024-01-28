using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource source;

    [HideInInspector]
    public List<AudioClip> playlist;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    public void LoadPlaylist(TriggerFunctionality tf)
    {
        
        StopAllCoroutines();
        playlist.Clear();
        playlist= tf.clips; 
        PlayPlaylist();
    }

    public void PlayPlaylist()
    {
        StartCoroutine(Player());
    }

    public IEnumerator Player()
    {
        for (int i = 0; i < playlist.Count; i++)
        {
            source.clip = playlist[i];
            source.Play();
            yield return new WaitForSeconds(source.clip.length);
        } 
    }
}
