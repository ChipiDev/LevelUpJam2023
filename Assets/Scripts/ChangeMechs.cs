using UnityEngine;

public class ChangeMechs : MonoBehaviour
{
    private SpriteRenderer spriteRendererObject;
    public SpriteRenderer[] spriteRenderer;
    
    private void Start()
    {
        spriteRendererObject = GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown() {
        if (Dialogue.Instance.IsActive()) return;
        GameObject.Find("GameManager").GetComponent<GameManager>().ChangeMechanic();
        spriteChanger();
    }
    
    private void spriteChanger()
    {
        if (spriteRendererObject.sprite == spriteRenderer[0].sprite)
        {
            spriteRendererObject.sprite = spriteRenderer[1].sprite;
        }
        else
        {
            spriteRendererObject.sprite = spriteRenderer[0].sprite;
        }
    }
}
