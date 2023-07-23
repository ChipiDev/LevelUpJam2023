using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public string allTexts;
    public string incorrectMessage;
    public string trashOnCoco;
    public string incorrectTrashMechanic;
    public string incorrectReusableMechanic;
    public string cocoClick;
    public string cocoClick2;
    public string completationMessage;

    [SerializeField] private GameObject box;
    [SerializeField] private TMP_Text text;

    [SerializeField] private string[] textList;
    private int listIndex;
    public bool isActive;

    public delegate void OnConversationEnded();
    public static event OnConversationEnded onConversationEnded;

    private bool isFinal;

    private static Dialogue instance;
    public static Dialogue Instance
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

    // Start is called before the first frame update
    IEnumerator Start()
    {
        box.SetActive(false);
        gameObject.GetComponent<Collider2D>().enabled = false;
        isActive = false;
        isFinal = false;

        //* Esperamos un fotograma para que los textos se actualicen
        yield return null;
        Debug.Log(allTexts);
        textList = allTexts.Split('|');

        transform.parent = Camera.main.transform;
    }

    private void OnMouseDown() {
        if(isFinal) {
            onConversationEnded?.Invoke();
            return;
        }
        listIndex++;
        if(listIndex < textList.Length)
            text.text = textList[listIndex];
        else{
            onConversationEnded?.Invoke();
        }
    }

    public void Activate(){
        gameObject.GetComponent<Collider2D>().enabled = true;
        box.SetActive(true);
        text.text = textList[0];
        listIndex = 0;
        isActive = true;
    }

    public void ActivateFinal(){
        Activate();
        text.text = "Veo que se te da muy bien esto!! ¿Alguien dijo fiesta?";
        isFinal = true;
    }

    public void Deactivate(){
        gameObject.GetComponent<Collider2D>().enabled = false;
        box.SetActive(false);
        isActive = false;
    }

    public bool IsActive(){
        return isActive;
    }
}
