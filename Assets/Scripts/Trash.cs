using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public enum ETrashType
    {
        amarillo,
        verde,
        azul
    }
    public ETrashType type;

    public static Trash pickedTrash = null;
    private GameObject overlay;
    [HideInInspector]
    public Collider2D collider2Dcollider;
    Vector3 restorePosition;

    int standardOverlayIndex = 5;

    // Start is called before the first frame update
    void Start()
    {
        restorePosition = transform.position;

        overlay = new GameObject();
        overlay.name = "overlay";
        overlay.AddComponent<SpriteRenderer>();
        overlay.transform.parent = transform;
        overlay.transform.localScale = Vector3.one * 1.23f;
        overlay.transform.localPosition = Vector3.zero;

        standardOverlayIndex = GetComponent<SpriteRenderer>().sortingOrder;

        overlay.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
        overlay.GetComponent<SpriteRenderer>().color = Color.white;
        overlay.GetComponent<SpriteRenderer>().sortingOrder = standardOverlayIndex - 1;

        overlay.SetActive(false);

        collider2Dcollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (Trash.pickedTrash)
        {
            DeactivateOverlay();
        }
    }


    /*
    * Función llamada cuando pasamos el mouse por encima, hacemos overlay del sprite
    */
    public void OnMouseEnter()
    {
        ActivateOverlay();
    }

    public void OnMouseExit()
    {
        DeactivateOverlay();
    }


    /*
     * Función llamada cuando clickamos el objeto
     */
    public void OnMouseDown()
    {
        Trash.pickedTrash = this;
        restorePosition = transform.position;
        collider2Dcollider.enabled = false;
    }

    /*
     * Función llamada cuando levantamos el mouse encima del objeto
     */
    public void OnMouseUp()
    {
        IEnumerator cor()
        {
            yield return null;
            DeactivateOverlay();
            collider2Dcollider.enabled = true;
            Trash.pickedTrash = null;
        }

        StartCoroutine(cor());
    }

    private void ActivateOverlay()
    {
        if (!overlay.activeInHierarchy)
        {
            overlay.SetActive(true);

            overlay.GetComponent<SpriteRenderer>().sortingOrder++;
            GetComponent<SpriteRenderer>().sortingOrder++;
        }

    }

    private void DeactivateOverlay()
    {
        if (overlay.activeInHierarchy)
        {
            overlay.SetActive(false);

            overlay.GetComponent<SpriteRenderer>().sortingOrder--;
            GetComponent<SpriteRenderer>().sortingOrder--;
        }
    }

    public void Restore()
    {
        transform.position = restorePosition;
        DeactivateOverlay();
    }
}
