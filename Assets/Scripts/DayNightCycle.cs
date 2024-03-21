using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sunLight;
    public float dayLengthSeconds = 10f;
    public float nightLengthSeconds = 10f;
    public float fadeDuration = 2f;

    private float currentCycleTime;
    public bool isDaytime { get; private set; } = true;
    private float fadeStartTime;
    [SerializeField] private CollectibleSpawner collectibleSpawner;

    private void Start()
    {
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
