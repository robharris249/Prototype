using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSwitch : MonoBehaviour {

    public GameObject door;

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag == "Item") {
            door.GetComponent<Door>().isActive = true;
            GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
        
    }

    private void OnCollisionExit(Collision collision) {
        if(collision.collider.tag == "Item") {
            door.GetComponent<Door>().isActive = false;
            GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        
    }
}
