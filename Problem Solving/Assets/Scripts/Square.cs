using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    [SerializeField] private Scene scene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(scene == Scene.SIX)
        {
            //doing nothing
        }

        if(scene == Scene.SEVEN)
        {
            ScoreManager.Instance.IncreaseScore(1);
            Destroy(gameObject);
        }

        if(scene == Scene.EIGHT)
        {
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
            GetComponent<BoxCollider2D>().enabled = !GetComponent<Renderer>().enabled;
            ScoreManager.Instance.IncreaseScore(1);
            StartCoroutine(DelayedSpawn());
        }

        if(scene == Scene.NINE)
        {
            if(collision.gameObject.tag == "Player")
            {
                GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
                GetComponent<BoxCollider2D>().enabled = !GetComponent<Renderer>().enabled;
                StartCoroutine(DelayedSpawn());
            }
        }
    }

    private IEnumerator DelayedSpawn()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
        SquareSpawner.Instance.SpawnSquare();
    }
}

public enum Scene
{
    SIX,
    SEVEN,
    EIGHT,
    NINE
}
