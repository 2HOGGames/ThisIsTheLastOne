using System.Linq;
using TMPro;
using UnityEngine;

public class changeStat : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statNumber;
    [SerializeField] private Magician magician;

    public void changeValue()
    {
        statNumber.text = (magician.PlayerClass.result.Min() + magician.PlayerClass.magic).ToString();
    }
}
