using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementBlocker : MonoBehaviour
{
    private bool isMouseInside = false;
    // Start is called before the first frame update
    void Start()
    {

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
}
