using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsHandler : MonoBehaviour
{
    [SerializeField]
    public GameObject[] checkpoints;

    [SerializeField]
    public GameObject player;

    private int currentCheckpoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Reset player's position to be at first checkpoint
        ReloadCheckpoint();
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
        if(Input.GetKeyDown(KeyCode.R)) {
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

        // Update the checkpoint index
        this.currentCheckpoint = index;
    }
}
