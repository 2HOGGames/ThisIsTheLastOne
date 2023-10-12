using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thiefButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int wantToReroll;
    [SerializeField] private gameManager manager;
    public void ThiefPressed()
    {
        Debug.Log("buttonPressed");
        
            manager.waitForThief = false;
            if (wantToReroll == 1)
            {
            manager.ThiefReroll();
            }
        else
        {
            manager.ThiefMenuOff();
        }
            
        Inputs.PlayMode();
        
    }
}
