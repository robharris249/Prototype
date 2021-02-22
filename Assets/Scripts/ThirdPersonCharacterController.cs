using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour {

    public float speed;
    public float rotationSpeed;
    public Rigidbody rb;
    public GameObject currentCheckpoint;
    public bool ableToJump;
    public GameObject menu;

    private void Start() {
    }

    // Update is called once per frame
    void Update() {
        playerMovement();
        playerControls();
    }

    void playerMovement() {

        if(Input.GetKey(KeyCode.W)) {
            rb.AddForce(transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(new Vector3(0, -1, 0) * speed/2 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S)) {
            rb.AddForce(-transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(new Vector3(0, 1, 0) * speed/2 * Time.deltaTime);
        }
    }

    void playerControls() {
        if (Input.GetKey(KeyCode.Return)) {
            Restart();
        }

        if(Input.GetKeyDown(KeyCode.Escape)) {
            menu.SetActive(!menu.activeSelf);
        }

        if(ableToJump && Input.GetKey(KeyCode.Space)) {
            rb.AddForce(new Vector3(0, 10, 0) * speed);
        }
    }

    private void OnTriggerEnter(Collider other) {

        if(other.tag == "Checkpoint") {
            if (currentCheckpoint == null) {
                currentCheckpoint = other.gameObject;
            } else {
                if (currentCheckpoint.GetComponent<Checkpoint>().order < other.GetComponent<Checkpoint>().order) {
                    currentCheckpoint = other.gameObject;
                }
            }
        }
        
        if(other.tag == "Death") {
            Restart();
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag == "Wall") {
            if(collision.collider.gameObject.GetComponent<Wall>().destructable == true) {
                Destroy(collision.collider.gameObject);
            }
        }

        if(collision.collider.tag == "Floor") {
            ableToJump = true;
        }
    }

    private void OnCollisionExit(Collision collision) {
        if(collision.collider.tag == "Floor") {
            ableToJump = false;
        }
    }
    
    void Restart() {
        if (currentCheckpoint == null) {
            transform.position = new Vector3(0f, 1f, 0f);
        } else {
            transform.position = currentCheckpoint.transform.position + new Vector3(0, 1.5f, 0);
        }
    }
}
