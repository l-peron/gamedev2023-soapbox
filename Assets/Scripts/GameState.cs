using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private static bool hasWon = false;
    
    public void setHasWon(bool _hasWon) {
        hasWon = _hasWon;
    }

    public bool getHasWon() {
        return hasWon;
    }
}
