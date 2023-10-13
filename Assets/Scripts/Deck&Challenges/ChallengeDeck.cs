using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeDeck : MonoBehaviour
{
    int[] roomChallenge = new int[2];
    int targetNum, loserPenalty;
    [SerializeField] private EventManager events;
    //target num is the number needed to roll to win the room
    //stat is the stat being rolled 1 might, 2 magic, 3 none
    //numOfRolls is how many attempts each player gets
    //loserPenalty is wether or not there is a penalty for being last
   public int[] ChosenRoom(int roomNum)
    {
        switch (roomNum)
        {
            case 0:
                Debug.Log("combat room");
                targetNum = 6;
                loserPenalty = 2;
                break;
            case 1:
                Debug.Log("Might Room");
                events.SwitchStat();
                targetNum = 5;
                loserPenalty = 0;
                break;
            case 2:
                Debug.Log("Magic Room");
                targetNum = 7;
                loserPenalty = 0;
                events.SwitchStat();
                break;
            case 3:
                Debug.Log("lock Picking Room");
                targetNum = Random.Range(1, 8);
                loserPenalty = 1;
                break;
            case 4:
                Debug.Log("random stuff to fill out info");
                targetNum = 8;
                loserPenalty = 0;
                break;
            case 5:
                //luck room
                Debug.Log("Luck room");
                targetNum = 0;
                loserPenalty = 0;
                break;
        }
        roomChallenge[0] = targetNum;
        roomChallenge[1] = loserPenalty;
        return (roomChallenge);
    }

    
}
