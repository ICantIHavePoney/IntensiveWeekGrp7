using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
	public float duration;
	public float goToX;
	public float backToX;
	public float goToY;
	public float backToY;

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
		transform.DOMove (new Vector2(transform.position.x + goToX, transform.position.y + goToY), duration);
		yield return new WaitForSeconds (5f);
		transform.DOMove (new Vector2(transform.position.x + backToX, transform.position.y + backToY), duration);
		yield return new WaitForSeconds (5f);
		started = true;
		transform.DOKill ();
	}



}
