using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFormSpawnerScript : MonoBehaviour
{
    public GameObject platform;
    public GameObject diamonds;
    public bool gameOver;

    Vector3 lastPos;
    float size;

    void Start(){

        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;

        for(int i = 0; i < 40; i++){
            SpawnPlatfroms();
        }
    }

    public void StartSpawningPlatforms(){
        InvokeRepeating("SpawnPlatfroms", 1f, 0.2f);
    }   

    void Update(){

        if (GameManagerScript.instance.gameOver == true){
            CancelInvoke("SpawnPlatfroms");
        }
    }

    void SpawnPlatfroms(){

        int random = Random.Range(0, 6);

        if(random < 3){
            SpawnX();
        }
        
        else if( random >= 3){
            SpawnZ();
        }
    }

    void SpawnX(){

        Vector3 pos = lastPos;
        pos.x += size;

        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int randomDimondsX = Random.Range(0, 6);
        
        if(randomDimondsX == 1){
            Instantiate(diamonds, new Vector3(pos.x, pos.y + 1, pos.z), diamonds.transform.rotation);
        }
    }

    void SpawnZ(){

        Vector3 pos = lastPos;
        pos.z += size;

        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int randomDimondsY = Random.Range(0, 6);

        if(randomDimondsY == 2){
            Instantiate(diamonds, new Vector3(pos.x, pos.y + 1, pos.z), diamonds.transform.rotation);
        }
    }
}
