using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float startTime;
    private bool timerStarted = false;

    private void Start()
    {
        StartTimer();
    }

    public void StartTimer()
    {
        startTime = Time.time;
        timerStarted = true;
    }

    public void StopTimer()
    {
        SceneManager.LoadScene("GameWin");
    }

    private void Update()
    {
        if (timerStarted)
        {
            float t = Time.time - startTime;
        }
    }
}

