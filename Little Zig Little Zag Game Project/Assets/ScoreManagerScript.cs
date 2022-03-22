using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerScript : MonoBehaviour
{
    public static ScoreManagerScript instance;

    public int score;
    public int highScore;

    private void Awake(){
        if(instance == null){
            instance = this;
        }
    }

    void Start(){
        score = 0;
    }

    void IncrementScore(){
        score++;
        PlayerPrefs.SetInt("scoreKey", score);
    }

    public void StartScore(){
        InvokeRepeating("IncrementScore", 0.1f, 0.5f);
    }

    public void StopScore(){
        CancelInvoke("IncrementScore");
        PlayerPrefs.SetInt("scoreKey", score);

        if (PlayerPrefs.HasKey("highScore")){

            if(score > PlayerPrefs.GetInt("highScore")){
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        
        else{
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
