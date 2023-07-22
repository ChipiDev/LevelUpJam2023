using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    #region Singletone
    private static HUD instance;
    public static HUD Instance
    {
        get
        {
            if (instance != null)
                return instance;
            else
            {
                return null;
            }

        }
        set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public GameObject tutorialPanel;
    public GameObject gameplayPanel;
    public Image fadeImage;

    public bool isInTutorial
    {
        get
        {
            return tutorialPanel.activeInHierarchy;
        }
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name.Contains('1'))
        {
            // Es el primer escenario, iniciamos tutorial
            // tutorialPanel.SetActive(true);
            gameplayPanel.SetActive(false);
        }
        else
        {
            // Es cualquier otro escenario
            tutorialPanel.SetActive(false);
            gameplayPanel.SetActive(true);
        }
        StartCoroutine(FadeOutCor());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator FadeOutCor()
    {
        float duration = 3;
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1);
        while (fadeImage.color.a > 0)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, fadeImage.color.a - (Time.deltaTime / duration));
            yield return null;
        }
        fadeImage.gameObject.SetActive(false);
        Dialogue.Instance.Activate();
    }

    #region Tutorial

    public void OnTutorialAdvaceClicked()
    {
        int childrenCount = tutorialPanel.transform.childCount;
        for (int i = 0; i < childrenCount - 1; i++)
        {
            if (tutorialPanel.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                // Activamos el pr�ximo elemento
                tutorialPanel.transform.GetChild(i).gameObject.SetActive(false);
                tutorialPanel.transform.GetChild(i + 1).gameObject.SetActive(true);
                break;
            }
        }
    }

    public void OnRestartTutorialClicked()
    {
        int childrenCount = tutorialPanel.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            // Activamos el pr�ximo elemento
            tutorialPanel.transform.GetChild(i).gameObject.SetActive(false);
        }
        tutorialPanel.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnFinishTutorialClicked()
    {
        tutorialPanel.SetActive(false);
        gameplayPanel.SetActive(true);
    }

    #endregion
}

