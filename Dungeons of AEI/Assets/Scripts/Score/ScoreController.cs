using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
