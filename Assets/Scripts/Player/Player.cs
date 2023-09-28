using UnityEngine;


[System.Serializable]
public class Player
{
    public string name;
    public int stamina, magic, might, diceAmount;
    public int[] results;

    public void heal(int healAmount)
    {
        stamina += healAmount;
    }
    public void hurt(int damage)
    {
        stamina -= damage;
    }

    public void roll(int dice)
    {
        for (int i = 0; i < dice; i++)
        {
            results[i] = Random.Range(1, 7);
        }
    }

}
