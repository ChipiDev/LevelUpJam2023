using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public string name;

    public enum ETrashType
    {
        amarillo,
        verde,
        azul
    }
    public ETrashType type;

    public static Trash pickedTrash = null;
    [SerializeField]
    private GameObject overlay;
    [HideInInspector]
    public Collider2D collider2Dcollider;
    Vector3 restorePosition;

    // Start is called before the first frame update
    void Start()
    {
        restorePosition = transform.position;
        overlay.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder - 1;
        overlay.transform.localScale = Vector3.one * 1.23f;
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
    * Funci�n llamada cuando pasamos el mouse por encima, hacemos overlay del sprite
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
     * Funci�n llamada cuando clickamos el objeto
     */
    public void OnMouseDown()
    {
        Trash.pickedTrash = this;
        restorePosition = transform.position;
        collider2Dcollider.enabled = false;
    }

    /*
     * Funci�n llamada cuando levantamos el mouse encima del objeto
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
