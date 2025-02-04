using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;
    public int budget;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        budget = 100;
    }

    public void IncreaseBudget(int amount)
    {
        budget += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if (amount < budget)
        {
            //buy
            budget -= amount;
            return true;
        }
        else
        {
            Debug.Log("Not enough money.");
            return false;
        }
    }

}
