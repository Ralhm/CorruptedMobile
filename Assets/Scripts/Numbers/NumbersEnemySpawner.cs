using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbersEnemySpawner : MonoBehaviour
{


    public int SpawnedEnemies;
    
    public int SpawnRate;

    //after spawning how many enemies do corrupted enemies start spawning?
    public int CorruptedEnemySpawnNum;


    public List<NumbersEnemy> EnemyPrefabs;


    public NumbersEnemy CorruptedEnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        SpawnedEnemies++;

        if (SpawnedEnemies >= CorruptedEnemySpawnNum)
        {
            Instantiate(CorruptedEnemyPrefab, transform.position, transform.rotation);
        }
        else
        {

            Debug.Log(EnemyPrefabs.Count);

            Instantiate(EnemyPrefabs[Random.Range(0, EnemyPrefabs.Count)], transform.position, transform.rotation);
        }
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnRate);

            SpawnEnemy();
        }
    }
}
