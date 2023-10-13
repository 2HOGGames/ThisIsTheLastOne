using UnityEngine;

public class Thief : MonoBehaviour
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

    public int RollThief()
    {
        PlayerClass.result[0] = Random.Range(1, 7);
        PlayerClass.result[1] = Random.Range(1, 7);
        PlayerClass.result[2] = Random.Range(1, 7);

        int sum = 0;
        foreach (int i in PlayerClass.result)
        {
            sum += i;
        }

        sum = Mathf.RoundToInt(sum * 0.5f)+1;

        return sum;
    }
}
