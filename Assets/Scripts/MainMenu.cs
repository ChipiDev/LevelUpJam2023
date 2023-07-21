using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MainMenu : MonoBehaviour
{
    public GameObject fadePanel;
    public GameObject exitButton;
    public GameObject mainMenuOptions;
    public GameObject controlsMenu;
    public GameObject creditsMenu;
    public GameObject gameTittle;
    public GameObject spainButton;
    public GameObject englishButton;
    public GameObject laguagesText;
    public GameObject levelSelectionMenu;
    public GameObject mainBackground;
    public GameObject creditsBackground;

    // Start is called before the first frame update
    void Start()
    {
        PanelFadeIn(2000);
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
        mainBackground.SetActive(false);
        //selectLevelBackground.setactive(true);
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
        mainBackground.SetActive(false);
        //tutorialbackground.setactive(true);
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
        mainBackground.SetActive(false);
        creditsBackground.SetActive(true);
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
        mainBackground.SetActive(true);
        creditsBackground.SetActive(false);
        //tutorialbackground.setactive(false);
        //selectLevelBackground.setactive(false);
        spainButton.SetActive(true);
        englishButton.SetActive(true);
        laguagesText.SetActive(true);
        gameTittle.SetActive(true);
        mainMenuOptions.SetActive(true);
        controlsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        levelSelectionMenu.SetActive(false);
    }

    public async void OnLevelButtonClicked(int levelIndex)
    {
        await PanelFadeOut(3000);
        SceneManager.LoadScene(levelIndex);
    }

    public async void OnExitButtonClicked()
    {
        await PanelFadeOut(3000);
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
    
    private async void PanelFadeIn(int delay)
    {
        fadePanel.gameObject.SetActive(true);
        fadePanel.gameObject.GetComponent<Animator>().Play("FadeIn");
        await Task.Delay(delay);
        fadePanel.gameObject.SetActive(false);
    }
    
    private async Task PanelFadeOut(int delay)
    {
        fadePanel.gameObject.SetActive(true);
        fadePanel.gameObject.GetComponent<Animator>().Play("FadeOut");
        await Task.Delay(delay);
    }
}
