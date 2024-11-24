using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUps;
    public Transform[] spawnLocations;

    public GameObject player1;
    public GameObject player2;

    public int maxSpawns = 3;
    private float[] healthIntervals;

    void Start()
    {
        healthIntervals = new float[maxSpawns];

        // add each interval into the array (accept the last one which is 100)
        float step = 100 / (maxSpawns + 1); 
        float interval = step;

        for (int i = 0; i < maxSpawns; i++)
        {
            healthIntervals[i] = interval;
            interval += step;
        }
    }

    void Update()
    {
        float avgHealth = (player1.GetComponent<PlayerHealth>().currentHealth + player2.GetComponent<PlayerHealth>().currentHealth) / 2;

        // if the current average health is less than the last element in the array (the largest interval) -> spawn powerup. Then remove the last element in the array
        if (healthIntervals.Length > 0 && avgHealth <= healthIntervals[healthIntervals.Length - 1])
        {
            // spawn a random powerup in the powerUps array in a random position in the spawnLocations array
            Instantiate(powerUps[Random.Range(0, powerUps.Length)], spawnLocations[Random.Range(0, spawnLocations.Length)]);

            // remove the last element in the array
            healthIntervals = healthIntervals.SkipLast(1).ToArray();
        }
    }
}
