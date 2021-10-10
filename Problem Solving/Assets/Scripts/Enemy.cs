using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector2 randomPoint;
    float randomX, randomY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMoveRandom();
    }

    void EnemyMoveRandom()
    {
        randomPoint = new Vector2(randomX, randomY);

        transform.position = Vector2.MoveTowards(transform.position, randomPoint, 1 * Time.deltaTime);

        if(Vector2.Distance(transform.position, randomPoint) <= 0)
        {
            randomX = Random.Range(-8, 8);
            randomY = Random.Range(-4, 4);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
            GetComponent<BoxCollider2D>().enabled = !GetComponent<BoxCollider2D>().enabled;
            ScoreManager.Instance.IncreaseScore(1);
            StartCoroutine(DelayedEnemySpawn());
        }
    }

    IEnumerator DelayedEnemySpawn()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
        EnemySpawner.Instance.SpawnEnemy();
    }
}
