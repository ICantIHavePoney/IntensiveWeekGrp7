using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScript : MonoBehaviour {

    public GameObject block;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.childCount == 0)
        {
            //var clone = Instantiate(block, new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z), Quaternion.identity) as GameObject;

            var clone = Instantiate(block);
            clone.transform.parent = transform;
            clone.transform.position = transform.position;
            clone.GetComponent<DragTransform>().Editor = GameObject.Find("Editor");
        }         
	}
}
