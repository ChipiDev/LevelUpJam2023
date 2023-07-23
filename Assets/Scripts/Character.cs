using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    #region Singletone
    private static Character instance;
    public static Character Instance
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
    #endregion

    public Sprite neutralSprite;
    public Sprite happySprite;
    public Sprite angrySprite;

    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private bool isMouseInside = false;
    private Coroutine expresionCoroutine;

    bool clicked = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseInside && Trash.pickedTrash)
        {
            if (!Input.GetMouseButton(0))
            {
                // Que se ha equivocao
                Trash.pickedTrash.collider2Dcollider.enabled = true;
                Trash.pickedTrash.Restore();
                Trash.pickedTrash = null;

                Dialogue.Instance.SetText(Dialogue.Instance.trashOnCoco);
                Dialogue.Instance.Activate();
                SetAngry();

                Jump();
            }
        }

    }

    private void OnMouseEnter()
    {
        isMouseInside = true;
    }

    private void OnMouseExit()
    {
        isMouseInside = false;
    }

    private void OnMouseDown()
    {
        if (Dialogue.Instance.isDialogeActive) { return; }
        if (clicked)
        {
            Dialogue.Instance.SetText(Dialogue.Instance.cocoClick2);
            Dialogue.Instance.Activate();
        }
        else
        {
            Dialogue.Instance.SetText(Dialogue.Instance.cocoClick);
            Dialogue.Instance.Activate();
            SetHappy();
        }

        clicked = true;

    }

    public void SetHappy()
    {
        spriteRenderer.sprite = happySprite;

        //if (expresionCoroutine != null)
        //{
        //    StopCoroutine(expresionCoroutine);
        //}
        //IEnumerator expresionCor()
        //{
        //    spriteRenderer.sprite = happySprite;
        //    yield return new WaitForSeconds(2);
        //    spriteRenderer.sprite = neutralSprite;
        //}
        //expresionCoroutine = StartCoroutine(expresionCor());
    }

    public void SetAngry()
    {
        spriteRenderer.sprite = angrySprite;

        //if (expresionCoroutine != null)
        //{
        //    StopCoroutine(expresionCoroutine);
        //}
        //IEnumerator expresionCor()
        //{
        //    spriteRenderer.sprite = angrySprite;
        //    yield return new WaitForSeconds(2);
        //    spriteRenderer.sprite = neutralSprite;
        //}
        //expresionCoroutine = StartCoroutine(expresionCor());
    }

    public void SetNeutral()
    {
        spriteRenderer.sprite = neutralSprite;
    }

    public void Jump()
    {
        anim.Play("Jump");
    }
}
