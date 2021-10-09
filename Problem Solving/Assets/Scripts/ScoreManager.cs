using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    #region Singleton

    private static ScoreManager _instance = null;

    public static ScoreManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<ScoreManager>();
                if(_instance == null)
                {
                    Debug.LogError("Fatal Error : ScoreManager not found");
                }
            }
            return _instance;
        }
    }

    #endregion

    int score = 0;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        ResetCurrentScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetCurrentScore()
    {
        score = 0;
    }

    public void IncreaseScore(int scoreCount)
    {
        score += scoreCount;
        scoreText.text = score.ToString();
    }
}
