using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMechs : MonoBehaviour
{
    private void OnMouseDown() {
        if (Dialogue.Instance.IsActive()) return;
        GameObject.Find("GameManager").GetComponent<GameManager>().ChangeMechanic();
    }
}
