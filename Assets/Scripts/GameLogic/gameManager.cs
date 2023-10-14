using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;


    public DeckShuffler deckShuffler;//deck shuffling object
    public ChallengeDeck challengeDeck;//chellenge deck object
    public GameController gameController;//game controller object


    public GameObject buttonCanvas;
    public GameObject ThiefButton;
    public Camera gameCamera;


    public GameObject[] players = new GameObject[4];//players

    public int currentPlayer = 0;//current players turn


    private int[] newCards = new int[2];//current cards waiting to be chosen

    private int[] challengeInfo = new int[2];//the details of the current challenge

    [SerializeField] private int[] playerRolls = new int[4];//what each player rolled

    [SerializeField] private int[] points = new int[4];//how many points each player has

    private int[] sortingArray = new int[] { 1, 2, 3, 4 };//keeps player rolls position during sorting

    private int chosenRoom, discardedRoom;//room chosen and room discarded

    private int nextPos;

    public bool selectingRoom = false;//failsafe so things cahnt happen until a room is selected
    private bool alreadyRolling = false;
    public bool waitForInput = true;
    public bool waitForThief = false;
    //public bool thiefChoice;

    int givingPoint = 3;
   [SerializeField] private int numRoomCompleted;

    private TextMeshProUGUI mainText;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;


        mainText = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        buttonCanvas.SetActive(false);
        ThiefButton.SetActive(false);
        //Commented this out so the game owuld run idk what happend......
        chosenRoom = deckShuffler.firstCard();
        challengeInfo = challengeDeck.ChosenRoom(chosenRoom);
        Debug.Log("first card is " + chosenRoom);


        

    }
    private void Update()
    {
       
    }
    public void GameLoop()
    {
        
        if (!selectingRoom && numRoomCompleted != 5)
        {
            Debug.Log("it is player " + currentPlayer + " turn");
            if (!alreadyRolling)
            {
                    
            alreadyRolling = true;
            //Debug.Log("space");
            if (currentPlayer < 4)
            {
                //Debug.Log("space pressed and it is " + currentPlayer + "  players turn");
                if (chosenRoom == 5)
                {
                        //luck room
                        //Debug.Log("Luck roll");
                    playerRolls[currentPlayer] = gameController.LuckRoll();
                }
                else
                {
                        //Debug.Log("notLuckRoom");
                    playerRolls[currentPlayer] = gameController.Roll();
                }
                    Debug.Log("you rolled " + playerRolls[currentPlayer] + " your Target is " + challengeInfo[0]);
                    mainText.text = ("You Rolled: " + playerRolls[currentPlayer]);
                if (currentPlayer == 2)
                {
                    waitForThief = true;
                    Inputs.MenuMode();
                    Debug.Log("thief may reroll");
                    ThiefButton.SetActive(true);
                    mainText.text = ("You Rolled A: " + playerRolls[currentPlayer] + "\nWould You Like To ReRoll?");

                }
                currentPlayer++;
            }

            if (currentPlayer == 4 && numRoomCompleted != 5)
            {
                selectingRoom = true;

                SortResults();
                CheckWinRoom();
                Inputs.MenuMode();
                buttonCanvas.SetActive(true);
                checkDrawnCard();
                waitForInput = true;
                currentPlayer = 0;
            }/*else if(numRoomCompleted == 5)
                {
                    EndGame();
                }*/
            alreadyRolling = false;
                    
            }
            
        }




    }
    public void ThiefMenuOff()
    {
        ThiefButton.SetActive(false);
    }

    public void ThiefReroll()
    {
        
        currentPlayer = 2;
        if (chosenRoom == 5)
        {
            playerRolls[currentPlayer] = gameController.LuckRoll();
        }
        else
        {
            playerRolls[currentPlayer] = gameController.Roll();
        }
        ThiefButton.SetActive(false);
        Debug.Log("Thief Rerolled for" + playerRolls[currentPlayer]);
        mainText.text = "Theif ReRolled For A " + playerRolls[currentPlayer];
        currentPlayer++;
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
        numRoomCompleted++;
        //check if all tied
        
        
        for (int i = 0; i <= 3; i++)
            {
            if (playerRolls[i] < challengeInfo[0])//player failed
            {
                Debug.Log("Damaging" + players[sortingArray[i] - 1].name);
                switch (sortingArray[i] - 1)
                {

                    case 0:
                        players[0].GetComponent<Magician>().PlayerClass.hurt(challengeInfo[1]);
                        if (players[0].GetComponent<Magician>().PlayerClass.stamina <= 0)
                        {
                            Debug.Log("magician died and lost 1 point");
                            players[0].GetComponent<Magician>().PlayerClass.stamina = 3;
                            points[0]--;
                        }
                        break;
                    case 1:
                        players[1].GetComponent<Knight>().PlayerClass.hurt(challengeInfo[1]);
                        if (players[1].GetComponent<Knight>().PlayerClass.stamina <= 0)
                        {
                            Debug.Log("Knight died and lost 1 point");
                            players[1].GetComponent<Knight>().PlayerClass.stamina = 3;
                            points[1]--;
                        }
                        break;
                    case 2:
                        players[2].GetComponent<Thief>().PlayerClass.hurt(challengeInfo[1]);
                        if (players[2].GetComponent<Thief>().PlayerClass.stamina <= 0)
                        {
                            Debug.Log("Thief died and lost 1 point");
                            players[2].GetComponent<Thief>().PlayerClass.stamina = 3;
                            points[2]--;
                        }
                        break;
                    case 3:
                        players[3].GetComponent<Human>().PlayerClass.hurt(challengeInfo[1]);
                        if (players[3].GetComponent<Human>().PlayerClass.stamina <= 0)
                        {
                            Debug.Log("Knight died and lost 1 point");
                            players[3].GetComponent<Human>().PlayerClass.stamina = 3;
                            points[3]--;
                        }
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

        for (int i = 0; i <= 3; i++)
        {
           // playerRolls[i] = 0;
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
            challengeInfo = challengeDeck.ChosenRoom(chosenRoom);
            buttonCanvas.SetActive(false);
            deckShuffler.ReformDeck(discardedRoom);
            

            selectingRoom = false;
            nextPos += 8;
            gameCamera.transform.position = new Vector3(0, nextPos, -10);//moves camera
        }
    }

    private void checkDrawnCard()
    {
        if (numRoomCompleted < 5)
        {
            newCards = deckShuffler.DrawnCards();
        }
    }

    private void EndGame()
    {
        Inputs.MenuMode();
        for (int i = 0; i <= 3; i++)
        {
            for (int k = 0; k <= 3; k++)
            {
                if (points[i] > points[k])
                {
                    int temp = points[i];
                    points[i] = points[k];
                    points[k] = temp;

                    temp = sortingArray[i];
                    sortingArray[i] = sortingArray[k];
                    sortingArray[k] = temp;
                }


            }
        }
        
       
        for ( int i = 0; i <= 3; i++)
        {
            Debug.Log("player " + sortingArray[i] + "got " + (i+1) + " place with " + points[i]);
            points[i] = 0;
            playerRolls[i] = 0;
            sortingArray[i] = i + 1;
        }
        deckShuffler.ResetDeck();
        numRoomCompleted = 0;
        currentPlayer = 0;
        chosenRoom = deckShuffler.firstCard();
        challengeInfo = challengeDeck.ChosenRoom(chosenRoom);
        Inputs.PlayMode();
    }
    
   
}
