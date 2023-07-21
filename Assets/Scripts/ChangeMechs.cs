using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMechs : MonoBehaviour
{
    private void OnMouseDown() {
        GameObject.Find("GameManager").GetComponent<GameManager>().ChangeMechanic();
    }
}
