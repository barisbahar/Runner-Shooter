using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public static GameOver instance;
    void Start()
    {
        gameObject.SetActive(false);
    }
    void Awake()
    {
        instance = this;
    }
    public void Setup(float recor)
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        pointsText.text = "YOUR SCORE\n" + recor;
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Time.timeScale = 1;
        }
    }
}
