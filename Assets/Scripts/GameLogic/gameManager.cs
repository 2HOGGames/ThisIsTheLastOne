using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;
   

    public  DeckShuffler deckShuffler;
    public ChallengeDeck challengeDeck;
    public GameController gameController;

    public GameObject[] players = new GameObject[4];
    
    public int currentPlayer;
    private int[] newCards = new int[2];
    private int[] challengeInfo = new int[3];
    private int[] playerRolls = new int [4];
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
        roomCompleted = false;
        //GameLoop();
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
    private void GameLoop()
    {


       
            if (!roomCompleted)
            {
                challengeInfo = challengeDeck.ChosenRoom(chosenRoom);
                
            }
            else if (roomCompleted)
            {
                numRoomCompleted++;
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

            }
        



    }

    private void activeChallenge()
    {
        while (!roomCompleted)
        {
            for(int i = 0; i <= 3; i++)
            {
                
            }

        }
    }


    private void checkDrawnCard()
    {
        newCards = deckShuffler.DrawnCards();
        
       // Debug.Log(newCards[0]);
        //Debug.Log(newCards[1]);
    }
}
