using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private int score = 0;

    [SerializeField]
    public Text scoreText;

    private void OnEnable()
    {
        CoinPick.picked += AddScore;
    }

    public void AddScore()
    {
        score++;
    }

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
