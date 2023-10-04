using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckShuffler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int[] deck = new int[6];//stores the shuffled value of the deck
    [SerializeField] private int[] freeSpaces = new int[6];//stores chosen spaces
    int randomNum;
    bool spaceTaken = false;
    private int CardsDrawn = 0;

    public int card1, card2;

    private void Start()
    {
        Shuffle();
        
        
       
    }
    public void Shuffle()//shuffles the deck by placing a value from 1-11 in a random index (position in the deck)
    {
        for(int i = 0; i <= deck.Length -1; i++)//repeats for each card
        {
            spaceTaken = false;//sets the current space as false to initialize the loop
            while(spaceTaken == false)//loops until the space is taken (a card that hasnt been sorted is sorted)
            {
                randomNum = Random.Range(0, (deck.Length));//accesss a random index of the array


                if(freeSpaces[randomNum] == 0)//if that index hasnt been used yet
                {
                    deck[randomNum] = i;//adds the current card to the random chosen index
                    freeSpaces[randomNum] = 1;//confirms the index has been chosen so the card cant be overridden later
                    spaceTaken = true;//ends the loop
                }


            }



        }

       
    }
    //draws the first card to start the game, resets the deck positions after
    public int firstCard()
    {
        card1 = deck[0];
        CardsDrawn++;
        for (int i = 1; i <= deck.Length - 1; i++)
        {
           
            deck[i - 1] = deck[i];
            deck[i] = 0;


        }
        return (card1);
    }
    public void Drawnext()//draws the next two cards for reference
    {
         card1 = deck[0];
         card2 = deck[1];
        CardsDrawn ++;
       // Debug.Log("you drew " + card1 + " and " + card2);

        

    }
    public int[] DrawnCards()//returns an array containing the two drawn cards
    {
        int[] cards = new int[2];
        Drawnext();
        cards[0] = card1;
        cards[1] = card2;
        return (cards);
    }
    public void ReformDeck(int nonChosen)//resets the deck and puts the card not chosen by the player back on the bottom of the deck
    {
        for (int i = 2; i <= deck.Length - 1; i++)
        {
            //Debug.Log("Index " + (i - 2) + "was " + deck[i - 2] + "It became " + deck[i]);
            deck[i - 2] = deck[i];
            deck[i] = 0;


        }
        deck[(deck.Length - 1) - CardsDrawn] = nonChosen;
        CardsDrawn++;
    }
}
