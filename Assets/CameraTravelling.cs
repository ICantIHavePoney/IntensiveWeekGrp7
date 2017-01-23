using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTravelling : MonoBehaviour {

    public float smoothTime = 0.3f;
    public Vector3 cameraOffset;

    public GameObject player;

    private Vector3 velocity;

    void FixedUpdate()
    {
        Vector3 target = new Vector3(player.transform.position.x + cameraOffset.x, player.transform.position.y + cameraOffset.y, transform.position.z + cameraOffset.z);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothTime);

    }
}
