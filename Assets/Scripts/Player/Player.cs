using System.Linq;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

[System.Serializable]
public class Player
{
    public string name;
    public int stamina, magic, might, diceAmount;
    public int[] result;
    public TextMeshProUGUI staminaText;
    public TextMeshProUGUI mightText;
    public TextMeshProUGUI magicText;

    public void heal(int healAmount)
    {
        stamina += healAmount;
    }
    public void hurt(int damage)
    {
        stamina -= damage;
    }
}
