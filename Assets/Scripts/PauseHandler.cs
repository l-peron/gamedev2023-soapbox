using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] AudioLowPassFilter audioLowPassFilter;

    public float cutoffFrequency = 500f;

    private bool isPaused = false;
    private float audioLowPassFilterTempValue = 0f;

    // Update is called once per frame
    void Update()
    {  
        // Escape is pause key (once)
        if(Input.GetKeyDown(KeyCode.Escape)) {
            isPaused = !isPaused;

            pauseMenu.SetActive(isPaused);

            if(isPaused) {
                audioLowPassFilterTempValue = audioLowPassFilter.cutoffFrequency;
                audioLowPassFilter.cutoffFrequency = cutoffFrequency;

                Time.timeScale = 0f;
            } else {
                audioLowPassFilter.cutoffFrequency = audioLowPassFilterTempValue;

                Time.timeScale = 1f;
            }
        }
    }
}
