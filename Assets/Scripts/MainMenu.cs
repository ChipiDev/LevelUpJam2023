using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

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
    public GameObject chaptersBackground;
    public GameObject tutorialbackground;
    [SerializeField] private GameObject level2;
    [SerializeField] private GameObject level3;
    [SerializeField] private GameObject level4;


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

        if(PlayerPrefs.GetInt("FirstTime") == 1){
            #if !UNITY_EDITOR
                PlayerPrefs.SetInt("Nivel", 1);
                PlayerPrefs.SetInt("FirstTime", -1);
            #endif
        }

        Debug.Log(PlayerPrefs.GetInt("Nivel"));

        level2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        level3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        level4.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

        if(PlayerPrefs.GetInt("Nivel") == 1){
            level2.GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 1f);
            level3.GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 1f);
            level4.GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 1f);
        }else if(PlayerPrefs.GetInt("Nivel") == 2){
            level3.GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 1f);
            level4.GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 1f);

        }else if(PlayerPrefs.GetInt("Nivel") == 3){
            level4.GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 1f);
        }
    }

    public void OnStartGameButtonClicked()
    {
        mainBackground.SetActive(false);
        chaptersBackground.SetActive(true);
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
        tutorialbackground.SetActive(true);
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
        tutorialbackground.SetActive(false);
        chaptersBackground.SetActive(false);
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
