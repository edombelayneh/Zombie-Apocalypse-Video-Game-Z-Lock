using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovementController : MonoBehaviour
{
    public float moveSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");  //get x-axis movement: from arrow keys or AD
        float y = Input.GetAxis("Vertical");    //get y-axis movement: from arrow keys or WS
        //Construct the moving direction vector from keyboard input
        Vector3 direction = new Vector3(x, y, 0);

        //Move the transform (i.e., the gameObject) in the given direction and distance
        //The distance is determined by how long you've pressed the keys, and the moveSpeed
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
