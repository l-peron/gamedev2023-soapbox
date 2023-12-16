using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsHandler : MonoBehaviour
{
    [SerializeField] GameObject[] checkpoints;
    [SerializeField] GameObject player;
    [SerializeField] ParticleSystem playerParticleSystem;
    [SerializeField] UIHandler UIHandler;
    [SerializeField] GameState gameState;
    [SerializeField] WinHandler winHandler;

    private int currentCheckpoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Reset player's position to be at first checkpoint
        ReloadCheckpoint();
        // Update UI for checkpoints
        UIHandler.setCheckpointCounter(this.currentCheckpoint, this.checkpoints.Length - 1);
        // Play particles
        playerParticleSystem.Play();
        // Print start
        StartCoroutine(UIHandler.printNotification("GO !"));
    }

    private void ReloadCheckpoint() {
        // Retrieve the last checkpoint's first child (which is the Respawn location)
        Transform checkpointRespawnLocation = checkpoints[currentCheckpoint].transform.GetChild(0).gameObject.transform;

        // Move the player to that location
        player.transform.position = checkpointRespawnLocation.position;

        // Reset player's rotation
        player.transform.rotation = checkpointRespawnLocation.rotation;

        // Cancel velocity
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // If 'R' key is pressed, return to last checkpoint
        // Also checking if player hasn't won already (skipping input)
        if(!gameState.getHasWon() && Input.GetKeyDown(KeyCode.R)) {
            ReloadCheckpoint();
        }
    }

    public void updateCheckpoint(GameObject checkpoint) {
        // Get the checkpoint's index
        int index = -1;

        for(int i = 0; i < checkpoints.Length; i++) {
            if(checkpoints[i] == checkpoint) {
                index = i;
                break;
            }
        }

        // Should throw an error
        if(index == -1) return;

        // Not updating anything
        if(index <= currentCheckpoint) return;
        
        Debug.Log($"Updating checkpoint : new checkpoint's index is {index} !");

        // Play particle explosion
        playerParticleSystem.Play();

        // Update the checkpoint index
        this.currentCheckpoint = index;

        UIHandler.setCheckpointCounter(this.currentCheckpoint, this.checkpoints.Length - 1);

        // Final checkpoint reached
        if(index == this.checkpoints.Length - 1) {
            Debug.Log("Player reached last checkpoint !");
            StartCoroutine(UIHandler.printNotification("RACE FINISHED !"));
            winHandler.win();
        } else {
            // Update UI
            StartCoroutine(UIHandler.printNotification("CHECKPOINT REACHED !"));
        }
    }
}
