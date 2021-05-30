using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishObstacleCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().HasWon = true;
            Destroy(gameObject);
        }
    }
}
