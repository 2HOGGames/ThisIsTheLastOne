using System.Collections;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool currentlyPaused;
    private gameManager gameManager;

    //Players
    private Magician magician;
    private Knight knight;
    private Thief thief;
    private Human human;

    private void Awake()
    {
        Inputs.Init(this);
        InitScripts();
        
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
    public void playerInput()
    {
        gameManager.GameLoop();
    }
    public int Roll()
    {
        switch (gameManager.currentPlayer)
        {
            case 0:
                return magician.RollMagician();
            case 1:
                return knight.RollKnight();
            case 2:
                return thief.RollThief();
            case 3:
                return human.RollHuman();
        }
        return 0;
    }
    private void InitScripts()
    {
        gameManager = gameObject.GetComponent<gameManager>();
        gameManager = GetComponent<gameManager>();
        magician = FindObjectOfType<Magician>();
        knight = FindObjectOfType<Knight>();
        thief = FindObjectOfType<Thief>();
        human = FindObjectOfType<Human>();
    }
}
