using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText, gameOverScore;
    public GameObject titleMenu, pauseScreen, gameOverScreen;
    NGHelper ngHelper;
    public bool isGameActive,isPause;
    private int score, bumps, kills;
    
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;
        score = 0;
        ngHelper = FindObjectOfType<NGHelper>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && isGameActive)
        {
            ChangePause();
        }
    }

    void ChangePause()
    {
        if (isPause){
            isPause = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            isPause = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void StartGame()
    {
        isGameActive = true;
        titleMenu.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        int bestScore = PlayerPrefs.GetInt("Score");
        if (score > bestScore)
        {
            PlayerPrefs.SetInt("Score", score);
        }
        isGameActive = false;
        gameOverScreen.SetActive(true);
        scoreText.gameObject.SetActive(false);
        gameOverScore.text = @"Bumps: " + bumps + "\n" +
                            "Kills: " + kills + "\n" +
                            "Score: " + score + "\n" +
                            "Best: " + PlayerPrefs.GetInt("Score");
        if (score >= 1000)
        {
            ngHelper.UnlockMedal(65912);
        }
        ngHelper.NGSubmitScore(10969, score);
        ngHelper.LoadScore("D");
    }

    public void UpdateScore(int score)
    {
        this.score += score;
        scoreText.text = "Score: " + this.score;
        if (score == 1)
        {
            bumps++;
        }
        else
        {
            kills++;
        }
    }
}
