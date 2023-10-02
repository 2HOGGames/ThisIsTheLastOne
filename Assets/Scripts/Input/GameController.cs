using System.Collections;
using System.Xml;
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

    public void Roll()
    {
        switch (gameManager.currentPlayer)
        {
            case 0:
                rollTheDice.RollMagician();
                break;
            case 1:
                rollTheDice.RollKnight();
                break;
            case 2:
                rollTheDice.RollThief();
                break;
            case 3:
                rollTheDice.RollHuman();
                break;
        }
    }

}
