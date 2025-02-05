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
    private GameObject towerObj;
    public Turret turret;
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
        if(UIManager.main.IsHoveringUI()) 
            return;
            
        if (towerObj != null)
        {
            turret.OpenUpgradeUI();
            return;
        }

        Tower selectedTower = BuildManager.main.GetSelectedTower();

        if (selectedTower.cost > LevelManager.main.budget)
        {
            return;
        }

        LevelManager.main.SpendBudget(selectedTower.cost);
        towerObj = Instantiate(selectedTower.prefab, transform.position, Quaternion.identity);
        turret = towerObj.GetComponent<Turret>();
    }
}
