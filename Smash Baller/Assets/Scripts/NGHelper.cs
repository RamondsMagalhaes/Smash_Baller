using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NGHelper : MonoBehaviour
{
    public io.newgrounds.core ngioCore;
    public GameObject content;
    // Start is called before the first frame update
    void Start()
    {
        ngioCore.onReady(() =>
        {
            ngioCore.checkLogin((bool isLogged) =>
            {
                if (isLogged)
                {
                    OnLoggedIn();
                }
                else
                {
                    RequestLogin();
                }
            });
        });
    }
    void OnLoggedIn()
    {
        io.newgrounds.objects.user player = ngioCore.current_user;
    }
    void RequestLogin()
    {
        ngioCore.requestLogin(OnLoggedIn, OnLoginFailed, OnLoginCancelled);
    }

    void OnLoginFailed()
    {
        io.newgrounds.objects.error error = ngioCore.login_error;
    }
    void OnLoginCancelled()
    {

    }

    public void UnlockMedal(int medal)
    {
        io.newgrounds.components.Medal.unlock medalUnlock = new io.newgrounds.components.Medal.unlock();
        medalUnlock.id = medal;
        medalUnlock.callWith(ngioCore);
        Debug.Log("Sent a message to the server to unlock a medal");
    }
    public void NGSubmitScore(int scoreboardID, int score)
    {
        io.newgrounds.components.ScoreBoard.postScore submitScore = new io.newgrounds.components.ScoreBoard.postScore();
        submitScore.id = scoreboardID;
        submitScore.value = score;
        submitScore.callWith(ngioCore);
        Debug.Log("Sent a message to the server to submit to the Scoreboard");
    }

    /*public void UpdateScoreboard(int scoreboard)
    {
        io.newgrounds.components.ScoreBoard.getScores getScores = new io.newgrounds.components.ScoreBoard.getScores();
        getScores.period = "D";
        getScores.callWith(ngioCore);
        io.newgrounds.objects.score score = new io.newgrounds.objects.score();
        score.user = getScores.user;
        
    }*/
    void OnScoresLoaded(io.newgrounds.results.ScoreBoard.getScores result)
    {
        if (result.success)
        {
            Debug.Log("Score loaded succefully");
            for (int i = 0; i < 100; i++)
            {
                string text = "" + (i+1);
                //Debug.Log("Scorelist count: "+result.scores.Count);
                if ( i < result.scores.Count)
                {
                    io.newgrounds.objects.score score = (io.newgrounds.objects.score)result.scores[i];
                    text += " " + score.user.name + " " + score.value;
                    Debug.Log(score.user.name + "" + score.value);
                }
                else
                {
                    text += " -";
                }
                content.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = text;
                
            }
        }
        else
        {
            Debug.Log("Can't Load Scoreboard");
        }
    }
    public void LoadScore(string period)
    {
        io.newgrounds.components.ScoreBoard.getScores getScores = new io.newgrounds.components.ScoreBoard.getScores();
        getScores.id = 10969;
        getScores.period = period;
        getScores.social = false;
        getScores.limit = 100;
        getScores.callWith(ngioCore, OnScoresLoaded);

    }

}
