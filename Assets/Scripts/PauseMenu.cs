using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;
    public AudioSource musicAudioSource; // Reference to the AudioSource component responsible for playing music

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        // Find the AudioSource component in the scene
        musicAudioSource = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            QuitGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        // Pause the music
        if (musicAudioSource != null)
        {
            musicAudioSource.Pause();
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        // Resume the music
        if (musicAudioSource != null)
        {
            musicAudioSource.UnPause();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
