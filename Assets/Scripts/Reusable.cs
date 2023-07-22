using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reusable : MonoBehaviour
{

    //Objeto nuevo despues de clickar
    [SerializeField] private GameObject newBackgroundObject;
    private GameManager gameManager;

    void Start()
    {
        gameObject.SetActive(true);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        newBackgroundObject.SetActive(false);
    }

    private void OnMouseDown() {
        if(!gameManager.GetReciclarActive() && !Dialogue.Instance.IsActive())
            Pickup();
    }

    public void Pickup()
    {
        gameObject.SetActive(false);
        newBackgroundObject.SetActive(true);
        TaskList.Instance.ReusableTrash();
    }
}
