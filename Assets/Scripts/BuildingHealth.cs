using UnityEngine;
using UnityEngine.UI;

public class BuildingHealth : MonoBehaviour
{
    public float startHealth = 100f; // Starting health of the building
    public GameObject healthBar; // Reference to the health bar GUI object

    private float currentHealth; // Current health of the building

    void Start()
    {
        currentHealth = startHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        // Update health bar
        UpdateHealthBar();

        // Check if the building is destroyed
        if (currentHealth <= 0)
        {
            DestroyBuilding();
        }
    }

    // Method to update the health bar GUI
    void UpdateHealthBar()
    {
        // Calculate fill amount for the health bar
        float fillAmount = currentHealth / startHealth;

        // Set the fill amount for the health bar GUI
        healthBar.GetComponent<Image>().fillAmount = fillAmount;
    }

    // Method to destroy the building
    void DestroyBuilding()
    {
        // Destroy the GameObject associated with this script
        Destroy(gameObject);
    }
}
