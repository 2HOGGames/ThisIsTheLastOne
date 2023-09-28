using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Magician : MonoBehaviour
{
    [SerializeField] private Player magician;

    private void rollMagician()
    {
        magician.lastRoll = magician.roll(magician.diceAmount);

        SevenCheck();

        magician.lastRoll += magician.magic;
    }

    private void SevenCheck()
    {
        if (magician.results[0] + magician.results[1] == 7)
            magician.heal(2);
    }
}
