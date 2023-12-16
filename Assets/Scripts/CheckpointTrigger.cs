using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    [SerializeField] CheckpointsHandler checkpointsHandler;

    //Upon collision with another Player, update checkpoint's index
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
			checkpointsHandler.updateCheckpoint(this.gameObject);
		}
    }
}
