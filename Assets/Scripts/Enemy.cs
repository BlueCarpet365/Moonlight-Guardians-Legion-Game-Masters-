// Enemy script
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public float startHealth = 100;
    private float health;
    public GameObject enemyDE;
    public Image healthBar;

    // Add a boolean to track whether the enemy is dead
    private bool isDead = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        FindAndSetTarget();
        health = startHealth;
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return; // If the enemy is already dead, exit the method

        health -= amount;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true; // Mark the enemy as dead to prevent further damage
        GameObject effect = Instantiate(enemyDE, transform.position, Quaternion.identity);
        Destroy(effect, 0.7f);
        Destroy(gameObject);
    }

    void Update()
    {
        if (navMeshAgent.destination == transform.position)
        {
            FindAndSetTarget();
        }
    }

    void FindAndSetTarget()
    {
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");

        if (buildings.Length > 0)
        {
            GameObject randomBuilding = buildings[Random.Range(0, buildings.Length)];
            navMeshAgent.SetDestination(randomBuilding.transform.position);
        }
        else
        {
            Debug.LogWarning("No buildings found with the 'Building' tag!");
        }
    }
}
