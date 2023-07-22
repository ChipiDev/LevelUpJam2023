using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyPassword : MonoBehaviour
{
    private string keyWord = "pato";
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

        if (key == keyWord)
        {
            Debug.Log("Restart game");

            key = string.Empty;
            PlayerPrefs.SetInt("Nivel", 0);
            SceneManager.LoadScene(0);
            Destroy(gameObject);
        }

    }

}
