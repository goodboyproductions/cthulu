﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame() {
        Application.Quit();
    }

    public void BackToMain() {
        //basement is 0 which is main screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
