using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicPlayerController : MonoBehaviour {
    public float moveSpeed = 3f;
    public float jumpForce = 100f;

    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //Move left or right
        float x = Input.GetAxis("Horizontal");
        //Construct the moving direction vector from keyboard input
        Vector3 direction = new Vector3(x, 0, 0);

        //Move the transform (i.e., the gameObject) in the given direction and distance
        //The distance is determined by how long you've pressed the keys, and the moveSpeed
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);

        //If Spacebar is pressed: jump
        if (Input.GetKeyDown(KeyCode.Space)) { 
            rb.AddForce(new Vector3(0.0f, jumpForce, 0.0f));
        }         
    }
}

