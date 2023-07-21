using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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




    public List<ChipiDev.Task> list;
    public TextMeshPro[] textsField;

    // Start is called before the first frame update
    void Start()
    {
        //* Analizamos la escena y creamos a lista de objetos a recoger
        Trash[] trash = FindObjectsOfType<Trash>();
        for (int i = 0; i < trash.Length; i++)
        {
            bool found = false;
            for (int h = 0; h < list.Count; h++)
            {
                if (list[h].trashName == trash[i].name)
                {
                    found = true;
                }
            }
            if (!found)
            {
                ChipiDev.Task newList = new ChipiDev.Task();
                newList.trashName = trash[i].name;
                list.Add(newList);
            }
        }

        //* Vamos a checkear ahora la cantidad
        for (int i = 0; i < trash.Length; i++)
        {
            for (int h = 0; h < list.Count; h++)
            {
                if (list[h].trashName == trash[i].name)
                {
                    list[h].ammountRemaining++;
                }
            }
        }

        //* Habilitamos y editamos los textos correspondientes
        for (int i = 0; i < textsField.Length; i++)
        {
            textsField[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < list.Count; i++)
        {
            list[i].textField = textsField[i];
            list[i].textField.gameObject.SetActive(true);
            list[i].UpdateText();
        }

    }

    public void PickUpTrash(Trash trash)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].trashName == trash.name)
            {
                list[i].ammountPicked++;
                list[i].UpdateText();
            }
        }
    }
}
