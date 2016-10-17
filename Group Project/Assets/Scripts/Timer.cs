﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool finished = false;

	void Start ()
    {
        startTime = Time.time;
	
	}

	void Update ()
    {
        if (finished)
            return;
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f1");

        timerText.text = minutes + ":" + seconds;
	
	}

    public void finish()
    {
        finished = true;
        timerText.color = Color.red;
    }
}