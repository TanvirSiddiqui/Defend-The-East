using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;

    Goldmine goldmine;

     void Start()
    {
        goldmine = FindObjectOfType<Goldmine>();
    }
    public void RewardGold()
    {
        if (goldmine == null) { return; }
        goldmine.Deposit(goldReward);
    }
    public void SteelGold()
    {
        if (goldmine == null) { return; }
        goldmine.Withdraw(goldPenalty);
    }
}
