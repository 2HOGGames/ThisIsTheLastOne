using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;
   

    public  DeckShuffler deckShuffler;
    public ChallengeDeck challengeDeck;

    public GameObject[] players = new GameObject[4];
    
    public int currentPlayer;
    private int[] newCards = new int[2];
    
    
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
        
        checkDrawnCard();
    }
    private void GameLoop()
    {
       
       





    }

    
    private void checkDrawnCard()
    {
        newCards = deckShuffler.DrawnCards();

        Debug.Log(newCards[0]);
        Debug.Log(newCards[1]);
    }
}
