﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region Properties

    public bool IsControllable
    {
        get { return isControllable; }
        set { isControllable = value; }
    }

    public int Coins
    {
        get { return coins; }
        set { coins = value; }
    }

    #endregion

    #region General Values

    private Rigidbody rigidbody; // Store a reference to the RigidBody required to use 3D physics.
    private bool isControllable;
    [SerializeField] private int coins;

    #endregion

    #region Movement Values

    private float moveSpeed; // Floating point variable to store the player's movement speed.
    [SerializeField] private float jumpPower = 5f;
    [SerializeField] private float moveDistance = 1;
    [SerializeField] private int playerPositionZ = 1;
    [SerializeField] private int playerPositionY = 1;

    #endregion

    #region Jump Values

    private float jumpTimer = 0f;
    private float jumpCooldown = 1f;

    #endregion

    #region Damage Values

    private int health;
    [SerializeField] private float moveSpeedNormal = 0.01f;
    [SerializeField] private float moveSpeedSlowed = 0.001f;
    private float slowTimer = 0f;
    private float slowCooldown = 0.7f;

    #endregion


    private void Awake()
    {
        ReferenceManager.Player = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Get and store a reference to the RigidBody component so that we can access it.
        rigidbody = GetComponent<Rigidbody>();
        health = 3;
        coins = 0;
        slowTimer = slowCooldown;
        moveSpeed = moveSpeedNormal;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isControllable)
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

            if (jumpTimer > 0f)
            {
                jumpTimer -= Time.deltaTime;
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                MoveJump();
                Debug.Log("I'm jumping");
                jumpTimer = jumpCooldown;
            }
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
        rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            Debug.Log("You done fucked up");
        }
    }

    public void TakeDamage()
    {
        health--;

        if (health <= 0)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        StartCoroutine(SlowMovement());
    }

    public IEnumerator SlowMovement()
    {
        moveSpeed = moveSpeedSlowed;
        yield return new WaitForSeconds(0.5f);
        moveSpeed = moveSpeedNormal;
    }
}
