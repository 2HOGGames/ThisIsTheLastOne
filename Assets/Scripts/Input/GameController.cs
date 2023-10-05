using System.Collections;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool currentlyPaused;
    private gameManager gameManager;

    private RollTheDice rollTheDice;

    int currentPlayer;

    private void Awake()
    {
        Inputs.Init(this);
        rollTheDice = gameObject.GetComponent<RollTheDice>();
        gameManager = gameObject.GetComponent<gameManager>();
    }
    public void Pause()
    {
        if (currentlyPaused)
        {
            currentlyPaused = false;
            Debug.Log("Unpause");
        }
        else
        {
            currentlyPaused = true;
            Debug.Log("Pause");
        }
    }

    public void Test()
    {
        Debug.Log("Test");
    }

    public int Roll()
    {
        switch (gameManager.currentPlayer)
        {
            case 0:
                return rollTheDice.RollMagician();
            case 1:
                return rollTheDice.RollKnight();
            case 2:
                return rollTheDice.RollThief();
            case 3:
                return rollTheDice.RollHuman();
        }
        return 0;
    }

}
