using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MainMenu : MonoBehaviour
{
    public GameObject exitButton;
    public GameObject mainMenuOptions;
    public GameObject controlsMenu;
    public GameObject creditsMenu;
    public GameObject gameTittle;
    public GameObject spainButton;
    public GameObject englishButton;
    public GameObject laguagesText;
    public GameObject levelSelectionMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuOptions.SetActive(true);
        controlsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        levelSelectionMenu.SetActive(false);
        gameTittle.SetActive(true);
        spainButton.SetActive(true);
        englishButton.SetActive(true);
        laguagesText.SetActive(true);

        #if UNITY_WEBGL
               exitButton.SetActive(false);
        #endif
    }

    public void OnStartGameButtonClicked()
    {
        levelSelectionMenu.SetActive(true);
        gameTittle.SetActive(false);
        spainButton.SetActive(false);
        englishButton.SetActive(false);
        laguagesText.SetActive(false);
        controlsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        mainMenuOptions.SetActive(false);
    }

    public void OnControlsButtonClicked()
    {
        spainButton.SetActive(false);
        englishButton.SetActive(false);
        laguagesText.SetActive(false);
        gameTittle.SetActive(false);
        controlsMenu.SetActive(true);
        levelSelectionMenu.SetActive(false);
        creditsMenu.SetActive(false);
        mainMenuOptions.SetActive(false);
    }

    public void OnCreditsButtonClicked()
    {
        spainButton.SetActive(false);
        englishButton.SetActive(false);
        laguagesText.SetActive(false);
        gameTittle.SetActive(false);
        creditsMenu.SetActive(true);
        levelSelectionMenu.SetActive(false);
        controlsMenu.SetActive(false);
        mainMenuOptions.SetActive(false);
    }

    public void OnBackButtonClicked()
    {
        spainButton.SetActive(true);
        englishButton.SetActive(true);
        laguagesText.SetActive(true);
        gameTittle.SetActive(true);
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
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
