using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float healthPoint = 4;

    private bool isDestroyed = false;

    public void TakeDamage(float damage)
    {
        healthPoint -= damage;

        if (healthPoint <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            Destroy(gameObject);
            isDestroyed = true;
        }
    }
}
