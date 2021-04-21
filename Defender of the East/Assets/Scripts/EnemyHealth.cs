using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;
    [SerializeField] int currentHitPoint;
    void OnEnable()
    {
        currentHitPoint = maxHitPoint;
    }

     void OnParticleCollision(GameObject other)
    {
        CalculateHit();
    }

    void CalculateHit()
    {
        currentHitPoint--;
        if (currentHitPoint <= 0)
        {

            gameObject.SetActive(false);
        }
    }
}
