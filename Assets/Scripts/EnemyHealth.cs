using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float healthPoint = 4;
    [SerializeField] private int destroyPrize = 32;

    private bool isDestroyed = false;

    public void TakeDamage(float damage)
    {
        healthPoint -= damage;

        if (healthPoint <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.IncreaseBudget(destroyPrize);
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
