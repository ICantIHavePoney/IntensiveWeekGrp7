using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour {

    GameObject resultText;
    GameObject yesButton;
    GameObject noButton;

	// Use this for initialization
	void Start () {

        resultText = transform.Find("PanelText").gameObject;
        yesButton = transform.Find("Yes").gameObject;
        noButton = transform.Find("No").gameObject;

	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void OnYesClick()
    {
        resultText.GetComponent<Text>().text = "YES";
        resultText.SetActive(true);
        yesButton.SetActive(false);
        noButton.SetActive(false);
    }


}
