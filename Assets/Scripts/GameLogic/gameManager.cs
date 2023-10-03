using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;
   

    public  DeckShuffler deckShuffler;
    public ChallengeDeck challengeDeck;

    public GameObject[] players = new GameObject[4];
    
    public int currentPlayer;
    private int[] newCards = new int[2];
    private int chosenRoom, discardedRoom;
    
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
        
        
        GameLoop();
    }
    private void GameLoop()
    {
        Debug.Log("first room");
        chosenRoom = deckShuffler.firstCard();
       challengeDeck.ChosenRoom(chosenRoom);
       Debug.Log("Second Room");
        checkDrawnCard();
        challengeDeck.ChosenRoom(newCards[0]);
        challengeDeck.ChosenRoom(newCards[1]);
        deckShuffler.ReformDeck(newCards[0]);
        checkDrawnCard();
        deckShuffler.ReformDeck(newCards[0]);



    }

    
    private void checkDrawnCard()
    {
        newCards = deckShuffler.DrawnCards();

        Debug.Log(newCards[0]);
        Debug.Log(newCards[1]);
    }
}
