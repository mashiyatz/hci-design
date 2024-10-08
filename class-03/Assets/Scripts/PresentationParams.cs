using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PresentationParams : MonoBehaviour
{
    public string[] presenters;
    public Color startColor;
    public Color endColor;
    private List<string> presentersList;
    [SerializeField]
    private TextMeshProUGUI nameTextbox;
    [SerializeField]
    private TextMeshProUGUI timeRemainingTextbox;

    [SerializeField]
    private TextMeshProUGUI startButtonTextbox;
    [SerializeField]
    private TextMeshProUGUI pauseButtonTextbox;

    public float timeLimit;
    private float timeRemaining;
    private bool isPaused;
    private string currentPresenter;
    private AudioSource audioSource;

    void Start()
    {
        presentersList = new List<string>(presenters);
        timeRemaining = timeLimit;
        timeRemainingTextbox.text = GetTimeInFormat(timeRemaining);
        nameTextbox.text = "Next Presenter!";
        isPaused = true;
        audioSource = GetComponent<AudioSource>();
    }

    public void StartPresentation()
    {
        if (!isPaused) Reset();
        else
        {
            presentersList.Remove(currentPresenter);
            timeRemaining = timeLimit;
            isPaused = false;
            startButtonTextbox.text = "Restart";
            pauseButtonTextbox.text = "Pause";
        }
    }
    public void PausePresentation()
    {
        if (timeRemaining == timeLimit) { 
            StartPresentation();
            return;  
        }
        isPaused = !isPaused;
        pauseButtonTextbox.text = isPaused ? "Play" : "Pause";
    }

    public void SelectRandomNameFromList()
    {
        currentPresenter = presentersList[Random.Range(0, presentersList.Count)];
        nameTextbox.text = currentPresenter;
    }

    void Update()
    {
        if (!isPaused)
        {
            timeRemaining -= Time.deltaTime;
            Camera.main.backgroundColor = Color.Lerp(startColor, endColor, 1 - timeRemaining / timeLimit);
            if (timeRemaining <= 0)
            {
                audioSource.Play();
                Reset();
            }
            timeRemainingTextbox.text = GetTimeInFormat(timeRemaining);
            
        }
    }

    private void Reset()
    {
        isPaused = true;
        nameTextbox.text = "Next Presenter!";
        startButtonTextbox.text = "Start";
        pauseButtonTextbox.text = "Pause";
        timeRemaining = timeLimit;
        timeRemainingTextbox.text = GetTimeInFormat(timeRemaining);
        Camera.main.backgroundColor = startColor;
    }

    private string GetTimeInFormat(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        string timeText = $"{minutes:00}:{seconds:00}";
        return timeText;
    }
}
