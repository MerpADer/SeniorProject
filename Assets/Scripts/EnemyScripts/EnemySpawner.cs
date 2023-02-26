using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<GameObject> enemyOptions;

    void Start()
    {
        GameObject chosenEnemy = enemyOptions[Random.Range(0, enemyOptions.Count)];
        Instantiate(chosenEnemy, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
