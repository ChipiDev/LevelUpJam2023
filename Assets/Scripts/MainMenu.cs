using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
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
    [SerializeField] private Button[] levels;

    public Slider volumeSlider;

    private bool isLoadingLevel = false;
    // Start is called before the first frame update
    void Start()
    {
        IEnumerator fadeOutCor()
        {
            fadePanel.gameObject.SetActive(true);
            fadePanel.gameObject.GetComponent<Animator>().Play("FadeIn");
            yield return new WaitForSeconds(2);
            fadePanel.gameObject.SetActive(false);
        }
        StartCoroutine(fadeOutCor());

        if (GameManager.levelPlayed)
        {
            OnStartGameButtonClicked();
        }
        else
        {
            InitialiceStartScene();
        }

#if UNITY_WEBGL
        exitButton.SetActive(false);
#endif

#if !UNITY_EDITOR
        if (PlayerPrefs.GetInt("FirstTime") == 1)
        {
                PlayerPrefs.SetInt("Nivel", 1);
                PlayerPrefs.SetInt("FirstTime", -1);
        }
#endif
        PlayerPrefs.SetInt("Nivel0", 1);

        for (int i = 0; i < levels.Length; i++)
        {
            if (PlayerPrefs.GetInt("Nivel" + i.ToString()) == 1)
            {
                levels[i].interactable = true;
            }
            else
            {
                levels[i].interactable = false;
                levels[i].GetComponent<EventTrigger>().enabled = false;
            }
        }

        audioMixer.GetFloat("Volume", out float volume);
        volumeSlider.value = -Mathf.Sqrt(Mathf.Abs(volume));

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

    public void OnLevelButtonClicked(int levelIndex)
    {
        if (isLoadingLevel) return;

        Debug.Log("Nivel desbloqueado: " + PlayerPrefs.GetInt("Nivel"));

        IEnumerator waitCor()
        {
            // Restamos 1 para no contar el men� principal
            isLoadingLevel = true;
            fadePanel.gameObject.SetActive(true);
            fadePanel.gameObject.GetComponent<Animator>().Play("FadeOut");
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(levelIndex);
        }
        StartCoroutine(waitCor());
    }

    public void OnExitButtonClicked()
    {
        if (isLoadingLevel) return;

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    private void InitialiceStartScene()
    {
        mainMenuOptions.SetActive(true);
        controlsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        levelSelectionMenu.SetActive(false);
        gameTittle.SetActive(true);
        spainButton.SetActive(true);
        englishButton.SetActive(true);
        laguagesText.SetActive(true);
    }

    public void SetSpanishLanguage()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
    }

    public void SetEnglishLanguage()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
    }

    public void OnVolumeSliderChange(float value)
    {
        audioMixer.SetFloat("Volume", -(value * value));
    }

}
