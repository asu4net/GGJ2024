using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject playerVisuals;
    public GameObject butt;
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
        TurnOffVisuals();
    }
    public void TurnOffVisuals()
    {
        playerVisuals.SetActive(false);
        StartCoroutine(DoorSound());
    }
    public void TurnOffScreen()
    {
        StartCoroutine(DoorSound());
    }
    public IEnumerator DoorSound()
    {

        audioSource.Play();
        black.color = Color.black;
        butt.SetActive(false);
        yield return new WaitForSeconds(audioSource.clip.length);   
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
