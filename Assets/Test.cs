using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public bool isJumping;
    Vector3 startPosition;
    Rigidbody m_rigidbody;

    public GameObject canvas;

    bool doubleJump;

    public int speed;
    public int jumpHeight;

    float translateLat;

	// Use this for initialization
	void Start () {
        
        m_rigidbody = GetComponent<Rigidbody>();
        startPosition = transform.position;

        speed = 10;
        jumpHeight = 10;

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        m_rigidbody.AddForce(Vector3.down * (jumpHeight * 2));

        if (!canvas.activeInHierarchy)
        {
            if(Input.GetAxisRaw("Horizontal") == 1)
            {
                moveRight();
            }
            if(Input.GetAxisRaw("Horizontal") == -1)
            {
                moveLeft();
            }
        }

        if(Input.GetKeyDown("space"))Jump();
	}

    void moveLeft()
    {

        transform.Translate(new Vector3( -1 * Time.deltaTime * speed, 0, 0));
    }

    void moveRight()
    {
        transform.Translate(new Vector3( 1 * Time.deltaTime * speed, 0, 0));
    }


    void Jump()
    {


        if (!isJumping)
        {
            Debug.Log("toto");
            m_rigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isJumping = true;
        }
        else if(isJumping && !doubleJump)
        {
            m_rigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            doubleJump = true;
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "floor")
        {
            isJumping = false;
            doubleJump = false;
        }
    }
}
