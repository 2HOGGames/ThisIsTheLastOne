using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action<int> changeEye;
    public static event Action defaultEye;
    public static event Action SwitchRoomStatType;

    public void SwitchStat()
    {
        SwitchRoomStatType?.Invoke();
    }
}
