using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform Player;

    [SerializeField]
    private float CameraMoveSpeed;

    [SerializeField]
    private Vector3 CameraOffset;

    // Update is called once per frame
    void LateUpdate()
    {
        // Exclude z-axis movement
        Vector3 targetPosition = new Vector3(Player.position.x + CameraOffset.x, Player.position.y + CameraOffset.y, transform.position.z);

        float distanceToMove = CameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, distanceToMove);
    }
}
