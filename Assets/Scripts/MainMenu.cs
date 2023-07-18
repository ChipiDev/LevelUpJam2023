using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject exitButton;

    public GameObject mainMenuOptions;
    public GameObject controlsMenu;
    public GameObject creditsMenu;

    public GameObject levelSelectionMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuOptions.SetActive(true);
        controlsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        levelSelectionMenu.SetActive(false);

#if UNITY_WEBGL
       // En WebGL no nos hace falta este botón
       exitButton.SetActive(false);
#endif

    }

    public void OnStartGameButtonClicked()
    {
        levelSelectionMenu.SetActive(true);
        controlsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        mainMenuOptions.SetActive(false);
    }

    public void OnControlsButtonClicked()
    {
        controlsMenu.SetActive(true);
        levelSelectionMenu.SetActive(false);
        creditsMenu.SetActive(false);
        mainMenuOptions.SetActive(false);
    }

    public void OnCreditsButtonClicked()
    {
        creditsMenu.SetActive(true);
        levelSelectionMenu.SetActive(false);
        controlsMenu.SetActive(false);
        mainMenuOptions.SetActive(false);
    }

    public void OnBackButtonClicked()
    {
        mainMenuOptions.SetActive(true);
        controlsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        levelSelectionMenu.SetActive(false);
    }

    public void OnLevelButtonClicked(int levelIndex)
    {
        Debug.Log("Queremos cargar nivel " + levelIndex);
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
