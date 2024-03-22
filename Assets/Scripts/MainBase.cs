using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainBase : MonoBehaviour
{
    public float startHealth = 100f;
    public List<GameObject> healthBars; // List of health bar GameObjects
    private float currentHealth;

    void Start()
    {
        currentHealth = startHealth;
        UpdateHealthBars();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        UpdateHealthBars();
        if (currentHealth <= 0)
        {
            DestroyBase();
        }
    }

    void UpdateHealthBars()
    {
        // float fillAmount = currentHealth / startHealth;
        foreach (var healthBarObj in healthBars)
        {
            if (healthBarObj != null)
            {
                Slider slider = healthBarObj.GetComponent<Slider>();
                if (slider != null)
                {
                    slider.value = currentHealth;
                }
                else
                {
                    Debug.LogWarning("Health bar object does not have a Slider component: " + healthBarObj.name);
                }
            }
            else
            {
                Debug.LogWarning("Health bar object in the list is null.");
            }
        }
    }


    void DestroyBase()
    {
        Destroy(gameObject);
        GameOver.Instance.TriggerGameOver();
    }
}
