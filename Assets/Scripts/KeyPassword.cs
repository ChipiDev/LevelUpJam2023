using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyPassword : MonoBehaviour
{
    private string restartKeyword = "pato";
    private string unlockAllKeyword = "papa";
    private string key = string.Empty;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            key += "p";
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            key += "a";
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            key += "t";
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            key += "o";
        }

        if (key.Length > 4)
        {
            key = key.Substring(1, key.Length - 1);
        }

        if (key == restartKeyword)
        {
            Debug.Log("Restart game");

            key = string.Empty;
            PlayerPrefs.SetInt("Nivel0", 1);
            PlayerPrefs.SetInt("Nivel1", 0);
            PlayerPrefs.SetInt("Nivel2", 0);
            PlayerPrefs.SetInt("Nivel3", 0);

            SceneManager.LoadScene(0);
            Destroy(gameObject);
        } else if(key == unlockAllKeyword)
        {
            Debug.Log("Unlock all");

            key = string.Empty;
            PlayerPrefs.SetInt("Nivel0", 1);
            PlayerPrefs.SetInt("Nivel1", 1);
            PlayerPrefs.SetInt("Nivel2", 1);
            PlayerPrefs.SetInt("Nivel3", 1);

            SceneManager.LoadScene(0);
            Destroy(gameObject);
        }

    }

}
