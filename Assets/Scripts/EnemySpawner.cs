using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 5, time = 1.5f;
    //ARRAY
    public GameObject[] enemies;
    private Character value;
    public GameObject getcharacter;
    void Update()
    {
        value = getcharacter.GetComponent<Character>();
        //IF-ELSE
        if (value.startcheck == true)
        {
            StartCoroutine(SpawnAnEnemy());
            value.startcheck = false;
        }
    }

    IEnumerator SpawnAnEnemy()
    {
        Vector2 spawnPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnEnemy());
    }
}
