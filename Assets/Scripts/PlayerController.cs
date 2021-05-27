using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rigidbody; // Store a reference to the RigidBody required to use 3D physics.
    private Vector3 movement; // Vector3 variable to store the player's movement.
    [SerializeField] private float moveSpeed = 1f; // Floating point variable to store the player's movement speed.

    // Start is called before the first frame update
    void Start()
    {
        // Get and store a reference to the RigidBody component so that we can access it.
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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

    public void MoveLeft()
    {
        transform.Translate(0, 0, 1);
    }

    public void MoveRight()
    {
        transform.Translate(0, 0, -1);
    }



    public void MoveJump()
    {

    }
}
