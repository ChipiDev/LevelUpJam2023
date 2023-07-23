using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollutionFilter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Deactivate());
    }

    private IEnumerator Deactivate(){
        yield return new WaitUntil(() => TaskList.Instance.IsSixtyPercentCompleted());
        gameObject.SetActive(false);
    }
}
