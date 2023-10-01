using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckShuffler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int[] deck = new int[12];
    [SerializeField] private int[] freeSpaces = new int[12];
    int randomNum;
    bool spaceTaken = false;
    private int CardsDrawn = 0;

    private void Start()
    {
        Shuffle();

        for(int i = 0; i <= 11; i++)
        {
            Drawnext();
        }
    }
    public void Shuffle()
    {
        for(int i = 0; i <= deck.Length -1; i++)
        {
            spaceTaken = false;
            while(spaceTaken == false)
            {
                randomNum = Random.Range(0, 12);


                if(freeSpaces[randomNum] == 0)
                {
                    deck[randomNum] = i;
                    freeSpaces[randomNum] = 1;
                    spaceTaken = true;
                }


            }



        }

       
    }

    public void Drawnext()
    {
        Debug.Log(deck[CardsDrawn]);
        CardsDrawn++;


    }
}
