using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region Singleton

    private static EnemySpawner _instance = null;

    public static EnemySpawner Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<EnemySpawner>();
                if(_instance == null)
                {
                    Debug.LogError("Fatal Error : EnemySpawner not Found");
                }
            }
            return _instance;
        }
    }

    #endregion


    public GameObject enemyPrefabs;

    int maxEnemy = 5;

    float randomX;
    float randomY;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= Random.Range(1, maxEnemy); i++)
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        randomX = Random.Range(-8, 8);
        randomY = Random.Range(-4, 4);

        GameObject newEnemy = Instantiate(enemyPrefabs);
        newEnemy.transform.position = new Vector2(randomX, randomY);
    }
}
