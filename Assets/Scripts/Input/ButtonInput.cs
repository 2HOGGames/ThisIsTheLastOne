using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]private gameManager _manager;
    [SerializeField] private int buttonNum;
    public void ButtonSelected()
    {
        if (_manager.waitForInput)
        {
            Debug.Log("button " + buttonNum + " pressed");

            _manager.waitForInput = false;
            _manager.SelectionMade(buttonNum);
        }
        
    }
    


}
