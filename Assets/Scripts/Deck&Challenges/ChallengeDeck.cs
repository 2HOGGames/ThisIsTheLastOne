using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeDeck : MonoBehaviour
{
   public void ChosenRoom(int roomNum)
    {
        switch (roomNum)
        {
            case 0:
                Debug.Log("challenge 1");
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
    }

    public void MonsterRoom()
    {

        Debug.Log("monsterDeckchosen");



    }
}
