using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D mainMenuTexture;
    public Texture2D gameplayStandardTexture;
    public Texture2D gameplaySelectTexture;
    public Texture2D gameplayPickTexture;


    #region Singletone
    private static CustomCursor instance;
    public static CustomCursor Instance
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
        if (Instance)
        {
            Destroy(instance.gameObject);
        }
        Instance = this;
    }
    #endregion


    void Start()
    {
        SetMainMenuCursor();
        DontDestroyOnLoad(gameObject);
    }

    public void SetMainMenuCursor()
    {
        Cursor.SetCursor(mainMenuTexture, new Vector2(), CursorMode.ForceSoftware);
    }

    public void SetStandardGameplayHand()
    {
        Cursor.SetCursor(gameplayStandardTexture, new Vector2(), CursorMode.ForceSoftware);
    }

    public void SetSelectGameplayHand()
    {
        Cursor.SetCursor(gameplaySelectTexture, new Vector2(), CursorMode.ForceSoftware);
    }

    public void SetPickingHand()
    {
        Cursor.SetCursor(gameplayPickTexture, new Vector2(), CursorMode.ForceSoftware);
    }
}
