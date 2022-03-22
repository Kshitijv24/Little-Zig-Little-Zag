using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;

    public bool gameOver;

    private void Awake(){
        if(instance == null){
            instance = this;
        }
    }

    void Start(){
        gameOver = false;
    }

    public void StartGame(){
        
        UIManagerScript.instance.GameStart();
        ScoreManagerScript.instance.StartScore();

        GameObject.Find("PlatFormSpawner").GetComponent<PlatFormSpawnerScript>().StartSpawningPlatforms();
    }

    public void GameOver(){

        UIManagerScript.instance.GameOver();
        ScoreManagerScript.instance.StopScore();

        gameOver = true;
    }
}
