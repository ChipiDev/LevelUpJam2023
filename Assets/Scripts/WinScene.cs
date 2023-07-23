using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScene : MonoBehaviour
{

    public void LoadMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
