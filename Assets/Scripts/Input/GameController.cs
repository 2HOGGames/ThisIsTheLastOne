using System.Xml;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool currentlyPaused;

    private void Awake()
    {
        Inputs.Init(this);
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

    public void SwitchCharacter()
    {

    }



}
