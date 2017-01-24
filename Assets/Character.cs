using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

	public Vector3 checkpointPosition;
	// Use this for initialization
	void Start ()
	{


	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.transform.tag == "DeathZone") {
			transform.position = checkpointPosition;
		}

		if (other.transform.tag == "Checkpoint") {
			checkpointPosition = other.transform.position;
		}


	}

}
