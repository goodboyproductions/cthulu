﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countDown : MonoBehaviour 
{
	[SerializeField] private Text uiText;
	[SerializeField] private Text uiTextWinLose;
	[SerializeField] private float mainTimer;
	[SerializeField] private GameObject winLoseScreen;
	
	private float timer;
	private bool canCount = true;
	private bool doOnce = false;
    private bool win = true;
	
	void Start()
	{

        winLoseScreen.SetActive(false);
		timer = mainTimer;
	}
	
	void Update()
	{

        if (GameObject.FindGameObjectsWithTag("AI").Length == 0) {
            timer = 0f;
            canCount = false;
            win = false;
        }

        if (timer > 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F");
        }
        else if (timer <= 0.0f && !doOnce && win)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0.00";
            winLoseScreen.SetActive(true);
            uiTextWinLose.text = "YOU WIN";
            timer = 0.0f;
            Time.timeScale = 0.0f;
            FindObjectOfType<AudioManagement>().Stop("Theme");
            FindObjectOfType<AudioManagement>().Play("Victory");
        }
        else {
            winLoseScreen.SetActive(true);
            uiTextWinLose.text = "YOU LOSE";
            Time.timeScale = 0.0f;
        }
	}

}