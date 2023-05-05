using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timer;
    private float time = 5 * 60;
    public GameObject gameOver;
    public EventManager points;

    // private bool isTimerRunning = false;
    // private float startTime;
    // private float timeElapsed;

    //public Text timerText;

    private bool startTimer = false;
    // Start is called before the first frame update
    public void Start()
    {
        timer = gameObject.GetComponentInChildren<Text>();
        UpdateTimer();
    }

    //michaels code
    // Update is called once per frame
    void Update()
    {
        if (startTimer && time > 0.0f)
        {
            time -= Time.deltaTime;
            UpdateTimer();
        }
        else if (startTimer && time < 0.0f)
        {
            EndGame();
            StartTimer(false);
        }
    }

    void UpdateTimer()
    {

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timer.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");

    }

    public void StartTimer(bool value)
    {
        startTimer = value;
    }

    public void ResetTimer()
    {
        time = 5 * 60;
        StartTimer(true);
    }

    public void EndGame()
    {
        gameOver.SetActive(true);
        gameOver.GetComponent<Text>().text = "The Winner is " + (points.returnPoints() > points.threshold ? "Marco" : "Polo");
        //GameObject.Find("networking").GetComponent<EventManager>().SendGameOver();
    }


    // private void StartTimer()
    // {
    //     isTimerRunning = true;
    //     startTime = Time.time;
    // }

    // private void ResetTimer()
    // {
    //     isTimerRunning = false;
    // }

    // private void Update()
    // {
    //     if (isTimerRunning)
    //     {
    //         timeElapsed = Time.time - startTime;

    //         string minutes = Mathf.Floor(timeElapsed / 60).ToString("00");
    //         string seconds = (timeElapsed % 60).ToString("00");
    //         string milliseconds = ((timeElapsed * 100) % 100).ToString("00");

    //         timerText.text = $"{minutes}:{seconds}:{milliseconds}";
    //     }
    // }

//michales code
    
}