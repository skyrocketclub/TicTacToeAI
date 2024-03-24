using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentAI : MonoBehaviour
{
    public static bool cpuHasPlayed = false;
    public static bool playerCanPlay = true;

    public GameObject oPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.playerHasPlayed)
        {
            GameManager.playerHasPlayed = false;
            playerCanPlay = false;
            CpuPlays();
        }
    }

    void CpuPlays()
    {
        //Implement the Cpu playing in a spot...
        GameObject[] gameSlots = GameObject.FindGameObjectsWithTag("GameSlots");
        foreach(GameObject slot in gameSlots)
        {
            DetectClicks slotClickhandler = slot.GetComponent<DetectClicks>();
            if(slotClickhandler!= null && slotClickhandler.available)
            {
                Quaternion desiredRotation = Quaternion.Euler(90f, 0f, 0f);
                Instantiate(oPrefab, slotClickhandler.transform.position, desiredRotation);
                slotClickhandler.available = false;
                slotClickhandler.letter = "O";
                playerCanPlay = true;
                break;
            }
        }
    }
}
