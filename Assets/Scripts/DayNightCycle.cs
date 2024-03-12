using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sunLight;
    public float dayLengthSeconds = 10f;
    public float nightLengthSeconds = 10f;
    public float fadeDuration = 2f; // Duration for the light fade

    private float currentCycleTime;
    public bool isDaytime { get; private set; } = true;
    private float fadeStartTime; // Time when fade starts

    private void Start()
    {
        currentCycleTime = 0f;
        UpdateLightIntensity();
    }

    private void Update()
    {
        // Update the time
        currentCycleTime += Time.deltaTime;

        // Check if it's daytime
        if (isDaytime && currentCycleTime > dayLengthSeconds)
        {
            isDaytime = false;
            currentCycleTime = 0f;
            fadeStartTime = Time.time; // Start the fade
        }
        else if (!isDaytime && currentCycleTime > nightLengthSeconds)
        {
            isDaytime = true;
            currentCycleTime = 0f;
            fadeStartTime = Time.time; // Start the fade
        }

        // Update light intensity based on day or night
        UpdateLightIntensity();
    }

    private void UpdateLightIntensity()
    {
        if (isDaytime)
        {
            // Daytime logic: Fade in
            float elapsedTime = Time.time - fadeStartTime;
            float fadeProgress = Mathf.Clamp01(elapsedTime / fadeDuration);
            sunLight.intensity = Mathf.Lerp(0f, 1f, fadeProgress);
        }
        else
        {
            // Nighttime logic: Fade out
            float elapsedTime = Time.time - fadeStartTime;
            float fadeProgress = Mathf.Clamp01(elapsedTime / fadeDuration);
            sunLight.intensity = Mathf.Lerp(1f, 0f, fadeProgress);
        }
    }
}
