using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private GameObject overlay;

    // Start is called before the first frame update
    void Start()
    {
        overlay = new GameObject();
        overlay.name = "overlay";
        overlay.AddComponent<SpriteRenderer>();
        overlay.transform.parent = transform;
        overlay.transform.localScale = Vector3.one * 1.23f;
        overlay.transform.localPosition= Vector3.zero;

        overlay.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
        overlay.GetComponent<SpriteRenderer>().color= Color.white;
        overlay.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder - 1;

        overlay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
    * Función llamada cuando pasamos el mouse por encima, hacemos overlay del sprite
    */
    public void OnMouseEnter()
    {
        Debug.Log("On Mouse Enter");
        overlay.SetActive(true);
    }

    public void OnMouseExit()
    {
        overlay.SetActive(false);
    }


    /*
     * Función llamada cuando clickamos el objeto
     */
    public void OnMouseDown()
    {
        Debug.Log("On mouse down");
    }

    /*
     * Función llamada cuando levantamos el mouse encima del objeto (puede que se quiera cambiar por el Input.getMouse() en el update por si el jugador saca el mouse fuera de la pantalla)
     */
    public void OnMouseUp()
    {
        Debug.Log("On mouse up");
    }
}
