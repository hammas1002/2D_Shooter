using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave_spawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public Enemy[] enemies;
        public int count;
        public float timeBtwSpawns;
    }

    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBtwWaves;

    private Wave currentWave;
    private int currentWaveIndex;
    private Transform player;

    private bool finishedSpawning;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(startNextWave(currentWaveIndex));
    }

    IEnumerator startNextWave(int index)
    {
        yield return new WaitForSeconds(timeBtwWaves);
        StartCoroutine(spawnWave(index));
    }
    IEnumerator spawnWave(int index)
    {
        currentWave = waves[index];
        for (int i=0;i<currentWave.count;i++)
        {
            if (player==null)
            {
                yield break;
            }
            Enemy randomEnemy = currentWave.enemies[Random.Range(0,currentWave.enemies.Length)];
            Transform randomSpot = spawnPoints[Random.Range(0,spawnPoints.Length)];
            Instantiate(randomEnemy,randomSpot.position,randomSpot.rotation);

            if (i==currentWave.count-1)
            {
                finishedSpawning = true;
            }
            else { finishedSpawning = false; }


            yield return new WaitForSeconds(currentWave.timeBtwSpawns);
        }
    }
    private void Update()
    {
        if (finishedSpawning && GameObject.FindGameObjectsWithTag("Enemy").Length==0)
        {
            finishedSpawning = false;
            if (currentWaveIndex+1<waves.Length)
            {
                currentWaveIndex += 1;
                StartCoroutine(startNextWave(currentWaveIndex));
            }
            else
            {
                Debug.Log("All Waves Survived!");
            }
        }
    }
}
