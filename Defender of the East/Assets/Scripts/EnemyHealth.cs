using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;
    [SerializeField] int currentHitPoint;

    Enemy enemy;
    void OnEnable()
    {
        currentHitPoint = maxHitPoint;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
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
            enemy.RewardGold();
            gameObject.SetActive(false);
        }
    }
}
