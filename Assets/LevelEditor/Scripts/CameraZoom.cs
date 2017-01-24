using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour
{
    float ZoomAmount = 0; //With Positive and negative values
    float MaxToClamp = 10;
    float ROTSpeed = 10;
 
 void Update()
    {
        ZoomAmount += Input.GetAxis("Mouse ScrollWheel");
        ZoomAmount = Mathf.Clamp(ZoomAmount, -MaxToClamp, MaxToClamp);
        var translate = Mathf.Min(Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")), MaxToClamp - Mathf.Abs(ZoomAmount));
        transform.Translate(0, 0, translate * ROTSpeed * Mathf.Sign(Input.GetAxis("Mouse ScrollWheel")));
    }
}



