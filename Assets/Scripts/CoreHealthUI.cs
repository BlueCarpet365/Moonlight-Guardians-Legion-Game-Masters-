using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoreHealthUI : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    private Slider healthBar;

    private void Start()
    {
        healthBar = GetComponent<Slider>();
    }

    public void UpdateHealth()
    {
        healthText.text = "Core Health: " + healthBar.value + "/" + healthBar.maxValue;
    }
}
