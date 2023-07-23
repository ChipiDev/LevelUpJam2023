using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollutionMusic : MonoBehaviour
{
    [SerializeField] private AudioSource pollutedMusic;
    [SerializeField] private AudioSource cleanMusic;

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
}
