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
    private bool isDead = false;
    public int damage = 10; // Damage dealt by the enemy
    public float damageInterval = 3f; // Interval between each damage
    private bool canDealDamage = true; // Flag to control damage dealing
    private Animator animator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        FindAndSetTarget();
        health = startHealth;
    }

    void Update()
    {
        if (canDealDamage && health > 0)
        {
            canDealDamage = false;
            Invoke("EnableDamage", damageInterval); // Enable damage dealing after the interval
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Building"))
        {
            BuildingHealth building = collision.gameObject.GetComponent<BuildingHealth>();
            if (building != null)
            {
                building.TakeDamage(damage);
            }
            animator.SetBool("isAttacking", true);
            animator.SetBool("isMoving", false);
        }
    }

    void OnCollisionExit(Collision other)
    {
        animator.SetBool("isAttacking", false);
        animator.SetBool("isMoving", true);
    }

    void EnableDamage()
    {
        canDealDamage = true;
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        health -= amount;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetBool("isDeath", true);
        GameObject effect = Instantiate(enemyDE, transform.position, Quaternion.identity);
        Destroy(effect, 0.7f);
        Destroy(gameObject);
    }

    void FindAndSetTarget()
    {
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");

        if (buildings.Length > 0)
        {
            GameObject randomBuilding = buildings[Random.Range(0, buildings.Length)];
            navMeshAgent.SetDestination(randomBuilding.transform.position);
            animator.SetBool("isMoving", true);
        }
        else
        {
            Debug.LogWarning("No buildings found with the 'Building' tag!");
        }
    }
}
