using UnityEngine;
using System.Linq;
using TMPro;

public class Knight : MonoBehaviour
{
    public Player PlayerClass;
    private TextMeshProUGUI mainText;

    private bool UsingMight;

    private void Awake()
    {
        PlayerClass.mightText.text = "Might\n" + PlayerClass.might;
        PlayerClass.magicText.text = "Magic\n" + PlayerClass.magic;
        mainText = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();
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

        if (UsingMight)
        {
            mainText.text = "Knight Rolled: " + (PlayerClass.result.Min() + PlayerClass.might);
            Debug.Log("magician rolled with might");
            return PlayerClass.result.Min() + PlayerClass.might;
        }
        else
        {
            mainText.text = "Knight Rolled: " + (PlayerClass.result.Min() + PlayerClass.magic);
            Debug.Log("magician rolled with magic");
            return PlayerClass.result.Min() + PlayerClass.magic;
        }
    }
    private void OnEnable()
    {
        EventManager.SwitchRoomStatType += ChangeBool;
    }

    private void OnDisable()
    {
        EventManager.SwitchRoomStatType -= ChangeBool;
    }

    private void ChangeBool()
    {
        if (UsingMight)
            UsingMight = false;
        else
            UsingMight = true;
    }
}

   





