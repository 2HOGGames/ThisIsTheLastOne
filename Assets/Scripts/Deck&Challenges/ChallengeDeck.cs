using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeDeck : MonoBehaviour
{
    int[] roomChallenge = new int[3];
    int targetNum, stat, numOfRolls, loserPenalty;
    //target num is the number needed to roll to win the room
    //stat is the stat being rolled 1 might, 2 magic, 3 none
    //numOfRolls is how many attempts each player gets
    //loserPenalty is wether or not there is a penalty for being last
   public int[] ChosenRoom(int roomNum)
    {
        switch (roomNum)
        {
            case 0:
                targetNum = 12;
                stat = 1;
                
                loserPenalty = -1;
                break;
            case 1:
                Debug.Log("challenge 2");
                break;
            case 2:
                Debug.Log("challenge 3");
                break;
            case 3:
                Debug.Log("challenge 4");
                break;
            case 4:
                Debug.Log("challenge 5");
                break;
            case 5:
                Debug.Log("challenge 6");
                break;
        }
        roomChallenge[0] = targetNum;
        roomChallenge[1] = stat;
        roomChallenge[2] = loserPenalty;
        return (roomChallenge);
    }

    
}
