using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goldmine : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }
    // Start is called before the first frame update
    void Awake()
    {
        currentBalance = startingBalance;
    }

    public void Deposit(int amount)
    {
        currentBalance +=Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
    }
}
