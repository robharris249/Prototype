using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItems : MonoBehaviour {

    public bool canHold = true;
    public GameObject item;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (!canHold) {
                Drop();
            } else {
                PickUp();
            }
        }

        if(!canHold && item) {
            item.transform.position = gameObject.transform.position + (transform.forward * 2);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Item") {
            if(!item) {
                item = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Item") {
            if(canHold) {
                item = null;
            }
        }
    }

    void PickUp() {
        if(!item) {
            return;
        }

        item.transform.SetParent(gameObject.transform);

        item.GetComponent<Rigidbody>().useGravity = false;

        item.transform.localRotation = transform.rotation;

        item.transform.position = gameObject.transform.position + (transform.forward * 2);

        canHold = false;
    }

    void Drop() {
        if(!item) {
            return;
        }

        item.GetComponent<Rigidbody>().useGravity = true;

        item = null;

        transform.GetChild(2).parent = null;
        canHold = true;
    }
}
