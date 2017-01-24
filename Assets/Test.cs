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
		GameObject.Find ("Scarf").GetComponent<SpriteRenderer>().flipX = true;
		GameObject.Find ("Head").GetComponent<SpriteRenderer>().flipX = true;
		GameObject.Find ("FootLeft").GetComponent<SpriteRenderer>().flipX = true;
		GameObject.Find ("LegLeft").GetComponent<SpriteRenderer>().flipX = true;
		GameObject.Find ("Aine").GetComponent<SpriteRenderer>().flipX = true;
		GameObject.Find ("Planche").GetComponent<SpriteRenderer>().flipX = true;
		GameObject.Find ("Buste").GetComponent<SpriteRenderer>().flipX = true;
		GameObject.Find ("FootRight").GetComponent<SpriteRenderer>().flipX = true;
		GameObject.Find ("UpLegRight").GetComponent<SpriteRenderer>().flipX = true;
		GameObject.Find ("Planche_5").GetComponent<SpriteRenderer>().flipX = true;
		GameObject.Find ("PunchLeft").GetComponent<SpriteRenderer>().flipX = true;
	}

	void moveRight ()
	{
		transform.Translate (new Vector3 (1 * Time.deltaTime * speed, 0, 0));
		GameObject.Find ("Scarf").GetComponent<SpriteRenderer>().flipX = false;
		GameObject.Find ("Head").GetComponent<SpriteRenderer>().flipX = false;
		GameObject.Find ("FootLeft").GetComponent<SpriteRenderer>().flipX = false;
		GameObject.Find ("LegLeft").GetComponent<SpriteRenderer>().flipX = false;
		GameObject.Find ("Aine").GetComponent<SpriteRenderer>().flipX = false;
		GameObject.Find ("Planche").GetComponent<SpriteRenderer>().flipX = false;
		GameObject.Find ("Buste").GetComponent<SpriteRenderer>().flipX = false;
		GameObject.Find ("FootRight").GetComponent<SpriteRenderer>().flipX = false;
		GameObject.Find ("UpLegRight").GetComponent<SpriteRenderer>().flipX = false;
		GameObject.Find ("Planche_5").GetComponent<SpriteRenderer>().flipX = false;
		GameObject.Find ("PunchLeft").GetComponent<SpriteRenderer>().flipX = false;
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
