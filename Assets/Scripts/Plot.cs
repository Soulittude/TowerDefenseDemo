using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    private GameObject tower;
    private Color startColor;

    private void Start()
    {
        startColor = sr.color;
    }

    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if (tower != null)
            return;

        Tower selectedTower = BuildManager.main.GetSelectedTower();

        if (selectedTower.cost > LevelManager.main.budget)
        {
            return;
        }

        LevelManager.main.SpendBudget(selectedTower.cost);
        tower = Instantiate(selectedTower.prefab, transform.position, Quaternion.identity);
    }
}
