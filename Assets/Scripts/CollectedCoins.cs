using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedCoins : MonoBehaviour
{
    [SerializeField] private Text text;

    private AudioSource _coinSound;
    private Coin[] coins;
    private int _collectedCoins;

    private void OnEnable()
    {
        coins = gameObject.GetComponentsInChildren<Coin>();

        foreach (var coin in coins)
        {
            coin.Collected += OnCoinCollected;
        }
    }

    private void OnDisable()
    {
        foreach (var coin in coins)
        {
            coin.Collected -= OnCoinCollected;
        }
    }

    private void OnCoinCollected()
    {
        _collectedCoins++;
        text.text = _collectedCoins.ToString();
    }
}
