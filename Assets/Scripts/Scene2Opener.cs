using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene2Opener : MonoBehaviour
{
    AudioSource audioSource;
    public Image black;
    public Color transparent;
    public PlayerController playerController;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(StartScene());
    }
    public IEnumerator StartScene()
    {

        audioSource.Play();
        black.color = Color.black;
        yield return new WaitForSeconds(audioSource.clip.length);
        playerController.SwitchPlayerState();
        black.color = transparent;
    }
}
