using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    GameObject selectedItem;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if (hit)
            {
                if(hitInfo.transform.tag == "Player")
                {
                    selectedItem = hitInfo.transform.gameObject;

                    selectedItem.GetComponent<Test>().canvas.SetActive(true);
                }
            }

        }
	}
}
