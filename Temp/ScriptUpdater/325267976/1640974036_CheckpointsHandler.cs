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
        foreach(GameObject checkpoint in checkpoints) {
            Debug.Log("Yo");
        }
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
}
