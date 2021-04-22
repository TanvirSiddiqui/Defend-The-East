using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;
     public bool CreateTower(Tower tower, Vector3 position) 
    {
        Goldmine goldmine = FindObjectOfType<Goldmine>();

        if (goldmine == null) { return false; }
        if (goldmine.CurrentBalance >= cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            goldmine.Withdraw(cost);
            return true;
        }
        return false;
    }
}
