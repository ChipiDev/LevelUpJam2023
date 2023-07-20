using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HUD : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject gameplayPanel;

    void Start()
    {
        if (SceneManager.GetActiveScene().name.Contains('1'))
        {
            // Es el primer escenario, iniciamos tutorial
            tutorialPanel.SetActive(true);
            gameplayPanel.SetActive(false);

        }
        else
        {
            // Es cualquier otro escenario
            tutorialPanel.SetActive(false);
            gameplayPanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Tutorial

    public void OnTutorialAdvaceClicked()
    {
        int childrenCount = tutorialPanel.transform.childCount;
        for (int i = 0; i < childrenCount - 1; i++)
        {
            if (tutorialPanel.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                // Activamos el próximo elemento
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
            // Activamos el próximo elemento
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

