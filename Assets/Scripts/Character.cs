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

    public void SetHappy()
    {
        if (expresionCoroutine != null)
        {
            StopCoroutine(expresionCoroutine);
        }
        IEnumerator expresionCor()
        {
            spriteRenderer.sprite = happySprite;
            yield return new WaitForSeconds(2);
            spriteRenderer.sprite = neutralSprite;
        }
        expresionCoroutine = StartCoroutine(expresionCor());
    }

    public void SetAngry()
    {
        if (expresionCoroutine != null)
        {
            StopCoroutine(expresionCoroutine);
        }
        IEnumerator expresionCor()
        {
            spriteRenderer.sprite = angrySprite;
            yield return new WaitForSeconds(2);
            spriteRenderer.sprite = neutralSprite;
        }
        expresionCoroutine = StartCoroutine(expresionCor());
    }

    public void Jump()
    {
        anim.Play("Jump");
    }
}
