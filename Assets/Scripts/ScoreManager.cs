using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance {get; private set;}

    bool gameStart;
    
    public int actualScore;
    float timeRemaining;

    [SerializeField]TextMeshProUGUI scoreText, timePanel, scoreResult;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] RandomTarget targetSpawner;

    
    private void Awake() {

        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }
    
    private void FixedUpdate() {
        
        if(gameStart)
        {
            timeRemaining -= Time.fixedDeltaTime;
            timePanel.text = "Quedan: " + (int)timeRemaining + " seg";
        }

        if(timeRemaining <= 0 && gameStart)
        {
            gameOverPanel.SetActive(true);
            scoreResult.text = "¡Obtuviste: " + actualScore + " puntos!";
            targetSpawner.enabled = false;
            gameStart = false;
        }
    }

    public void UpdateScore(int scoreGained)
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        actualScore += scoreGained;
        scoreText.text = actualScore + " Puntos"; 
    }

    public void StartGame()
    {
        timeRemaining = Random.Range(44, 120);
        gameStart = true;
    }
    public void ResetLoop()
    {
        actualScore = 0;
        scoreText.text = actualScore + " Puntos"; 
    }
}
