using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveClearedHandler : MonoBehaviour
{
    [SerializeField] Canvas waveClearedCanvas;
    [SerializeField] TextMeshProUGUI waveClearedText;

    // Start is called before the first frame update
    void Start()
    {
        waveClearedCanvas.enabled = false;
    }

    public IEnumerator HandleWaveCleared(int wave)
    {
        waveClearedText.text = "Wave " + wave + " Cleared!";
        waveClearedCanvas.enabled = true;
        yield return new WaitForSeconds(3f);
        waveClearedCanvas.enabled = false;
    }

}
