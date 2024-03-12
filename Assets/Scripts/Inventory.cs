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

    private void UpdateUIValues()
    {
        woodText.text = "Wood: " + wood.ToString();
        stoneText.text = "Stone: " + stone.ToString();
    }
}
