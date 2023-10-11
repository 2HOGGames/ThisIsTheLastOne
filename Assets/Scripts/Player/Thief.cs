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
}
