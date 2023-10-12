using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private gameManager manager;

    private void Awake()
    {
        manager = gameObject.GetComponent<gameManager>();
        manager = GetComponent<gameManager>();
    }
    public void ButtonOneSelected()
    {
        manager.SelectionMade(1);  
    }
    public void ButtonTwoSelected()
    {
        manager.SelectionMade(2);
    }
}
