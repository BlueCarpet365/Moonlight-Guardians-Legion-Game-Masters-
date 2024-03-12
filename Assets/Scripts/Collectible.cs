using UnityEngine;

public class Collectible : MonoBehaviour
{
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
            FindObjectOfType<Inventory>().AddResource(Type, Quantity);
            gameObject.SetActive(false);
        }
    }
}
