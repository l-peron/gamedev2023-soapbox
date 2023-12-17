using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    [SerializeField] Rigidbody car; 
    [SerializeField] AudioSource drumLoop;

    public float speedThreshold = 2.5f;
    public float pitchFactor = .00001f;

    public float maxPitch = 1f;
    public float minPitch = .95f;

    private float currentPitch = 0f;
    
    void FixedUpdate() {
        float carSpeed = car.velocity.magnitude;

        // Car is stopped -> decrease pitch
        if(carSpeed < speedThreshold) 
            currentPitch = Mathf.Max(currentPitch - pitchFactor / Time.deltaTime, minPitch);
        // else slowly increase
        else
            currentPitch = Mathf.Min(currentPitch + pitchFactor / Time.deltaTime, maxPitch);

        drumLoop.pitch = currentPitch;
    }
}
