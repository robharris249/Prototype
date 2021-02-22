using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour {

    public void StartGame() {
        SceneManager.LoadScene("Level");
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume() {
        gameObject.SetActive(false);
    }
}
