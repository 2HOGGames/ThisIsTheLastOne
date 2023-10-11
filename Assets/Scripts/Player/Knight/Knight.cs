using UnityEngine;

public class Knight : MonoBehaviour
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

    public int RollKnight()
    {
        PlayerClass.result[0] = Random.Range(1, 7);
        PlayerClass.result[1] = Random.Range(1, 7);


        //Recover 1 Stamina if a 1 is rolled
        foreach (int i in PlayerClass.result)
        {
            if (i == 1)
                PlayerClass.heal(1);
        }

        //Returns the average of both dice rolls + Might Stat

        return (Mathf.RoundToInt(PlayerClass.result[0] + PlayerClass.result[1] / 2) + PlayerClass.might);
    }
}
