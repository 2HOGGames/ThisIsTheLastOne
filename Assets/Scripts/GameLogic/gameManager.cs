using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;
   

    public  DeckShuffler deckShuffler;
    public ChallengeDeck challengeDeck;
    public GameController gameController;


    public GameObject[] players = new GameObject[4];
    
    public int currentPlayer = 0;
    private int[] newCards = new int[2];
    private int[] challengeInfo = new int[3];
    [SerializeField]private int[] playerRolls = new int [4];
   [SerializeField] private int[] points = new int[4];
    private int[] sortingArray = new int[] { 1, 2, 3, 4 };
    private int chosenRoom, discardedRoom;
    private bool selectingRoom = false;
    private bool roomCompleted = false;

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

        //Commented this out so the game owuld run idk what happend......
        //chosenRoom = deckShuffler.firstCard();
        chosenRoom = 0;
        roomCompleted = false;
        
    }
    private void Update()
    {
        /*if(!roomCompleted){
            challengeDeck.ChosenRoom(chosenRoom);
        } else if (roomCompleted)
        {
            selectingRoom = true;
        }
        if (selectingRoom)
        {
            checkDrawnCard();
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                chosenRoom = newCards[0];
                discardedRoom = newCards[1];
                selectingRoom = false;
                deckShuffler.ReformDeck(discardedRoom);
                challengeDeck.ChosenRoom(chosenRoom);

            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                chosenRoom = newCards[1];
                discardedRoom = newCards[0];
                selectingRoom = false;
                deckShuffler.ReformDeck(discardedRoom);
                challengeDeck.ChosenRoom(chosenRoom);
            }
            
        }*/
    }
    public void GameLoop()
    {
        //Debug.Log("space");
        if(currentPlayer < 4)
        {
            //Debug.Log("space pressed and it is " + currentPlayer + "  players turn");
            playerRolls[currentPlayer] = gameController.Roll();
            currentPlayer++;
        }
        if(currentPlayer == 4)
        {
            SortResults();
            currentPlayer = 0;
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
            Debug.Log("Player " + sortingArray[i] + " rolled " + playerRolls[i]);
        }
    }
   private void CheckWinRoom()
    {
        challengeInfo = challengeDeck.ChosenRoom(chosenRoom);

        

    }




    private void checkDrawnCard()
    {
        newCards = deckShuffler.DrawnCards();
        
       // Debug.Log(newCards[0]);
        //Debug.Log(newCards[1]);
    }
}
