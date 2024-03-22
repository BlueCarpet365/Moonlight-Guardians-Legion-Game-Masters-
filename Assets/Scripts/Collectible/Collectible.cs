using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioClip triggerSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = triggerSound;
    }

    public enum ItemType
    {
        Wood,
        Stone,
    }

    public int Quantity;
    public ItemType Type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audioSource.PlayOneShot(triggerSound);
            FindObjectOfType<Inventory>().AddResource(Type, Quantity);
            Destroy(gameObject);
        }
    }
}
