using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PauseHandler : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameState gameState;
    [SerializeField] AudioLowPassFilter audioLowPassFilter;

    public float cutoffFrequency = 500f;

    private bool isPaused = false;
    private float audioLowPassFilterTempValue = 0f;

    // Update is called once per frame
    void Update()
    {  
        // Escape is pause key (once) (and not won)
        if(Input.GetKeyDown(KeyCode.Escape) && !gameState.getHasWon()) {
            isPaused = !isPaused;

            pauseMenu.SetActive(isPaused);

            if(isPaused) {
                // Low pass the audio
                audioLowPassFilterTempValue = audioLowPassFilter.cutoffFrequency;
                audioLowPassFilter.cutoffFrequency = cutoffFrequency;

                // Pause the game
                Time.timeScale = 0f;
            } else {
                // Put the low pass back to its original value
                audioLowPassFilter.cutoffFrequency = audioLowPassFilterTempValue;

                // Play the game
                Time.timeScale = 1f;
            }
        }
    }
}
