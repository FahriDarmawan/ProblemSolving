using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    #region Singleton

    private static SquareSpawner _instance = null;

    public static SquareSpawner Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<SquareSpawner>();
                if(_instance == null)
                {
                    Debug.LogError("Fatal Error : SquareSpawner not Found");
                }
            }
            return _instance;
        }
    }

    #endregion

    public GameObject squarePrefabs;

    int maxSquare = 10;

    float randomX;
    float randomY;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i <= Random.Range(1, maxSquare); i++)
        {
            SpawnSquare();
        }
    }

    public void SpawnSquare()
    {
        randomX = Random.Range(-8, 8);
        randomY = Random.Range(-4, 4);
        GameObject newSquare = Instantiate(squarePrefabs);
        newSquare.transform.position = new Vector2(randomX, randomY);
    }
}
