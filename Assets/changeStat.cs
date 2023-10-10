using System.Linq;
using TMPro;
using UnityEngine;

public class changeStat : MonoBehaviour
{
    [SerializeField] private RollTheDice rollTheDice;
    [SerializeField] private TextMeshProUGUI statText;

    public void changeValue()
    {
        statText.text = (rollTheDice.result.Max() + 3).ToString();
    }
}
