using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UI : MonoBehaviour {

    public GameObject controls;
    public GameObject playButton;

    public void Play() {
        controls.SetActive(true);
        playButton.SetActive(false);
    }

    public void StartGame() {
        SceneManager.LoadScene("Level");
    }
}
