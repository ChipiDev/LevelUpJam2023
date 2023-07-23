using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollutionFilter : MonoBehaviour
{
    private float percentage;

    private static PollutionFilter instance;
    public static PollutionFilter Instance
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

    private void Start() {
        percentage = 1f;
    }

    public void ClearPollution(int pickedTrash, int totalTrash){
        percentage = (float)pickedTrash / (float)totalTrash;
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        color.a = 1f - percentage;
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }
}
