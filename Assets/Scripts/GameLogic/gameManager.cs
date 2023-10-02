using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;

    public GameObject[] players = new GameObject[4];

    public int currentPlayer;
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

    }

}
