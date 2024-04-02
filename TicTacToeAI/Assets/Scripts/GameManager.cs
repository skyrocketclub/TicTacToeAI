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
    public static bool updateGameState = false;
    public static int availableSlots;
    public static bool findFavorableSlot = false;
    public static int favorableSlot = 1;
   
    public static bool favorableSlotFound = false;
    public static bool gameStateUpdated = false;

    public static bool gameIsInPlay = true;
    public static bool simulating = false;
    

    public static string winner = "";
    public static string simulatedWinner = "";

    public GameObject gameTitle;
    public GameObject restartButton;
    public GameObject startButton;
    public GameObject gameStatusPanel;
    public TextMeshProUGUI gameWinner;
    
    public GameObject winnerTag;
    public GameObject winnerText;


    string[] slotLetters = new string[9];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(updateGameState)
        {
            updateGameState = false;
            UpdateGameState();
        }



        if(winner != "")
        {
            Debug.Log("Winner Detected");
            gameIsInPlay = false;
            OpponentAI.playerCanPlay = false;
            Debug.Log("Winner: " + winner);
            EndGame();
        }
        if (findFavorableSlot)
        {
            findFavorableSlot = false;
            StartCoroutine(FindFavorableSlot());
            //favorableSlot = ReturnFavorableSlot();
        }

    }

    
    void UpdateGameState()
    {
        GameObject[] gameSlots = GameObject.FindGameObjectsWithTag("GameSlots");
        foreach(GameObject slot in gameSlots)
        {
            string slotName = slot.name;
            //Debug.Log("Slot name: " + slotName);
            DetectClicks slotClickHandler = slot.GetComponent<DetectClicks>();
            if(slotClickHandler != null)
            {
                switch (slotName)
                {
                    case "1":
                        slotLetters[0] = slotClickHandler.letter;
                        Debug.Log(slotClickHandler.letter);
                        break;
                    case "2":
                        slotLetters[1] = slotClickHandler.letter;
                        break;
                    case "3":
                        slotLetters[2] = slotClickHandler.letter;
                        break;
                    case "4":
                        slotLetters[3] = slotClickHandler.letter;
                        break;
                    case "5":
                        slotLetters[4] = slotClickHandler.letter;
                        break;
                    case "6":
                        slotLetters[5] = slotClickHandler.letter;
                        break;
                    case "7":
                        slotLetters[6] = slotClickHandler.letter;
                        break;
                    case "8":
                        slotLetters[7] = slotClickHandler.letter;
                        break;
                    case "9":
                        slotLetters[8] = slotClickHandler.letter;
                        break;
                    default:
                        break;
                }
            }
        }
        Debug.Log("Game State Updated");
        gameStateUpdated = true;
        if (!simulating)
        {
            CheckWinner();
        }
        
    }

    void CheckWinner()
    {
        if (slotLetters[0] == slotLetters[3] && slotLetters[3] == slotLetters[6])
        {
            if (slotLetters[0] == "X")
            {
                winner = "PLAYER";
                //simulatedWinner = "PLAYER";
            }
            else if (slotLetters[0]=="O")
            {
                winner = "CPU";
            }
        }else if (slotLetters[1] == slotLetters[4] && slotLetters[4] == slotLetters[7])
        {
            if (slotLetters[1] == "X")
            {
                winner = "PLAYER";
                //simulatedWinner = "PLAYER";
            }
            else if (slotLetters[1] == "O")
            {
                winner = "CPU";
            }
        }
        else if (slotLetters[2] == slotLetters[5] && slotLetters[5] == slotLetters[8])
        {
            if (slotLetters[2] == "X")
            {
                winner = "PLAYER";
               // simulatedWinner = "PLAYER";
            }
            else if (slotLetters[2] == "O")
            {
                winner = "CPU";
            }
        }
        else if (slotLetters[0] == slotLetters[1] && slotLetters[1] == slotLetters[2])
        {
            if (slotLetters[0] == "X")
            {
                winner = "PLAYER";
               // simulatedWinner = "PLAYER";
            }
            else if (slotLetters[0] == "O")
            {
                winner = "CPU";
            }
        }
        else if (slotLetters[3] == slotLetters[4] && slotLetters[4] == slotLetters[5])
        {
            if (slotLetters[3] == "X")
            {
                winner = "PLAYER";
               // simulatedWinner = "PLAYER";
            }
            else if (slotLetters[3] == "O")
            {
                winner = "CPU";
            }
        }
        else if (slotLetters[6] == slotLetters[7] && slotLetters[7] == slotLetters[8])
        {
            if (slotLetters[6] == "X")
            {
                winner = "PLAYER";
               // simulatedWinner = "PLAYER";
            }
            else if (slotLetters[6] == "O")
            {
                winner = "CPU";
            }
        }
        else if (slotLetters[0] == slotLetters[4] && slotLetters[4] == slotLetters[8])
        {
            if (slotLetters[0] == "X")
            {
                winner = "PLAYER";
               // simulatedWinner = "PLAYER";
            }
            else if (slotLetters[0] == "O")
            {
                winner = "CPU";
            }
        }
        else if (slotLetters[2] == slotLetters[4] && slotLetters[4] == slotLetters[6])
        {
            if (slotLetters[2] == "X")
            {
                winner = "PLAYER";
                //simulatedWinner = "PLAYER";
            }
            else if (slotLetters[2] == "O")
            {
                winner = "CPU";
            }
        }else if(availableSlots == 0)
        {
            winner = "DRAW";
        }
        
    }

    //Function that helps the CPU to know where to play in order to intercept player moves
    void SimulateWinner()
    {
        if (slotLetters[0] == slotLetters[3] && slotLetters[3] == slotLetters[6])
        {
            Debug.Log(" 1 4 7");
            if (slotLetters[0] == "X")
            {
               // winner = "PLAYER";
                simulatedWinner = "PLAYER";
            }
            else if (slotLetters[0] == "O")
            {
                simulatedWinner = "CPU";
            }
        }
        else if (slotLetters[1] == slotLetters[4] && slotLetters[4] == slotLetters[7])
        {
            Debug.Log(" 2 5 8");
            if (slotLetters[1] == "X")
            {
               // winner = "PLAYER";
                simulatedWinner = "PLAYER";
            }
            else if (slotLetters[1] == "O")
            {
                simulatedWinner = "CPU";
            }
        }
        else if (slotLetters[2] == slotLetters[5] && slotLetters[5] == slotLetters[8])
        {
            Debug.Log(" 3 6 9");
            if (slotLetters[2] == "X")
            {
               // winner = "PLAYER";
                simulatedWinner = "PLAYER";
            }
            else if (slotLetters[2] == "O")
            {
                simulatedWinner = "CPU";
            }
        }
        else if (slotLetters[0] == slotLetters[1] && slotLetters[1] == slotLetters[2])
        {
            Debug.Log(" 1 2 3");
            if (slotLetters[0] == "X")
            {
               // winner = "PLAYER";
                simulatedWinner = "PLAYER";
            }
            else if (slotLetters[0] == "O")
            {
                simulatedWinner = "CPU";
            }
        }
        else if (slotLetters[3] == slotLetters[4] && slotLetters[4] == slotLetters[5])
        {
            Debug.Log(" 4 5 6");
            if (slotLetters[3] == "X")
            {
               // winner = "PLAYER";
                simulatedWinner = "PLAYER";
            }
            else if (slotLetters[3] == "O")
            {
                simulatedWinner = "CPU";
            }
        }
        else if (slotLetters[6] == slotLetters[7] && slotLetters[7] == slotLetters[8])
        {
            Debug.Log(" 7 8 9");
            if (slotLetters[6] == "X")
            {
                //winner = "PLAYER";
                simulatedWinner = "PLAYER";
            }
            else if (slotLetters[6] == "O")
            {
                simulatedWinner = "CPU";
            }
        }
        else if (slotLetters[0] == slotLetters[4] && slotLetters[4] == slotLetters[8])
        {
            Debug.Log(" 1 5 9");
            if (slotLetters[0] == "X")
            {
               // winner = "PLAYER";
                simulatedWinner = "PLAYER";
            }
            else if (slotLetters[0] == "O")
            {
                simulatedWinner = "CPU";
            }
        }
        else if (slotLetters[2] == slotLetters[4] && slotLetters[4] == slotLetters[6])
        {
            Debug.Log(" 3 5 7");
            if (slotLetters[2] == "X")
            {
               // winner = "PLAYER";
                simulatedWinner = "PLAYER";
            }
            else if (slotLetters[2] == "O")
            {
                simulatedWinner = "CPU";
            }
        }
        else if (availableSlots == 0)
        {
            winner = "DRAW";
        }
    }

    IEnumerator FindFavorableSlot()
    {
        simulating = true;
        GameObject[] gameSlots = GameObject.FindGameObjectsWithTag("GameSlots");
        foreach(GameObject slot in gameSlots)
        { 
            DetectClicks slotClickhandler = slot.GetComponent<DetectClicks>();
            if(slotClickhandler != null && slotClickhandler.available)
            {
                //simulating = true;
                //Simulate playing "X" in this slot
                slotClickhandler.available = false;
                slotClickhandler.letter = "X";

                UpdateGameState();
                yield return new WaitUntil(() => gameStateUpdated);
                gameStateUpdated = false;
                SimulateWinner();

                if(simulatedWinner == "PLAYER" || simulatedWinner == "CPU")
                {
                    simulatedWinner = "";
                    //Block player's winning move
                    slotClickhandler.available = true;
                    slotClickhandler.letter = "";
                    UpdateGameState();

                    yield return new WaitUntil(() => gameStateUpdated);
                    gameStateUpdated = false;
                    //simulating = false;
                    
                    favorableSlot = int.Parse(slot.name);
                    favorableSlotFound = true;
                    simulating = false;
                    yield break;
                    // ReturnFavorableSpot();
                    //return int.Parse(slot.name);
                }
                
                slotClickhandler.available = true;
                slotClickhandler.letter = "";
                UpdateGameState();
            }
        }
        //If there are no winning move for player
        
       
        
        favorableSlot = 11;
        favorableSlotFound = true;
        simulating = false;
        // ReturnFavorableSpot();
        //return 11; 
    }

    public void OnRetryGamePressed()
    {

        //winnerText.SetActive(false);
        winner = "";
        winnerTag.SetActive(false);
        OpponentAI.playerCanPlay = false;
      //  playerHasPlayed = false;

        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        
        gameStarted = true;
        gameIsInPlay = true;
        restartButton.SetActive(true);
        startButton.SetActive(false);
        gameTitle.SetActive(false);
        OpponentAI.playerCanPlay = true;
        availableSlots = 9;
    }

    public void EndGame()
    {
        Debug.Log("Player Wins");
        gameStatusPanel.SetActive(true);

        winnerTag.SetActive(true);
        winnerText.SetActive(true);
        gameWinner.text = winner;
        gameIsInPlay = false;
    }
}
