/*

using UnityEngine;
using System.Collections;
using DG.Tweening;


public class CameraDrag : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {

            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(1)) return;

        //Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        //Vector3 move = new Vector3(-pos.x * dragSpeed, -pos.y * dragSpeed, 0);
        //transform.Translate(move, Space.World);

        Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20) - dragOrigin);

        Vector3 move = new Vector3(-position.x , -position.y, 0);
        transform.Translate(move, Space.World);

        //transform.DOMove(pos, 0.1f);

        Debug.Log(position);

    }

    //Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);
}
*/

using UnityEngine;
using System.Collections;


public class CameraDrag : MonoBehaviour
{
    bool bDragging;
    Vector3 oldPos;
    Vector3 panOrigin;
    float panSpeed = 30;

   void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            bDragging = true;
            oldPos = transform.position;
            panOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);                    //Get the ScreenVector the mouse clicked
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition) - panOrigin;    //Get the difference between where the mouse clicked and where it moved
            transform.position = oldPos + -pos * panSpeed;                                         //Move the position of the camera to simulate a drag, speed * 10 for screen to worldspace conversion
        }

        if (Input.GetMouseButtonUp(1))
        {
            bDragging = false;
        }
    }
    
   
}