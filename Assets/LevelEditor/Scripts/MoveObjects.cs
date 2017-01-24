using UnityEngine;
using System.Collections;

public class MoveObjects : MonoBehaviour {

    public GameObject zStandard;
    float zDifference;

    bool canSelect;

    GameObject selectedObject;

    // Use this for initialization
    void Start () {
        canSelect = true;

    }
	
	// Update is called once per frame
	void Update ()
    {
        zDifference = zStandard.transform.position.z - Camera.main.transform.position.z;

        Debug.Log(Input.mousePosition);


        /*
        if (Input.GetButton("Fire1"))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDifference));
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    hit.transform.position = Vector3.Lerp(position, position, 0.1f);
                }
            }
        }
        */

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f) && Input.GetMouseButtonDown(0) && canSelect == true)
        {
            selectedObject = hit.collider.gameObject;
        }

        Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDifference));

        if (Input.GetMouseButton(0))
        {
            selectedObject.transform.position = Vector3.Lerp(position, position, 00f);
            canSelect = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            selectedObject = null;
            canSelect = true;
        }


    }
}
