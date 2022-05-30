using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    // control variables
    private float spawnRatio = 1;
    private float spawnDelay = 3;
    private float powerUpRatio;
    private float zRange = 7;
    [SerializeField]
    private float xRange = 10; 
    // objects to spawn
    public GameObject[] enemyPrefabs;
    public GameObject powerUp;
    


    // spawn random enemies in random positions
    void SpawnEnemies()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 enemeyPos = new Vector3(GenerateRandomSpawnPosition(), enemyPrefabs[enemyIndex].transform.position.y, zRange);
        Instantiate(enemyPrefabs[enemyIndex], enemeyPos, enemyPrefabs[enemyIndex].transform.rotation);
    }


    // method to generate a random spawn position
    float GenerateRandomSpawnPosition()
    {
        float xSpawnPos = Random.Range(-xRange, xRange);
        return xSpawnPos;
    }

    // start enemy spawning
    public void StartSpawning()
    {
        InvokeRepeating(nameof(SpawnEnemies), spawnDelay, spawnRatio);
    }
    
    public void StopSpawning()
    {
        CancelInvoke();
    }
}
