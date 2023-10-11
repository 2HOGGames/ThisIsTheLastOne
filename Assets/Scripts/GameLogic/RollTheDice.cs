using System.Linq;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;

public class RollTheDice : MonoBehaviour
{
    public int[] result;


    private gameManager gameManager;

    //Players
    private Magician magician;
    private Knight knight;
    private Thief thief;
    private Human human;




    [SerializeField] private TextMeshProUGUI statNumber;
    [SerializeField] private Animator magicianAnimator;
    [SerializeField] private UnityEngine.UI.Image die1;
    [SerializeField] private UnityEngine.UI.Image die2;
    [SerializeField] private Sprite[] dieSprites;
    [SerializeField] private Sprite[] dieSprites2;
    [SerializeField] private GameObject MagicianAnim;

    private void Awake()
    {
        gameManager = GetComponent<gameManager>();
        magician = FindObjectOfType<Magician>();
    }

    public int RollMagician()
    {
        MagicianAnim.SetActive(true);
        magicianAnimator.SetBool("LuckySeven", false);
        result[0] = Random.Range(1, 7);
        result[1] = Random.Range(1, 7);

        die1.sprite = dieSprites[result[0] - 1];
        die2.sprite = dieSprites[result[1] - 1];
        statNumber.text = magician.PlayerClass.magic.ToString();

        magicianAnimator.SetTrigger("StartAnim");

        //Lucky Seven
        if (result[0] + result[1] == 7)
        {
            magician.PlayerClass.heal(2);
            magicianAnimator.SetBool("LuckySeven", true);
        }

        if (result[0] >= result[1])
        {
            magicianAnimator.SetTrigger("Roll1");
        }
        else
        {
            magicianAnimator.SetTrigger("Roll2");
        }

        return result.Max() + magician.PlayerClass.magic;
    }

    public int RollKnight()
    {
        result[0] = Random.Range(1, 7);
        result[1] = Random.Range(1, 7);


        //Recover 1 Stamina if a 1 is rolled
        foreach (int i in result)
        {
            if (i == 1)
                knight.PlayerClass.heal(1);
        }

        //Returns the average of both dice rolls + Might Stat

        return (Mathf.RoundToInt(result[0] + result[1] / 2) + knight.PlayerClass.might);
    }

    public int RollThief()
    {
        result[0] = Random.Range(1, 7);
        result[1] = Random.Range(1, 7);
        result[2] = Random.Range(1, 7);

        int sum = 0;
        foreach (int i in result)
        {
            sum += i;
        }

        sum = Mathf.RoundToInt(sum * 0.5f);

        return sum;
    }

    public int RollHuman()
    {
        result[0] = Random.Range(1, 7);

        if (result[0] > 3)
            human.PlayerClass.heal(2);
        else
            human.PlayerClass.heal(1);

        return result.Max();
    }
}
