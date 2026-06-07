using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    private Vector2 gameAspect = new Vector2(4,3);

    private int width;
    private int height;

    void Start()
    {
        applyAspect();
        width = Screen.width;
        height = Screen.height;
    }

    void Update()
    {
        if (width != Screen.width || height != Screen.height)
        {
            applyAspect();
            width = Screen.width;
            height = Screen.height;
        }
    }

    private void applyAspect()
    {
        float targetAspect = gameAspect.x / gameAspect.y;
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        Camera cam = Camera.main;

        if (scaleHeight < 1.0f)
        {
            Rect rect = cam.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            cam.rect = rect;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            Rect rect = cam.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            cam.rect = rect;
        }
    }
}
