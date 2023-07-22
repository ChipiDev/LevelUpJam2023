using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool levelPlayed;
    private bool reciclarActivo;
    [SerializeField] private GameObject container1;
    [SerializeField] private GameObject container2;
    [SerializeField] private GameObject container3;


    // Start is called before the first frame update
    void Start()
    {
        levelPlayed = true;
        Debug.Log("Prueba");
        reciclarActivo = true;
        container1.SetActive(true);
        container2.SetActive(true);
        container3.SetActive(true);
    }

    public void ChangeMechanic(){
        container1.SetActive(!reciclarActivo);
        container2.SetActive(!reciclarActivo);
        container3.SetActive(!reciclarActivo);

        reciclarActivo = !reciclarActivo;
    }

    public bool GetReciclarActive(){
        return reciclarActivo;
    }
}
