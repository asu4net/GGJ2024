using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public GameObject MenuObject;
    public GameObject CreditsObject;

    public GameObject Credits_first_selected;
    public GameObject Principal_first_selected;
    public Animator anim;
    AudioSource source;
    public AudioClip openDoor;

    public PlayerController playerController;

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
        source = GetComponent<AudioSource>();
        if (playerController == null)
        {
            playerController = GetComponent<PlayerController>();
        }
        
    }

    public void PausePlay()
    {
        
        playerController.SwitchPlayerState();
        playerController.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        playerController.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        playerController.fs.StopFootsteps();
        playerController.anim.SetBool("fall", false);
        playerController.anim.SetBool("run", false);
        playerController.anim.SetBool("climb", false);
    }

    public void BeginGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void GoToCredits()
    {
        MenuObject.SetActive(false);
        CreditsObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(Credits_first_selected);
    }
    public void GoToMenu()
    {
        MenuObject.SetActive(true);
        CreditsObject.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(Principal_first_selected);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
