using System.Collections;
using System.Xml;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool currentlyPaused;
    private gameManager gameManager;
    private Magician magician;

    private void Awake()
    {
        Inputs.Init(this);
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
        if (gameManager.currentPlayer == 1)
        {

        }
    }

}
