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
    public GameObject cardCanvas;
    public GameObject resetButton;
    public Camera gameCamera;


    public GameObject[] players = new GameObject[4];//players

    public int currentPlayer = 0;//current players turn


    private int[] newCards = new int[2];//current cards waiting to be chosen

    private int[] challengeInfo = new int[2];//the details of the current challenge

    private string[] cardDescription = new string[6] {
        "Bully Slime Attacks!\n Roll your might vs 8\n losers take 3 damage", 
        "Test of Strength!\n Roll your Might vs 6\n losers pull a muscle and take 1 damage",
        "Cast a spell!\n Roll your Magic vs 7\n losers spell backfires hurting them for 1 damage",
        "you found locked treasures!\n roll your Might or Magic vs a random number between 4-9\n losers are embarassed and take 1 damage",
        "A mysterious room with unknown dangers\n roll your Might or Magic vs 8\n losers misplace their wallet and take 2 damage",
        "Test your luck!\n roll 2d6 with no bonuses vs 0\nlosers are dissapointed but take no damage" };

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
    [SerializeField] private TextMeshProUGUI card1Text, card2Text, scorekeeper;


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
        resetButton.SetActive(false);
        cardCanvas.SetActive(false);
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
        
        if (!selectingRoom)
        {
            Debug.Log("it is player " + currentPlayer + " turn");
            if (!alreadyRolling)
            {
                    
            alreadyRolling = true;
            //Debug.Log("space");
            if (currentPlayer < 4 && numRoomCompleted != 5)
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
                    mainText.text = ("You Rolled: " + playerRolls[currentPlayer] + "\nWould You Like To ReRoll?");

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
            }else if(numRoomCompleted == 5)
                {
                    EndGame();
                }
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
        mainText.text = "Thief ReRolled: " + playerRolls[currentPlayer];
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
                            scorekeeper.text += "Magician died and lost 1 point\n";
                            players[0].GetComponent<Magician>().PlayerClass.stamina = 3;
                            points[0]--;
                        }
                        else
                        {
                            scorekeeper.text += "Magician Failed the challenge and lost" + challengeInfo[1] + " stamina\n";
                        }
                        break;
                    case 1:
                        players[1].GetComponent<Knight>().PlayerClass.hurt(challengeInfo[1]);
                        if (players[1].GetComponent<Knight>().PlayerClass.stamina <= 0)
                        {
                            scorekeeper.text += "Knight died and lost 1 point\n";
                            players[1].GetComponent<Knight>().PlayerClass.stamina = 3;
                            points[1]--;
                        }
                        else
                        {
                            scorekeeper.text += "Knight Failed the challenge and lost" + challengeInfo[1] + " stamina\n";
                        }
                        break;
                    case 2:
                        players[2].GetComponent<Thief>().PlayerClass.hurt(challengeInfo[1]);
                        if (players[2].GetComponent<Thief>().PlayerClass.stamina <= 0)
                        {
                            scorekeeper.text += "Thief died and lost 1 point\n";
                            players[2].GetComponent<Thief>().PlayerClass.stamina = 3;
                            points[2]--;
                        }
                        else
                        {
                            scorekeeper.text += "Thief Failed the challenge and lost" + challengeInfo[1] + " stamina\n";
                        }
                        break;
                    case 3:
                        players[3].GetComponent<Human>().PlayerClass.hurt(challengeInfo[1]);
                        if (players[3].GetComponent<Human>().PlayerClass.stamina <= 0)
                        {
                            scorekeeper.text += "Human died and lost 1 point\n";
                            players[3].GetComponent<Human>().PlayerClass.stamina = 3;
                            points[3]--;
                        }
                        else
                        {
                            scorekeeper.text += "Human Failed the challenge and lost" + challengeInfo[1] + " stamina\n";
                        }
                        break;
                }
            }

            else//player won
            {
                scorekeeper.text += players[sortingArray[i] - 1].name + "scored: " + givingPoint + " points\n";
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
        cardCanvas.SetActive(false);
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

            scorekeeper.text = "";
            selectingRoom = false;
            nextPos += 8;
            gameCamera.transform.position = new Vector3(0, nextPos, -10);//moves camera
            for(int i = 0; i <= 3; i++)
            {
                players[i].transform.position = new Vector3(players[i].transform.position.x,players[i].transform.position.y + 8, players[i].transform.position.z);
            }
        }
    }

    private void checkDrawnCard()
    {
        if (numRoomCompleted < 5)
        {
            newCards = deckShuffler.DrawnCards();
        }
        mainText.text = "";
        cardCanvas.SetActive(true);

        card1Text.text = cardDescription[newCards[0]];
        card2Text.text = cardDescription[newCards[1]];



    }

    private void EndGame()
    {
        Inputs.MenuMode();
        resetButton.SetActive(true);
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
            //Debug.Log("player " + sortingArray[i] + "got " + (i+1) + " place with " + points[i]);
            scorekeeper.text += "player " + sortingArray[i] + "got " + (i + 1) + " place with " + points[i] + "\n";
            points[i] = 0;
            playerRolls[i] = 0;
            sortingArray[i] = i + 1;
        }
        
        
    }
    
   
}
