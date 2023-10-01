using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Magician : MonoBehaviour
{
    public Player magician;
    private int roll1;
    private int roll2;

    public int rollMagician()
    {
        roll1 = Random.Range(1, 7);
        roll2 = Random.Range(1, 7);
        SevenCheck();

        if (roll1 < roll2)
        {
            return roll2;
        }    
        else
        {
            return roll1;
        }
    }

    private void SevenCheck()
    {
        if (roll1 + roll2 == 7)
        {
            Debug.Log("Lucky Seven");
            magician.heal(2);
        }
    }
}
