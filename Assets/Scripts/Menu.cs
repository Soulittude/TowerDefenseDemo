using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI budgetUI;
    [SerializeField] Animator animator;

    private bool isMenuOpen = true;

    public void ToggleMenu() {
        isMenuOpen = !isMenuOpen;
        animator.SetBool("isMenuOpen", isMenuOpen);
    }

    private void OnGUI()
    {
        budgetUI.text = "Budget: " + LevelManager.main.budget.ToString();
    }

    public void SetSelected()
    {
        
    }
}
