using System;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public static event Action OnAnyKill;

    public void KillMonster()
    {
        Debug.Log("Kill Monster");
        OnAnyKill?.Invoke();
    }
}
