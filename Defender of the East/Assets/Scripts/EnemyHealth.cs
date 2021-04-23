using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;

    [Tooltip("Adds amount to maximumHitPoints when enemy dies. ")]
    [SerializeField] int difficultyRamp = 1;

    int currentHitPoint;

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
            maxHitPoint += difficultyRamp;
            gameObject.SetActive(false);
            Debug.Log(maxHitPoint);
        }
    }
}
