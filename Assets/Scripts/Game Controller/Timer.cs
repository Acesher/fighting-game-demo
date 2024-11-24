using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public float currentTime;
    public float gameDuration = 180f;

    [SerializeField] Text countdownText;
    void Start()
    {
        currentTime = gameDuration;
    }
    void Update()
    {
        currentTime -= 1 * Time.deltaTime; // reduce time by each frame
        countdownText.text = currentTime.ToString("0"); // display the converted time (only decimal)

        if (currentTime <= 0) // when time is over, who has the less health loses
        {
            currentTime = 0;
            float player1Health = player1.GetComponent<PlayerHealth>().currentHealth;
            float player2Health = player2.GetComponent<PlayerHealth>().currentHealth;

            string deathPlayer;

            if (player1Health > player2Health) deathPlayer = player2.name;
            else if (player2Health > player1Health) deathPlayer = player1.name;
            else deathPlayer = "Draw!";

            FindObjectOfType<GameController>().GameOver(deathPlayer);
        }
    }
}
