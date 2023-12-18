using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WinHandler : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] GameState gameState;
    [SerializeField] GameObject winMenu;

    public void win() {
        // Unicity check
        if(gameState.getHasWon()) return;

        // Set the game state to won
        gameState.setHasWon(true);

        // Make the camera stops following the player (but keep looking at him)
        cinemachineVirtualCamera.Follow = null;

        // Show the win menu
        winMenu.SetActive(true);
    }
}
