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
        azul,
        reusable
    }
    public ETrashType type;

    public static Trash pickedTrash = null;
    [SerializeField]
    private GameObject overlay;
    [HideInInspector]
    public Collider2D collider2Dcollider;
    Vector3 restorePosition;

    private GameManager gameManager;

    public GameObject reusableBackgroundObject;

    // Start is called before the first frame update
    void Start()
    {
        restorePosition = transform.position;
        GetComponent<SpriteRenderer>().sortingOrder = 19;
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
        ActivateOverlay();
    }

    public void OnMouseExit()
    {
        if (Dialogue.Instance.IsActive()) return;

        DeactivateOverlay();
    }


    /*
     * Funci�n llamada cuando clickamos el objeto
     */
    public void OnMouseDown()
    {
        if (Dialogue.Instance.IsActive() || Time.timeSinceLevelLoad < 3) return;

        if (gameManager.GetReciclarActive())
        {
            Trash.pickedTrash = this;
            restorePosition = transform.position;
            collider2Dcollider.enabled = false;

            overlay.GetComponent<SpriteRenderer>().sortingOrder += 5;
            GetComponent<SpriteRenderer>().sortingOrder += 5;
        }
        else
        {
            if (type == ETrashType.reusable)
            {
                TaskList.Instance.ReusableTrash();
                reusableBackgroundObject.SetActive(true);
                Destroy(gameObject);
            }
            else
            {
                Dialogue.Instance.SetText(Dialogue.Instance.incorrectReusableMechanic);
                Dialogue.Instance.Activate();
                GameManager.Instance.PlayErrorSound();
            }
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

            if (Trash.pickedTrash != null && Trash.pickedTrash.gameObject == gameObject)
            {
                overlay.GetComponent<SpriteRenderer>().sortingOrder -= 5;
                GetComponent<SpriteRenderer>().sortingOrder -= 5;
            }

            Trash.pickedTrash = null;
        }

        StartCoroutine(cor());
    }

    private void ActivateOverlay()
    {
        if (!overlay.activeInHierarchy)
        {
            overlay.SetActive(true);


        }

    }

    private void DeactivateOverlay()
    {
        if (overlay.activeInHierarchy)
        {
            overlay.SetActive(false);
        }
    }

    public void Restore()
    {
        transform.position = restorePosition;
        DeactivateOverlay();
    }
}
