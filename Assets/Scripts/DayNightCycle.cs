using TMPro;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public int dayCount = 1;
    public Light sunLight;
    public float dayLengthSeconds = 10f;
    public float nightLengthSeconds = 10f;
    public float fadeDuration = 2f;

    private float currentCycleTime;
    public bool isDaytime { get; private set; } = true;
    private float fadeStartTime;
    [SerializeField] private CollectibleSpawner collectibleSpawner;
    [SerializeField] private TMP_Text dayText;

    private void Start()
    {
        dayCount = 1;
        dayText.text = "Day " + dayCount;
        currentCycleTime = 0f;
        UpdateLightIntensity();
    }

    private void Update()
    {
        currentCycleTime += Time.deltaTime;

        if (isDaytime && currentCycleTime > dayLengthSeconds)
        {
            isDaytime = false;
            currentCycleTime = 0f;
            fadeStartTime = Time.time;
            OnDayNightChange?.Invoke(isDaytime);
        }
        else if (!isDaytime && currentCycleTime > nightLengthSeconds)
        {
            isDaytime = true;
            currentCycleTime = 0f;
            fadeStartTime = Time.time;
            OnDayNightChange?.Invoke(isDaytime);
            collectibleSpawner.SpawnResources();
            dayText.text = "Day " + ++dayCount;
        }

        UpdateLightIntensity();
    }

    private void UpdateLightIntensity()
    {
        if (isDaytime)
        {
            float elapsedTime = Time.time - fadeStartTime;
            float fadeProgress = Mathf.Clamp01(elapsedTime / fadeDuration);
            sunLight.intensity = Mathf.Lerp(0f, 1f, fadeProgress);
        }
        else
        {
            float elapsedTime = Time.time - fadeStartTime;
            float fadeProgress = Mathf.Clamp01(elapsedTime / fadeDuration);
            sunLight.intensity = Mathf.Lerp(1f, 0f, fadeProgress);
        }
    }

    public delegate void DayNightChange(bool isDaytime);
    public static event DayNightChange OnDayNightChange;
}
