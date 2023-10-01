using System.Linq;
using UnityEngine;


[System.Serializable]
public class Player
{
    public string name;
    public int stamina, magic, might, diceAmount;

    public void heal(int healAmount)
    {
        stamina += healAmount;
    }
    public void hurt(int damage)
    {
        stamina -= damage;
    }

}
