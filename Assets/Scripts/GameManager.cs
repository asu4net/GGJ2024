using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject MenuObject;
    public GameObject CreditsObject;
   
    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void BeginGame()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToCredits()
    {
        MenuObject.SetActive(false);
        CreditsObject.SetActive(true);
    }
    public void GoToMenu()
    {
        MenuObject.SetActive(true);
        CreditsObject.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
