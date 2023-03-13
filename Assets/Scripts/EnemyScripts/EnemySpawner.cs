using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<GameObject> enemyOptions;

    private LevelPicker levelPicker;

    void Start()
    {
        levelPicker = FindObjectOfType<LevelPicker>();

        GameObject chosenEnemy = enemyOptions[Random.Range(0, enemyOptions.Count)];
        levelPicker.enemies.Add(Instantiate(chosenEnemy, gameObject.transform.position, Quaternion.identity));
        Destroy(gameObject);
    }

}
