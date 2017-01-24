using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DisappearingPlatform : MonoBehaviour
{
	public float duration;
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
		transform.DOLocalMoveZ (goToZ, duration);
		yield return new WaitForSeconds (5f);
		transform.DOLocalMoveZ (backToZ, duration);
		yield return new WaitForSeconds (5f);
		started = true;
		transform.DOKill ();
	}



}
