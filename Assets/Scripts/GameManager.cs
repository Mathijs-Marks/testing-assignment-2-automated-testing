using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float countDownTime;
    public bool timerIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        // Starts the timer automatically.
        countDownTime = 3f;
        timerIsRunning = true;

        ReferenceManager.Player.IsControllable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (countDownTime > 0)
            {
                countDownTime -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Game started!");
                countDownTime = 0;
                timerIsRunning = false;
                ReferenceManager.Player.IsControllable = true;
            }
        }
    }
}
