using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour {

    public float speed;
    public float rotationSpeed;
    public Rigidbody rb;
    public GameObject currentCheckpoint;

    private void Start() {
        rotationSpeed = 5 * speed;
    }

    // Update is called once per frame
    void Update() {
        playerMovement();
        playerControls();
    }

    void playerMovement() {
        /*
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0, ver).normalized * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
        */

        if(Input.GetKey(KeyCode.W)) {
            rb.AddForce(transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(new Vector3(0, -1, 0) * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S)) {
            rb.AddForce(-transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(new Vector3(0, 1, 0) * rotationSpeed * Time.deltaTime);
        }
    }

    void playerControls() {
        if (Input.GetKey(KeyCode.Space)) {
            if (currentCheckpoint == null) {
                transform.position = new Vector3(0f, 1f, 0f);
            } else {
                transform.position = currentCheckpoint.transform.position + new Vector3(0, 1.5f, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(currentCheckpoint == null) {
            currentCheckpoint = other.gameObject;
        } else {
            if(currentCheckpoint.GetComponent<Checkpoint>().order < other.GetComponent<Checkpoint>().order) {
                currentCheckpoint = other.gameObject;
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag == "Wall") {
            if(collision.collider.gameObject.GetComponent<Wall>().destructable == true) {
                Destroy(collision.collider.gameObject);
            }
        }
    }
}
