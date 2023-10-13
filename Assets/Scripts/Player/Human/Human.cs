using UnityEngine;

public class Human : MonoBehaviour
{
    public Player PlayerClass;

    private void Awake()
    {
        PlayerClass.mightText.text = "Might\n" + PlayerClass.might;
        PlayerClass.magicText.text = "Magic\n" + PlayerClass.magic;
    }
    private void Update()
    {
        PlayerClass.staminaText.text = "Stamina\n" + PlayerClass.stamina;
    }

    public int RollHuman()
    {
        PlayerClass.result[0] = Random.Range(1, 7);

        if (PlayerClass.result[0] > 3)
            PlayerClass.heal(2);
        else
            PlayerClass.heal(1);

        return PlayerClass.result[0] + 2;
    }
}
