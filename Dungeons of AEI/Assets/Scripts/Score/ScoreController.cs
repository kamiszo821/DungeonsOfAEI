using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Scoreboard control script, gets info about coin picking and increments the final score.
 * Saves info about the score even after changing the scene.
 */
public class ScoreController : MonoBehaviour
{
    private int score = 0;
    private static ScoreController instance = null;
    [SerializeField]
    public Text scoreText;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (this != instance)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnEnable()
    {
        CoinPick.picked += AddScore;
    }

    private void OnDisable()
    {
        CoinPick.picked -= AddScore;
    }

    //increment score
    public void AddScore()
    {
        score++;
    }

    //update actual score on scoreboard
    public void UpdateScore()
    {
        scoreText.text = "ECTS: " + score + "/30";
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }
}
