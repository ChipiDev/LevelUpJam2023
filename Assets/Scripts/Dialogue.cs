using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject box;
    [SerializeField] private TMP_Text text;

    [SerializeField] private List<string> textList;
    private int listIndex;
    private bool isActive;

    public delegate void OnConversationEnded();
    public static event OnConversationEnded onConversationEnded;

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
    void Start()
    {
        box.SetActive(false);
        gameObject.GetComponent<Collider2D>().enabled = false;
        isActive = false;
    }

    private void Update() {
        if (Input.GetKeyDown("space"))
        {
            Activate();
        }
    }

    private void OnMouseDown() {
        listIndex++;
        if(listIndex < textList.Count)
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

    public bool IsActive(){
        return isActive;
    }
}
