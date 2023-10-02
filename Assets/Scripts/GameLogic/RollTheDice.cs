using System.Linq;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class RollTheDice : MonoBehaviour
{
    private int[] result;
    private gameManager gameManager;

    private Magician magician;
    private Knight knight;


    private void Awake()
    {
        gameManager = GetComponent<gameManager>();
    }
    /*public int Roll()
    {

    }*/

    private int RollMagician()
    {
        result[0] = Random.Range(1, 7);
        result[1] = Random.Range(1, 7);


        //Lucky Seven
        if (result[0] + result[1] == 7)
            magician.PlayerClass.heal(2);



        return result.Max();
    }

    private int RollKnight()
    {
        result[0] = Random.Range(1, 7);
        result[1] = Random.Range(1, 7);

        foreach (int i in result)
        {
            if (i == 1)
                knight.PlayerClass.heal(1);
        }

        return result.Max();
    }

    private int RollThief()
    {
        result[0] = Random.Range(1, 7);
        result[1] = Random.Range(1, 7);
        result[2] = Random.Range(1, 7);

        return result.Max();
    }
}
