using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reusable : MonoBehaviour
{

    //Objeto nuevo despues de clickar
    [SerializeField] private GameObject newBackgroundObject;

    void Start()
    {
        gameObject.SetActive(true);
    }

    private void OnMouseDown() {
        gameObject.SetActive(false);
        newBackgroundObject.SetActive(true);
    }
}