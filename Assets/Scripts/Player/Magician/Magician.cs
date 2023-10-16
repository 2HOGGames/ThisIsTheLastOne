using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Magician : MonoBehaviour
{
    public Player PlayerClass;

    [SerializeField] private TextMeshProUGUI statNumber;
    [SerializeField] private Animator magicianAnimator;
    [SerializeField] private UnityEngine.UI.Image die1;
    [SerializeField] private UnityEngine.UI.Image die2;
    [SerializeField] private Sprite[] dieSprites;
    [SerializeField] private GameObject MagicianAnim;

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

    public int RollMagician()
    {
        //MagicianAnim.SetActive(true);
        //magicianAnimator.SetBool("LuckySeven", false);
        PlayerClass.result[0] = Random.Range(1, 7);
        PlayerClass.result[1] = Random.Range(1, 7);

        //die1.sprite = dieSprites[PlayerClass.result[0] - 1];
        //die2.sprite = dieSprites[PlayerClass.result[1] - 1];
        statNumber.text = PlayerClass.magic.ToString();

        //magicianAnimator.SetTrigger("StartAnim");

        //Lucky Seven
        if (PlayerClass.result[0] + PlayerClass.result[1] == 7)
        {
            PlayerClass.heal(2);
            //magicianAnimator.SetBool("LuckySeven", true);
        }

        /*if (PlayerClass.result[0] <= PlayerClass.result[1])
        {
            magicianAnimator.SetTrigger("Roll1");
        }
        else
        {
            magicianAnimator.SetTrigger("Roll2");
        }*/


        if (UsingMight)
        {
            mainText.text = "Magician Rolled: " + (PlayerClass.result.Min() + PlayerClass.might);
            Debug.Log("magician rolled with might");
            return PlayerClass.result.Min() + PlayerClass.might;
        }
        else
        {
            mainText.text = "Magician Rolled: " + (PlayerClass.result.Min() + PlayerClass.magic);
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
