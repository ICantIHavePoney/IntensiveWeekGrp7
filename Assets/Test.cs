using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

	public bool isJumping;
	Vector3 startPosition;
	Rigidbody m_rigidbody;

	public GameObject canvas;

	bool doubleJump;

	public int speed;
	public int jumpHeight;

	float gravity = 20;

	float newDash;

	public float dashTimer = 0.5f;

	bool isDashing;

	// Use this for initialization
	void Start ()
	{
        
		m_rigidbody = GetComponent<Rigidbody> ();
		startPosition = transform.position;

	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{



		m_rigidbody.AddForce (Vector3.down * (gravity));



		if (!canvas.activeInHierarchy) {
			if (Input.GetAxisRaw ("Horizontal") == 1) {
				moveRight ();
			}
			if (Input.GetAxisRaw ("Horizontal") == -1) {
				moveLeft ();
			}
		}

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			StartCoroutine ("Dash");
		}

		if (Input.GetKeyDown ("space")) {
			Jump ();
		}

	}

	void moveLeft ()
	{

		transform.Translate (new Vector3 (-1 * Time.deltaTime * speed, 0, 0));
	}

	void moveRight ()
	{
		transform.Translate (new Vector3 (1 * Time.deltaTime * speed, 0, 0));
	}


	void Jump ()
	{


		if (!isJumping) {

			m_rigidbody.AddForce (Vector3.up * jumpHeight, ForceMode.Impulse);
			isJumping = true;
		} else if (isJumping && !doubleJump) {
			m_rigidbody.AddForce (Vector3.up * jumpHeight, ForceMode.Impulse);
			doubleJump = true;
		}

	}


	IEnumerator Dash ()
	{



		isDashing = true;
		gravity = 0;
		m_rigidbody.velocity = Vector3.zero;
		if (Input.GetAxisRaw ("Horizontal") == -1) {
			m_rigidbody.AddForce (Vector3.left * 15, ForceMode.Impulse);
		} else {
			m_rigidbody.AddForce (Vector3.right * 15, ForceMode.Impulse);
		}
		yield return new WaitForSeconds (0.5f);
		m_rigidbody.velocity = Vector3.zero;
		isDashing = false;
		gravity = 20;


	}


	void OnCollisionEnter (Collision other)
	{
		if (other.transform.tag == "floor") {
			isJumping = false;
			doubleJump = false;
		}
	}
}
