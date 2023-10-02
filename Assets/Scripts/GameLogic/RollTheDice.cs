using System.Linq;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class RollTheDice : MonoBehaviour
{
    private int[] result;


    private gameManager gameManager;

    //Players
    private Magician magician;
    private Knight knight;
    private Thief thief;
    private Human human;


    private void Awake()
    {
        gameManager = GetComponent<gameManager>();
    }

    public void RollMagician()
    {
        result[0] = Random.Range(1, 7);
        result[1] = Random.Range(1, 7);


        //Lucky Seven
        if (result[0] + result[1] == 7)
            magician.PlayerClass.heal(2);
    }

    public void RollKnight()
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

        //(Mathf.RoundToInt(result[0] + result[1] / 2) + knight.PlayerClass.might);
    }

    public void RollThief()
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

        //Rerolling controlled in _ script
    }

    public void RollHuman()
    {
        result[0] = Random.Range(1, 7);

        if (result[0] > 3)
            human.PlayerClass.heal(2);
        else
            human.PlayerClass.heal(1);
    }
}