using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Trash;

public class Container : MonoBehaviour
{
    public ETrashType type;
    private bool isMouseInside = false;

    // Update is called once per frame
    void Update()
    {
        if (isMouseInside && Trash.pickedTrash)
        {
            if (!Input.GetMouseButton(0))
            {
                if (type == Trash.pickedTrash.type)
                {
                    PickUpTrash(Trash.pickedTrash);
                    Trash.pickedTrash = null;
                }else
                {
                    // Que se ha equivocao
                    Trash.pickedTrash.collider2Dcollider.enabled = true;
                    Trash.pickedTrash.Restore();
                    Trash.pickedTrash = null;
                }
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

    private void PickUpTrash(Trash trash)
    {
        TaskList.Instance.PickUpTrash(trash);
        Destroy(trash.gameObject);
    }
}
