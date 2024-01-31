using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject playerVisuals;
    public Image black;
    public AudioClip finalFart;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void CallPausePlay()
    {
        gameManager.PausePlay();
    }
    public void TurnOffVisuals()
    {
        playerVisuals.SetActive(false);
    }
    public void TurnOffScreen()
    {
        StartCoroutine(DoorSound());
    }
    public IEnumerator DoorSound()
    {

        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        black.color = Color.black;
        audioSource.clip = finalFart;
        StartCoroutine(EndGame());
    }
    public IEnumerator EndGame()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        gameManager.CloseGame();    
    }

}
