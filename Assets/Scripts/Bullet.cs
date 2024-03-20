using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;
    public int damage = 20;

    // Add a boolean to track whether the bullet has hit a target
    private bool hasHit = false;

    // Start is called before the first frame update
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasHit) return; // If the bullet has already hit a target, exit the method

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        hasHit = true; // Mark the bullet as having hit a target
        GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Damage(target);
        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }
}