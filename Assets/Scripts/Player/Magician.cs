using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Magician : MonoBehaviour
{
    public Player magician;
    private int roll1;
    private int roll2;

    private void SevenCheck()
    {
        if (roll1 + roll2 == 7)
        {
            Debug.Log("Lucky Seven");
            magician.heal(2);
        }
    }
}
