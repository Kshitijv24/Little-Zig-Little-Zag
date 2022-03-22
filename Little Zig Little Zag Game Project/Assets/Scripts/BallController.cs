using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    AudioSource sound;

    public GameObject partical;

    [SerializeField]
    private float speed;

    Rigidbody rb;
    bool started = false;
    bool gameOver = false;

    private void Awake(){

        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
    }

    void Update(){

        if (!started){
            if (Input.GetMouseButtonDown(0)){
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                GameManagerScript.instance.StartGame();
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if(!Physics.Raycast(transform.position, Vector3.down, 1f)){
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);

            Camera.main.GetComponent<CameraFollow>().gameOver = true;

            GameManagerScript.instance.GameOver();
        }

        if (Input.GetMouseButtonDown(0) && !gameOver){
            SwitchDirection();
        }
    }

    void SwitchDirection(){

        if(rb.velocity.x > 0){
            rb.velocity = new Vector3(0, 0, speed);
        }
        else if(rb.velocity.z > 0){
            rb.velocity = new Vector3(speed, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other){
        
        if(other.gameObject.tag == "Diamond"){

            GameObject particalGameObject = Instantiate(partical, other.gameObject.transform.position, Quaternion.identity) as GameObject;

            Destroy(other.gameObject);
            sound.Play();
            Destroy(particalGameObject, 0.8f);
        }
    }
}
