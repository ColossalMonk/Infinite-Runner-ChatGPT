using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static Score instance;

    public float scorePerSecond = 1f; // The score per second the player stays alive
    private float currentScore = 0f; // The current score
    private float startTime; // The time the player started playing
    public TextMeshProUGUI timeAliveText; // Reference to the UI text element to display the time alive

    public string sceneToLoad;

    private void Awake()
    {
        instance = this;    
    }

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (PlayerMovement.instance.isPlayerAlive)
        {
            currentScore += scorePerSecond * Time.deltaTime;
            float timeAlive = Time.time - startTime;
            timeAliveText.text = "Time Alive: " + timeAlive.ToString("F2"); // updating the text every frame
        }
    }

    public float GetCurrentScore()
    {
        return currentScore;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
