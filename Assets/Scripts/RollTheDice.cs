using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class RollTheDice : MonoBehaviour
{
    private int[] result;
    private gameManager gameManager;

    private Magician magician;


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

        if (result[0] + result[1] == 7)
            magician.magician.heal(2);

        if (result[1] > result[0])
            return result[1];
        else
            return result[0];
    }
}
