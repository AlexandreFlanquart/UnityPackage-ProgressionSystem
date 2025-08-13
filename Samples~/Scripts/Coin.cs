using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event Action OnAnyCoinsclaim;

    public void ClaimCoin()
    {
        Debug.Log("claim coin");
        OnAnyCoinsclaim?.Invoke();
    }
}
