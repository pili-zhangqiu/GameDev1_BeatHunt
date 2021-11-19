using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    // Global enemy wave number
    public static int waveNumber = 0;

    // For Bouncy Ball enemies
    public GameObject bouncySpawnee;
    public bool stopBouncySpawn = false;

    public float bouncySpawnTime = 1;     // Start InvokeRepeating() at second 0
    public float bouncySpawnDelay = 29;   // Invoke the method every 30 seconds

    // For Ray Swiper enemies
    public static bool stopSpawningRowRay = true;
    public static bool stopSpawningColRay = true;

    private int intCurrBeat = 0;
    public RowRayEnemyController RowRayEnemy;   // Reference the script, plus its variables and method
    public ColRayEnemyController ColRayEnemy;   // Reference the script, plus its variables and method

    void Start()
    {
        InvokeRepeating("SpawnBouncyBall", bouncySpawnTime, bouncySpawnDelay);
    }

    void Update()
    {
        // Ray cast only starts after 3rd beat
        if (intCurrBeat <= 3)
        {
            intCurrBeat = Mathf.FloorToInt(ConductorController.songPositionInBeats);                // Only check the beat position until the 3rd beat

            if (intCurrBeat == 3)
            {
                stopSpawningRowRay = false;
            }
        }

        if (waveNumber == 1)
        {
            RowRayEnemy.spawnBeatDelay = 6;
        }

        else if (waveNumber == 2)
        {
            RowRayEnemy.spawnBeatDelay = 5;
        }

        else if (waveNumber == 3)
        {
            stopSpawningColRay = false;
            RowRayEnemy.spawnBeatDelay = 4;
            ColRayEnemy.spawnBeatDelay = 4;
        }

        else if (waveNumber == 4)
        {
            RowRayEnemy.spawnBeatDelay = 3;
            ColRayEnemy.spawnBeatDelay = 3;
        }

    }

    public void SpawnBouncyBall()
    {
        // Instantiate bouncySpawnee gameobject
        Vector3 spawnStartPos = new Vector3(Random.Range(-9f, 21f), 1, Random.Range(-13f, 13f));
        

        Instantiate(bouncySpawnee, spawnStartPos, Quaternion.identity);

        // Update enemy wave number
        waveNumber = waveNumber + 1;

        // After 4 waves of enemies, stop the spawning routine
        if (waveNumber >= 4)
        {
            stopBouncySpawn = true;
        }

        if (stopBouncySpawn == true)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
