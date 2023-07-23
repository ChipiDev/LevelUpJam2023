using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSound : MonoBehaviour
{
    private AudioSource win;

    private static WinSound instance;
    public static WinSound Instance
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
    public void PlayWinSound(){
        win = gameObject.GetComponent<AudioSource>();
        win.Play();
        PollutionMusic.Instance.StopMusic();
    }
}
