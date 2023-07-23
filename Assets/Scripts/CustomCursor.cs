using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D cursorTexture;
    void Start()
    {
        Cursor.SetCursor(cursorTexture, new Vector2(), CursorMode.ForceSoftware);
        //Cursor.SetCursor(cursorTexture, new Vector2(), CursorMode.Auto);
    }


}
