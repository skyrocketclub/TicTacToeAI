using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  DetectClicks : MonoBehaviour
{
    public GameObject xPrefab;
    public bool available = true;
    public string letter = "";

 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        //If the player chooses a slot and it is the players turn to play...
        if (Input.GetMouseButtonDown(0) && OpponentAI.playerCanPlay && available && GameManager.gameStarted)
        {
            Quaternion desiredRotation = Quaternion.Euler(90f, 0f, 0f);
            Instantiate(xPrefab, transform.position, desiredRotation);
            GameManager.playerHasPlayed = true;
            available = false;
            letter = "X";
        }
    }
}
