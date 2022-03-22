using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheckerScript : MonoBehaviour
{
    private void OnTriggerExit(Collider other){
        
        if(other.gameObject.tag == "Ball"){
            Invoke("FallDown", 0.1f);
        }
    }

    void FallDown(){
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;

        Destroy(transform.parent.gameObject, 2f);
    }
}
