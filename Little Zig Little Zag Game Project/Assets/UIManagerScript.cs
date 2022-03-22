using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    public static UIManagerScript instance;

    public GameObject titlePanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public Text score;
    public Text bestScore;

    public Text littleZigText;
    public Text littleZagText;
    public Text highScore;

    private void Awake(){
        if(instance == null){
            instance = this;
        }
    }

    void Start(){
        highScore.text = "HighScore: " + PlayerPrefs.GetInt("highScore").ToString();
    }

    public void GameStart(){

        tapText.SetActive(false);
        titlePanel.GetComponent<Animator>().Play("Panel");
        littleZigText.GetComponent<Animator>().Play("LittleZig");
        littleZagText.GetComponent<Animator>().Play("LittleZag");
        highScore.GetComponent<Animator>().Play("HighScore");
    }

    public void GameOver(){

        score.text = PlayerPrefs.GetInt("scoreKey").ToString();
        bestScore.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
    }

    public void Restart(){
        SceneManager.LoadScene(0);
    }
}
