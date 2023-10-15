using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ChallengeDeck : MonoBehaviour
{

    int[] roomChallenge = new int[2];
    int targetNum, loserPenalty;
    [SerializeField] private EventManager events;
    [SerializeField] private GameObject room;
    private int nextSpace;
   // private int goNext;
    [SerializeField] private Sprite[] roomSprites;
    private SpriteRenderer roomRenderer;
    [SerializeField] private TextMeshProUGUI roomText;
    private string roomName;

    private void Awake()
    {
        roomRenderer = room.GetComponent<SpriteRenderer>();
    }

    //target num is the number needed to roll to win the room
    //stat is the stat being rolled 1 might, 2 magic, 3 none
    //numOfRolls is how many attempts each player gets
    //loserPenalty is wether or not there is a penalty for being last
    public int[] ChosenRoom(int roomNum)
    {


        
        //goNext++;
        
        switch (roomNum)
        {
            case 0:
                Debug.Log("combat room");
                targetNum = 8;
                loserPenalty = 3;
                roomName = "Combat Room";
                setSprite(0);
                
                break;
            case 1:
                Debug.Log("Might Room");
                events.SwitchStat();
                targetNum = 6;
                loserPenalty = 3;
                roomName = "Might Room";
                setSprite(1);
                break;
            case 2:
                Debug.Log("Magic Room");
                targetNum = 8;
                roomName = "Magic Room";
                loserPenalty = 1;
                setSprite(2);
                events.SwitchStat();
                break;
            case 3:
                Debug.Log("lock Picking Room");
                targetNum = Random.Range(3, 10);
                roomName = "Lock Picking Room";
                loserPenalty = 1;
                setSprite(3);
                break;
            case 4:
                Debug.Log("random stuff to fill out info");
                targetNum = 8;
                loserPenalty = 2;

                roomName = "Mystery Challenge Room";
                setSprite(0);
                break;
            case 5:
                
                Debug.Log("Luck room");
                targetNum = 0;
                loserPenalty = 0;
                roomName = "Luck Room";

                setSprite(4);

                break;
        }
        Instantiate(room, new Vector3(0, nextSpace, 0), Quaternion.identity);
        roomText.text = roomName + "\n Your target is: " + targetNum + "\n Losing penalty is: " + loserPenalty ;
        nextSpace += 8;
        roomChallenge[0] = targetNum;
        roomChallenge[1] = loserPenalty;
        return (roomChallenge);
    }

    
    private void setSprite(int sprite)
    {
        Debug.Log("Render sprite num " + sprite);
        roomRenderer.sprite = roomSprites[sprite];
    }
}
