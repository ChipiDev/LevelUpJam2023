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

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        restorePosition = transform.position;
        overlay.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder - 1;
        overlay.transform.localScale = Vector3.one * 1.23f;
        overlay.SetActive(false);

        collider2Dcollider = GetComponent<Collider2D>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (Trash.pickedTrash && gameManager.GetReciclarActive())
        {
            DeactivateOverlay();
        }
    }


    /*
    * Funci�n llamada cuando pasamos el mouse por encima, hacemos overlay del sprite
    */
    public void OnMouseEnter()
    {
        if (Dialogue.Instance.IsActive()) return;
        if (gameManager.GetReciclarActive())
        {
            ActivateOverlay();
        }
        else
        {
            //Cosas y sonidos de error
            Debug.Log("Reutilizar activo");
        }
    }

    public void OnMouseExit()
    {
        if (Dialogue.Instance.IsActive()) return;

        if (gameManager.GetReciclarActive())
        {
            DeactivateOverlay();
        }
        else
        {
            //Cosas y sonidos de error
            Debug.Log("Reutilizar activo");
        }
    }


    /*
     * Funci�n llamada cuando clickamos el objeto
     */
    public void OnMouseDown()
    {
        if (Dialogue.Instance.IsActive()) return;

        if (gameManager.GetReciclarActive())
        {
            Trash.pickedTrash = this;
            restorePosition = transform.position;
            collider2Dcollider.enabled = false;
        }
        else
        {
            //Cosas y sonidos de error
            Debug.Log("Reutilizar activo");
        }
    }

    /*
     * Funci�n llamada cuando levantamos el mouse encima del objeto
     */
    public void OnMouseUp()
    {
        if (Dialogue.Instance.IsActive()) return;

        IEnumerator cor()
        {
            yield return null;
            DeactivateOverlay();
            collider2Dcollider.enabled = true;
            Trash.pickedTrash = null;
        }

        if (gameManager.GetReciclarActive())
        {
            StartCoroutine(cor());
        }
        else
        {
            //Cosas y sonidos de error
            Debug.Log("Reutilizar activo");
        }
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
