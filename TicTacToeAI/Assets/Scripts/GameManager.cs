using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static bool playerHasPlayed = false;
    public static bool gameOver = false;
    public static bool gameStarted = false;

    public static string winner = "";

    public GameObject gameTitle;
    public GameObject restartButton;
    public GameObject startButton;
    public GameObject gameStatusPanel;
    public TextMeshProUGUI gameWinner;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckWinner()
    {
        //If any winner display winner & make restart 

    }

    public void OnRetryGamePressed()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        gameStarted = true;
        restartButton.SetActive(true);
        startButton.SetActive(false);
        gameTitle.SetActive(false);
    }
}
