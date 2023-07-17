using System;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private int _cost = 75;

    public bool Create(Tower towerPrefab, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null)
        {
            return false;
        }

        if (bank.CurrentBalance >= _cost)
        {
            Instantiate(towerPrefab, position, Quaternion.identity);
            bank.Withdraw(_cost);  
            return true;
        }

        return false;
    }
}
