using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DisappearingPlatform : MonoBehaviour
{
	public float duration;
	public float goToX;
	public float backToX;
	public float goToY;
	public float backToY;
	public float goToZ;
	public float backToZ;

	Vector3 originTransform;
	bool started = true;

	void Start ()
	{
		StartCoroutine ("Move");
		originTransform = transform.position;
	}

	void Update ()
	{
		if (started == true) {
			StartCoroutine ("Move");
		}

	}

	IEnumerator Move ()
	{
		started = false;
		transform.DOLocalMove (new Vector3 (transform.position.x + goToX, transform.position.y + goToY, transform.position.z + goToZ), duration);
		yield return new WaitForSeconds (5f);
		transform.DOLocalMove (new Vector3 (transform.position.x + backToZ, transform.position.y + backToZ, transform.position.z + backToZ), duration);
		yield return new WaitForSeconds (5f);
		started = true;
		transform.DOKill ();
	}



}
