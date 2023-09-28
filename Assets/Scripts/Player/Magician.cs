using UnityEngine;

public class Magician : MonoBehaviour
{
    [SerializeField] private Player magician;

    private void LuckySeven()
    {
        if (magician.results[0] + magician.results[1] == 7)
        {
            magician.heal(2);
        }
    }
}
