using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public SpriteRenderer background;

    public float speed = 1.0f;
    public float screenOffsetPercentaje = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 view = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        bool isOutside = view.x < 0 || view.x > 1 || view.y < 0 || view.y > 1;
        if (isOutside) { return; }

        #region Movimiento de cámara

        if (!Trash.pickedTrash)
        {
            Vector2 mouseCoord = Input.mousePosition;
            Vector2 resolution = new Vector3(Screen.width, Screen.height);

            float rightOffset = resolution.x - (resolution.x * screenOffsetPercentaje);
            float leftOffset = (resolution.x * screenOffsetPercentaje);

            if (mouseCoord.x > rightOffset)
            {
                Vector3 space = Vector3.right * speed * Time.deltaTime;
                float multipliyer = (mouseCoord.x - rightOffset) / (resolution.x - rightOffset);
                space *= multipliyer;

                transform.position += space;
            }
            else if (mouseCoord.x < leftOffset)
            {
                Vector3 space = -Vector3.right * speed * Time.deltaTime;
                float multipliyer = (leftOffset - mouseCoord.x) / leftOffset;
                space *= multipliyer;

                transform.position += space;
            }

            var horzExtent = (Camera.main.orthographicSize * Screen.width / Screen.height);
            float rightLimit = background.sprite.bounds.extents.x * background.transform.localScale.x - horzExtent;
            float leftLimit = -rightLimit;

            if (transform.position.x > rightLimit)
            {
                transform.position = new Vector3(rightLimit, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < leftLimit)
            {
                transform.position = new Vector3(leftLimit, transform.position.y, transform.position.z);
            }
        }

        #endregion

        #region Trash movement

        if (Trash.pickedTrash != null)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = Trash.pickedTrash.transform.position.z;
            Trash.pickedTrash.transform.position = Vector3.Lerp(Trash.pickedTrash.transform.position, mouseWorldPos, Mathf.Min(10 * Time.deltaTime, 1));
        }

        #endregion

    }
}
