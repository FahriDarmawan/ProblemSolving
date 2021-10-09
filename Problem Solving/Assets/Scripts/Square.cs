using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreManager.Instance.IncreaseScore(1);
        Destroy(gameObject);
    }
}
