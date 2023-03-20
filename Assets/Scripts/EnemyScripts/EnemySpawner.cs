using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<GameObject> enemyOptions;

    private LevelPicker levelPicker;

    private Transform player;

    void Start()
    {
        levelPicker = FindObjectOfType<LevelPicker>();
        player = FindObjectOfType<Movement>().transform;
    }

    private void Update()
    {
        if (Mathf.Abs(player.position.x - gameObject.transform.position.x) <= 4f)
        {
            GameObject chosenEnemy = enemyOptions[Random.Range(0, enemyOptions.Count)];
            levelPicker.enemies.Add(Instantiate(chosenEnemy, gameObject.transform.position, Quaternion.identity));
            Destroy(gameObject);
        }
    }

}
