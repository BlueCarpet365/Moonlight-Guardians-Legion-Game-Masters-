using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int wood;
    [SerializeField] private int stone;
    [SerializeField] private TMP_Text woodText;
    [SerializeField] private TMP_Text stoneText;

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
