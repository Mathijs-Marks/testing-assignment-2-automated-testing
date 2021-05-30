using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacleController : MonoBehaviour
{

    private bool movingRight;
    private bool movingLeft;
    [SerializeField] private float movementSpeed = 1f;
    private static float LaneOffsetLeft = 1.5f;
    private static float LaneOffsetRight = -1.5f;
    private Vector3 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        movingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the obstacle's current position.
        newPosition = transform.position;

        if (movingRight)
        {
            // Move the obstacle to the right.
            newPosition.z -= movementSpeed * Time.deltaTime;

            // Check if the obstacle has reached the edge of the lane.
            if (newPosition.z <= LaneOffsetRight)
            {
                // Set the obstacle back on the edge to make sure it doesn't overshoot.
                newPosition.z = LaneOffsetRight;

                // Inverse the movement.
                movingRight = false; 
                movingLeft = true;
            }
        }

        if (movingLeft)
        {
            // Move the obstacle to the left.
            newPosition.z += movementSpeed * Time.deltaTime;

            // Check if the obstacle has reached the edge of the lane.
            if (newPosition.z >= LaneOffsetLeft)
            {
                // Set the obstacle back on the edge to make sure it doesn't overshoot.
                newPosition.z = LaneOffsetLeft;

                // Inverse the movement.
                movingLeft = false;
                movingRight = true;
            }
        }

        // Update the position of the obstacle with the new position.
        // (Do the actual movement)
        transform.position = newPosition;
    }
}
