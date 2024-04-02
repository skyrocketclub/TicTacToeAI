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
            StartCoroutine(CpuPlays());
        }
    }

    IEnumerator CpuPlays()
    {
        yield return new WaitForSeconds(1.0f);

        if (GameManager.gameIsInPlay)
        {
            GameManager.findFavorableSlot = true;
            yield return new WaitUntil(()=>GameManager.favorableSlotFound);
            int favorableSlot = GameManager.favorableSlot;
            GameManager.favorableSlotFound = false;
          //  Debug.Log("Favorable Slot:" + favorableSlot);

            if (favorableSlot != 11)
            {
                //Play in the favorable slot to block player
                GameObject slot = GameObject.Find(favorableSlot.ToString());
                Debug.Log("Favorable Slot:" + favorableSlot);
                DetectClicks slotClickhandler = slot.GetComponent<DetectClicks>();
                if(slotClickhandler != null && slotClickhandler.available)
                {
                    Quaternion desiredRotation = Quaternion.Euler(90f, 0f, 0f);
                    Instantiate(oPrefab, slotClickhandler.transform.position, desiredRotation);
                    slotClickhandler.available = false;
                    slotClickhandler.letter = "O";
                    playerCanPlay = true;
                    GameManager.updateGameState = true;
                    GameManager.availableSlots -= 1;
                    GameManager.simulating = false;
                }
            }
            else
            {
                GameObject[] gameSlots = GameObject.FindGameObjectsWithTag("GameSlots");
                foreach (GameObject slot in gameSlots)
                {
                    DetectClicks slotClickhandler = slot.GetComponent<DetectClicks>();
                    if (slotClickhandler != null && slotClickhandler.available)
                    {
                        Quaternion desiredRotation = Quaternion.Euler(90f, 0f, 0f);
                        Instantiate(oPrefab, slotClickhandler.transform.position, desiredRotation);
                        slotClickhandler.available = false;
                        slotClickhandler.letter = "O";
                        playerCanPlay = true;
                        GameManager.updateGameState = true;
                        GameManager.availableSlots -= 1;
                        break;
                    }
                }
            }        
        }
       
    }

}
