using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //varijable
    public GameObject bigBoi;
    GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public GameObject[] enemiesArray;
    private float timeToSpawn = 1f, timePassed = 0f;
    private int numberOfEnemies = 0;

    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        timePassed += Time.deltaTime;

        if(timePassed >= timeToSpawn)
        {
            SpawnEnemy();
            timePassed = 0f;
        }
    }
    void SpawnEnemy()
    {
        int chooseSpawn = Mathf.RoundToInt(UnityEngine.Random.Range(0f, spawnPoints.Length - 1)); //odaberi indeks lokacije za spawn iz arraya lokacija

        if (numberOfEnemies != 0 && numberOfEnemies % 10 == 0)
        {
            Instantiate(bigBoi, spawnPoints[chooseSpawn].position, Quaternion.identity);
        }
        else
        {
            int chooseEnemy = Mathf.RoundToInt(UnityEngine.Random.Range(0f, enemiesArray.Length - 1)); //odaberi indeks neprijatelja za spawn iz arraya neprijatelja
            enemyPrefab = enemiesArray[chooseEnemy]; //odaberi prefab neprijatelja
            Instantiate(enemiesArray[chooseEnemy], spawnPoints[chooseSpawn].position, Quaternion.identity); //instanciraj neprijatelja
        }
        numberOfEnemies++;
    }
}
