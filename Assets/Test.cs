using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {

    public bool isJumping;
    Vector3 startPosition;
    Rigidbody m_rigidbody;
    bool isDashing;

    public string inputLeft;
    public string inputRight;
    public string dashKey;
    public string jumpKey;

    public GameObject canvas;

    public Entities player;

    float translateLat;


	// Use this for initialization
	void Start () {

        m_rigidbody = GetComponent<Rigidbody>();
        startPosition = transform.position;

        player = new Entities();

        inputLeft = "q";
        inputRight = "d";
        dashKey = "left shift";
        jumpKey = "space";

    }

	// Update is called once per frame
	void FixedUpdate () {



        m_rigidbody.AddForce(Vector3.down * (player.getGravity()));
        

        if (!canvas.activeInHierarchy)
        {
            if (player.getCanMoveLeft() && Input.GetKey(inputLeft))
            {
                moveLeft();

            }
            if (player.getCanMoveRight() && Input.GetKey(inputRight))
            {
                Debug.Log("toto");
                moveRight();
            }
            

        }

        if (Input.GetKeyDown(dashKey))
        {
            StartCoroutine("Dash");
        }

        if (Input.GetKeyDown(jumpKey))
        {
            Jump();
        }

	}

    void moveLeft()
    {

        transform.Translate(new Vector3(-1 * Time.deltaTime * player.getSpeed(), 0, 0));

    }


    void moveRight()
    {

        transform.Translate(new Vector3(1 * Time.deltaTime * player.getSpeed(), 0, 0));

    }


    void Jump()
    {


        if (!isJumping)
        {

            m_rigidbody.AddForce(Vector3.up * player.getJumpHeight(), ForceMode.Impulse);
            isJumping = true;
        }
        else if(isJumping && !player.getDoubleJump())
        {
            m_rigidbody.AddForce(Vector3.up * player.getJumpHeight(), ForceMode.Impulse);
            player.setDoubleJump(true);
        }

    }


    IEnumerator Dash()
    {



        isDashing = true;
        player.setGravity(0);
        m_rigidbody.velocity = Vector3.zero;
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            m_rigidbody.AddForce(Vector3.left * 15, ForceMode.Impulse);
        }
        else
        {
            m_rigidbody.AddForce(Vector3.right * 15, ForceMode.Impulse);
        }
        yield return new WaitForSeconds(0.5f);
        m_rigidbody.velocity = Vector3.zero;
        isDashing = false;
        player.setGravity(20);


    }


    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "floor")
        {
            isJumping = false;
            player.setDoubleJump(false);
        }
    }



}
