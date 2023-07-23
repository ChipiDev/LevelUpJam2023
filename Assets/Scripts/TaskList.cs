using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace ChipiDev
{
    [System.Serializable]
    public class Task
    {
        public string trashName;
        public int ammountPicked;
        public int ammountRemaining;
        public TextMeshPro textField;

        public Task()
        {
            trashName = string.Empty;
            ammountPicked = 0;
            ammountRemaining = 0;
        }

        public void UpdateText()
        {
            textField.text = trashName + " " + ammountPicked.ToString() + "/" + ammountRemaining;
            if (ammountPicked == ammountRemaining)
            {
                textField.fontStyle = FontStyles.Strikethrough;
            }
        }

    }
}



public class TaskList : MonoBehaviour
{

    #region Singletone
    private static TaskList instance;
    public static TaskList Instance
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

    public int pickedTrash = 0;
    public int totalTrash = 0;

    public int reusabledTrash = 0;
    public int totalReusableTrash = 0;

    [Space(10)]
    public float showSpeed = 6;
    public float showHeight = 1.3f;
    private Vector3 hidePosition;
    private Vector3 showPosition;
    private bool show = false;

    //public List<ChipiDev.Task> list;
    public TextMeshPro[] textsField;

    // Start is called before the first frame update
    void Start()
    {
        hidePosition = transform.localPosition;
        showPosition = hidePosition + Vector3.up * showHeight;

        Trash[] trash = FindObjectsOfType<Trash>();
        totalTrash = 0;
        totalReusableTrash = 0;

        for (int i = 0; i < trash.Length; i++)
        {
            if (trash[i].type == Trash.ETrashType.reusable)
            {
                totalReusableTrash++;
            }
            else
            {
                totalTrash++;
            }
        }


        UpdateList();

        #region C�digo antiguo que analiza toda la basura
        //* Analizamos la escena y creamos a lista de objetos a recoger
        //Trash[] trash = FindObjectsOfType<Trash>();
        //for (int i = 0; i < trash.Length; i++)
        //{
        //    bool found = false;
        //    for (int h = 0; h < list.Count; h++)
        //    {
        //        if (list[h].trashName == trash[i].name)
        //        {
        //            found = true;
        //        }
        //    }
        //    if (!found)
        //    {
        //        ChipiDev.Task newList = new ChipiDev.Task();
        //        newList.trashName = trash[i].name;
        //        list.Add(newList);
        //    }
        //}

        ////* Vamos a checkear ahora la cantidad
        //for (int i = 0; i < trash.Length; i++)
        //{
        //    for (int h = 0; h < list.Count; h++)
        //    {
        //        if (list[h].trashName == trash[i].name)
        //        {
        //            list[h].ammountRemaining++;
        //        }
        //    }
        //}

        ////* Habilitamos y editamos los textos correspondientes
        //for (int i = 0; i < textsField.Length; i++)
        //{
        //    textsField[i].gameObject.SetActive(false);
        //}

        //for (int i = 0; i < list.Count; i++)
        //{
        //    list[i].textField = textsField[i];
        //    list[i].textField.gameObject.SetActive(true);
        //    list[i].UpdateText();
        //}
        #endregion

    }

    private void Update()
    {
        if (show)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, showPosition, Time.deltaTime * showSpeed);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, hidePosition, Time.deltaTime * showSpeed);
        }
    }

    public void PickUpTrash(Trash trash)
    {
        pickedTrash++;
        UpdateList();
        PollutionFilter.Instance.ClearPollution(pickedTrash, totalTrash);

        //for (int i = 0; i < list.Count; i++)
        //{
        //    if (list[i].trashName == trash.name)
        //    {
        //        list[i].ammountPicked++;
        //        list[i].UpdateText();
        //    }
        //}
    }

    public void ReusableTrash()
    {
        reusabledTrash++;
        UpdateList();
    }

    public void UpdateList()
    {
        string recycledTextString = "Recycled ";
        string reusedTextString = "Recycled ";


        if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1])
        {
            recycledTextString = "Reciclado ";
            reusedTextString = "Reusado ";
        }

        textsField[0].text = recycledTextString + pickedTrash.ToString() + "/" + totalTrash.ToString();
        textsField[1].text = reusedTextString + reusabledTrash.ToString() + "/" + totalReusableTrash.ToString();

        if (pickedTrash == totalTrash)
        {
            textsField[0].fontStyle = FontStyles.Strikethrough;
        }

        if (reusabledTrash == totalReusableTrash)
        {
            textsField[1].fontStyle = FontStyles.Strikethrough;
        }

        if (pickedTrash == totalTrash && reusabledTrash == totalReusableTrash)
        {
            Debug.Log("Hemos ganao");
            int sceneNumber = SceneManager.GetActiveScene().buildIndex - 1;
            PlayerPrefs.SetInt("Nivel" + sceneNumber.ToString(), 1);
            Dialogue.Instance.ActivateFinal();
            //Sonido de triunfo
            //Muñeco gesto feliz
        }
    }

    private void OnEnable()
    {
        Dialogue.onConversationEnded += OnConversationEnded;
    }

    private void OnDisable()
    {
        Dialogue.onConversationEnded -= OnConversationEnded;
    }

    private void OnConversationEnded()
    {
        if (pickedTrash == totalTrash && reusabledTrash == totalReusableTrash)
        {
            int sceneNumber = SceneManager.GetActiveScene().buildIndex;

            PlayerPrefs.SetInt("Nivel" + (sceneNumber).ToString(), 1);
            SceneManager.LoadScene(sceneNumber + 1);
        }
        else
        {
            Dialogue.Instance.Deactivate();
        }

    }

    private void OnMouseDown()
    {
        if (Dialogue.Instance.IsActive()) return;
        show = !show;
    }

    public bool IsSixtyPercentCompleted(){
        return ((float)pickedTrash / (float)totalTrash) * 100 > 60;
    }

    //private void OnMouseExit()
    //{
    //    if (HUD.Instance.isInTutorial) { return; }
    //    show = false;
    //}


}
