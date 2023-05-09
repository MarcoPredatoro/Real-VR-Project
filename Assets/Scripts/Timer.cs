using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private Text timer;
    private float time = 2 * 60;
    public GameObject gameOver;
    public EventManager points;
    public AudioClip win;
    public AudioClip lose;
    

    private bool startTimer = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponentInChildren<Text>();
        UpdateTimer();
        gameOver.SetActive(false);
    }

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
        time = 2 * 60;
        StartTimer(true);
        gameOver.SetActive(false);
    }

    public void EndGame()
    {
        //GameObject.Find("Main").GetComponent<AudioSource>().Pause();
        gameOver.SetActive(true);
        // gameOver.GetComponentInChildren<Text>().text = "The Winner is " + (points.returnPoints() < points.threshold ? "Marco" : "Polo");
        //GameObject.Find("networking").GetComponent<EventManager>().SendGameOver();
        if (points.returnPoints() < points.threshold)
        {
            timer.text = "The Winner is Marco";
            gameOver.GetComponentInChildren<Text>().text = "The Winner is Marco";
            GetComponentInChildren<AudioSource>().PlayOneShot(win);
        }
        else
        {
            timer.text = "The Winner is Polo";
            gameOver.GetComponentInChildren<Text>().text = "The Winner is Polo";
            GetComponentInChildren<AudioSource>().PlayOneShot(lose);
        }
    }
}