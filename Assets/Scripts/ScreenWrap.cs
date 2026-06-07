using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Camera cam;
    private float width;
    private float height;

    void Start() 
    {
        cam = Camera.main;
        height = cam.orthographicSize;
        width = height * cam.aspect;
    }

    void FixedUpdate () 
    {
        Vector3 pos = transform.position;

        if (pos.x > width) 
            pos.x = -width;
        else if (pos.x < -width)
            pos.x = width;
        
        if (pos.y > height)
            pos.y = -height;
        else if (pos.y < -height)
            pos.y = height;
        
        transform.position = pos;
    }
}
