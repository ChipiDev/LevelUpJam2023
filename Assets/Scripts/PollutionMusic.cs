using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollutionMusic : MonoBehaviour
{
    [SerializeField] private AudioSource pollutedMusic;
    [SerializeField] private AudioSource cleanMusic;

    private static PollutionMusic instance;
    public static PollutionMusic Instance
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
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Clean());
    }

    private IEnumerator Clean(){
        yield return new WaitUntil(() => TaskList.Instance.IsSixtyPercentCompleted());
        pollutedMusic.volume = 0f;
        cleanMusic.volume = 1f;
    }

    public void StopMusic(){
        cleanMusic.volume = 0f;
    }
}
