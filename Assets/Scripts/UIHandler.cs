using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] Text chronoText;
    [SerializeField] Text checkpointReachedText;
    [SerializeField] Text checkpointsCounter;
    [SerializeField] GameState gameState;

    // Update is called once per frame
    void Update()
    {
        if(!gameState.getHasWon())
            updateChrono();
    }

    private IEnumerator FadeTo(float aValue, float aTime) {
        float alpha = checkpointReachedText.color.a;
        
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime) {
            Color newColor = checkpointReachedText.color;
            newColor.a = Mathf.Lerp(alpha, aValue, t);
            checkpointReachedText.color = newColor;
            yield return null;
        }

    }

    private void updateChrono() {
        float timeNow = Time.timeSinceLevelLoad;
        string timeToSeconds = timeNow.ToString("F1");

        chronoText.text = $"TIME : {timeToSeconds}S";
    }

    public IEnumerator printNotification(string text) {
        // Update the text
        checkpointReachedText.text = text;

        // Set alpha as 1 (opaque)
        Color newColor = checkpointReachedText.color;
        newColor.a = 1.0f;
        checkpointReachedText.color= newColor;

        // Wait for 1 seconds
        yield return new WaitForSeconds(1.0f);

        // Decrease the opacity to 0 within 2 seconds (transparent)
        StartCoroutine(FadeTo(0.0f, 2.0f));
    }

    public void setCheckpointCounter(int index, int max_index) {
        checkpointsCounter.text = $"CHECKPOINT : {index}/{max_index}";
    }
}
