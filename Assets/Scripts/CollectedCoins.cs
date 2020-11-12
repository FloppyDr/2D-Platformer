using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedCoins : MonoBehaviour
{
    [SerializeField] private Text _amountOfCoins;

    private int _collectedCoins;

    public void AddCoin()
    {
        _collectedCoins++;
        _amountOfCoins.text = _collectedCoins.ToString();
    }
}
