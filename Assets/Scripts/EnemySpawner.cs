using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float period;
    public GameObject enemy;
    float timeUntilNextSpawn;
    void Start()
    {
        timeUntilNextSpawn = Random.Range(0, period);
    }

    void Update()
    {
        timeUntilNextSpawn -= Time.deltaTime;
        if (timeUntilNextSpawn <= 0.0f)
        {
            timeUntilNextSpawn = period;
            Instantiate(enemy, transform.position, transform.rotation);
        }
    }
}