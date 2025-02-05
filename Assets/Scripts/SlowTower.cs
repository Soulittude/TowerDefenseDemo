using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SlowTower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask enemyMask;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float attacksPerSecond = 4f;
    [SerializeField] private float freezeDuration = 0.25f;
    [SerializeField] private float slowPower = 3f;

    private float timeUntilFire;


    private void Update()
    {
        timeUntilFire += Time.deltaTime;

        if (timeUntilFire >= 1f / attacksPerSecond)
        {
            Freeze();
            timeUntilFire = 0f;
        }
    }

    private void OnDrawGizmosSelected()
    {

        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }

    private void Freeze()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange,
        (Vector2)transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];

                EnemyMovement em = hit.transform.GetComponent<EnemyMovement>();
                em.UpdateSpeed(1 - slowPower / 10); //Slow; speed reduce multiplier calculation

                StartCoroutine(ResetFreeze(em));
            }
        }
    }

    private IEnumerator ResetFreeze(EnemyMovement em)
    {
        yield return new WaitForSeconds(freezeDuration);

        em.ResetSpeed();
    }
}
