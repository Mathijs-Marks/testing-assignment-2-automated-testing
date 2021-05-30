using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float countDownTime;
    public bool timerIsRunning = false;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject gameInformation;
    [SerializeField] private Text score;
    [SerializeField] private Text distanceRun;
    [SerializeField] private Text health;
    [SerializeField] private Text coins;

    // Start is called before the first frame update
    void Start()
    {
        // Starts the timer automatically.
        countDownTime = 3f;
        timerIsRunning = true;

        ReferenceManager.Player.IsAlive = true;
        ReferenceManager.Player.IsControllable = false;
    }

    // Update is called once per frame
    void Update()
    {

        UpdateUI();

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

        if (ReferenceManager.Player.IsAlive)
        {
            gameOverScreen.SetActive(false);
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        ReferenceManager.Player.IsControllable = false;
        gameOverScreen.SetActive(true);

        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void UpdateUI()
    {
        score.text = "Score: \n" + ReferenceManager.Player.Score;
        distanceRun.text = "Distance \n" + ReferenceManager.Player.DistanceRun;
        health.text = "Health: " + ReferenceManager.Player.Health;
        coins.text = "Coins: " + ReferenceManager.Player.Coins;
    }
}
