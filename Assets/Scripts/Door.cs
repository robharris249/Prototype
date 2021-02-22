using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public bool isActive = false;

    // Update is called once per frame
    void Update() {
        if(isActive && transform.position.y < 8) {
            transform.position = new Vector3(transform.position.x,
                                               transform.position.y + Time.deltaTime,
                                               transform.position.z);
        
        }
        if(!isActive && transform.position.y > 3) {
            transform.position = new Vector3(transform.position.x,
                                               transform.position.y - Time.deltaTime,
                                               transform.position.z);
        }
    }
}
