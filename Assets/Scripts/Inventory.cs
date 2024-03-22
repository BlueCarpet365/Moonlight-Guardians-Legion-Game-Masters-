using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public AudioClip triggerSound;
    private AudioSource audioSource;
    [SerializeField] private int wood;
    [SerializeField] private int stone;
    [SerializeField] private TMP_Text woodText;
    [SerializeField] private TMP_Text stoneText;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = triggerSound;
    }

    public void AddResource(Collectible.ItemType itemType, int quantity)
    {
        switch (itemType)
        {
            case Collectible.ItemType.Wood:
                wood += quantity;
                break;
            case Collectible.ItemType.Stone:
                stone += quantity;
                break;
        }

        if (quantity > 0)
            audioSource.PlayOneShot(triggerSound);

        UpdateUIValues();
    }

    public bool CanBuild(Collectible.ItemType itemType, int quantity)
    {
        switch (itemType)
        {
            case Collectible.ItemType.Wood:
                if (wood >= quantity)
                {
                    return true;
                }
                break;
            case Collectible.ItemType.Stone:
                if (stone >= quantity)
                {
                    return true;
                }
                break;
        }
        return false;
    }

    private void UpdateUIValues()
    {
        woodText.text = "Wood: " + wood.ToString();
        stoneText.text = "Stone: " + stone.ToString();
    }
}
