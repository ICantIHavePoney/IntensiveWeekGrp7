using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IfLogicv : MonoBehaviour {

    public GameObject entity;
    GameObject Condition;

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {

	}


	public void OnValueChanged(Dropdown d1)
	{
        if(d1.value == 0)
        {
            CanMoveRight();
        }
        
	}

    public void CanMoveRight()
    {

        Debug.Log("toto");
        entity.GetComponent<Test>().player.setCanMoveRight(true);
    }

 
}
