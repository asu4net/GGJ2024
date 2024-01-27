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
