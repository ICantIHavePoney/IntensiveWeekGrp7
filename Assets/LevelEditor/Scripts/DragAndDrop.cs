using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour {

    private Vector3 mousePosition;

    GameObject clone;
    public GameObject prefab;

    public GameObject zStandard;
    float zDifference;

    bool canInstantiate;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        zDifference = zStandard.transform.position.z - Camera.main.transform.position.z;

        if (Input.GetButtonDown("Fire1") && canInstantiate == true)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDifference));
            clone = Instantiate(prefab, position, Quaternion.identity) as GameObject;
        }


        if (Input.GetButton("Fire1")&& canInstantiate == true)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDifference));
            clone.transform.position = Vector3.Lerp(position, position, 0.1f);            
        }
        else
        {
            canInstantiate = false;
        }

    }

    public void GetObject(string tag)
    {
        canInstantiate = true;

        /*
        tag = EventSystem.current.currentSelectedGameObject.tag;
  
        if (tag == "GreyBlockUI")
        {
            prefab = GameObject.Find("GreyBlockObj");
        }
        if (tag == "GreenBlockUI")
        {
            prefab = GameObject.Find("GreenBlockObj");
        }
        */


        tag = EventSystem.current.currentSelectedGameObject.tag;

        GameObject test = GameObject.FindGameObjectWithTag(tag);
        if (test.layer != 5)
        {
            prefab = GameObject.FindGameObjectWithTag(tag);
        }

    }
   
}
