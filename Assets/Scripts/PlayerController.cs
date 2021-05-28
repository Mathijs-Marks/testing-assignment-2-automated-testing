using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rigidbody; // Store a reference to the RigidBody required to use 3D physics.
    private Vector3 movement; // Vector3 variable to store the player's movement.
    [SerializeField] private float moveSpeed = 0.5f; // Floating point variable to store the player's movement speed.
    [SerializeField] private float jumpPower = 1f;
    [SerializeField] private float moveDistance = 1;
    [SerializeField] private int playerPositionZ = 1;
    [SerializeField] private int playerPositionY = 1;

    // Start is called before the first frame update
    private void Start()
    {
        // Get and store a reference to the RigidBody component so that we can access it.
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        MoveForward();

        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetButtonDown("Jump"))
        {
            MoveJump();
        }
    }

    private void MoveForward()
    {
        // Move the player along the positive X axis.
        transform.Translate(moveSpeed, 0, 0);
    }

    public void MoveLeft()
    {
        if (playerPositionZ < 2)
        {
            // Move the player along the positive Z axis.
            transform.Translate(0, 0, moveDistance);
            // Increment the player position.
            playerPositionZ++;
        }
    }

    public void MoveRight()
    {
        if (playerPositionZ > 0)
        {
            // Move the player along the positive Z axis.
            transform.Translate(0, 0, -moveDistance);
            // Decrement the player position.
            playerPositionZ--;
        }
    }



    public void MoveJump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }
}
