using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    void FixedUpdate ()
    {
        Vector3 pos = transform.position;

        if (pos.x > CameraScript.width) 
            pos.x = -CameraScript.width;
        else if (pos.x < -CameraScript.width)
            pos.x = CameraScript.width;
        
        if (pos.y > CameraScript.height)
            pos.y = -CameraScript.height;
        else if (pos.y < -CameraScript.height)
            pos.y = CameraScript.height;
        
        transform.position = pos;
    }
}
