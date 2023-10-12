using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;
   

    public  DeckShuffler deckShuffler;//deck shuffling object
    public ChallengeDeck challengeDeck;//chellenge deck object
    public GameController gameController;//game controller object

    public GameObject buttonCanvas;
    public GameObject ThiefButton;
   


    public GameObject[] players = new GameObject[4];//players
    
    public int currentPlayer = 0;//current players turn


    private int[] newCards = new int[2];//current cards waiting to be chosen

    private int[] challengeInfo = new int[2];//the details of the current challenge

    [SerializeField]private int[] playerRolls = new int [4];//what each player rolled

   [SerializeField] private int[] points = new int[4];//how many points each player has

    private int[] sortingArray = new int[] { 1, 2, 3, 4 };//keeps player rolls position during sorting

    private int chosenRoom, discardedRoom;//room chosen and room discarded

    public bool selectingRoom = false;//failsafe so things cahnt happen until a room is selected
    private bool alreadyRolling = false;
    public bool waitForInput = true;

    int givingPoint = 3;
    private int numRoomCompleted;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

    }
    private void Start()
    {
        buttonCanvas.SetActive(false);
        ThiefButton.SetActive(false);
        //Commented this out so the game owuld run idk what happend......
        chosenRoom = deckShuffler.firstCard();
        Debug.Log("first card is " + chosenRoom);
        chosenRoom = 0;
        
        
    }
    private void Update()
    {
       
    }
    public void GameLoop()
    {
        if (!selectingRoom)
        {
            if (!alreadyRolling)
            {
                alreadyRolling = true;
                //Debug.Log("space");
                if (currentPlayer < 4)
                {
                    //Debug.Log("space pressed and it is " + currentPlayer + "  players turn");
                    playerRolls[currentPlayer] = gameController.Roll();
                    if (currentPlayer == 3)
                    {

                    }
                    currentPlayer++;
                }

                if (currentPlayer == 4)
                {
                    selectingRoom = true;
                    
                    SortResults();
                    CheckWinRoom();
                    buttonCanvas.SetActive(true);
                    checkDrawnCard();
                    waitForInput = true;
                    currentPlayer = 0;
                }
                alreadyRolling = false;
            }
        }




    }
    
    private void SortResults()
    {
        for (int i = 0; i <= 3; i++)
        {
            for (int k = 0; k <= 3; k++)
            {
                if (playerRolls[i] > playerRolls[k])
                {
                    int temp = playerRolls[i];
                    playerRolls[i] = playerRolls[k];
                    playerRolls[k] = temp;

                    temp = sortingArray[i];
                    sortingArray[i] = sortingArray[k];
                    sortingArray[k] = temp;
                }


            }
        }
        for(int i = 0; i <= 3; i++)
        {
            //Debug.Log("Player " + sortingArray[i] + " rolled " + playerRolls[i]);
        }
    }
   private void CheckWinRoom()
    {
        challengeInfo = challengeDeck.ChosenRoom(chosenRoom);
        //check if all tied
        if(playerRolls[0] == playerRolls[3])
        {
            Debug.Log("everyone Tied");
        }
        //check if 3 tied
        else if(playerRolls[0] == playerRolls[2])
        {
            Debug.Log("3 people tied");
        }
        //check if two tied
        else if(playerRolls[0] == playerRolls[1])
        {
            Debug.Log("2 people tied");
        }
        else
        {
            for (int i = 0; i <= 3; i++)
            {
                if(playerRolls[i] < 5)//player failed
                {
                    switch (sortingArray[i])
                    {
                        case 0:
                            players[0].GetComponent<Magician>().PlayerClass.hurt(1);
                            break;
                        case 1:
                            players[1].GetComponent<Knight>().PlayerClass.hurt(1);
                            break;
                        case 2:
                            players[2].GetComponent<Thief>().PlayerClass.hurt(1);
                            break;
                        case 3:
                            players[3].GetComponent<Human>().PlayerClass.hurt(1);
                            break;
                    }
                }
                else//player won
                {
                    points[sortingArray[i] - 1] += givingPoint;
                    givingPoint--;
                }

            }
            givingPoint = 3;
        }

        
        
        for(int i = 0; i <= 3; i++)
        {
            playerRolls[i] = 0;
            sortingArray[i] = i +1;
        }
    }

    
    public void SelectionMade(int selection)
    {

        if (selectingRoom && !waitForInput)
        {
            waitForInput = true;
            if (selection == 1)
            {
                chosenRoom = newCards[0];
                discardedRoom = newCards[1];
                Debug.Log("discarded card 2");
            }
            else if (selection == 2)
            {
                chosenRoom = newCards[1];
                discardedRoom = newCards[0];
                Debug.Log("discarded card 1");
            }

            buttonCanvas.SetActive(false);
            deckShuffler.ReformDeck(discardedRoom);
            discardedRoom = 0;

            selectingRoom = false;
        }
    }

    private void checkDrawnCard()
    {
        newCards = deckShuffler.DrawnCards();
        
    }
}
