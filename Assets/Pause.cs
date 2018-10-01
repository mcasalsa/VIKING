using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    public Canvas canvasPause;
    public bool pauseGame;
    // Use this for initialization
    void Start () {
        pauseGame = false;
        // canvasPause = GameObject.Find("CanvasPause");
        canvasPause = GetComponent<Canvas>();
        canvasPause.enabled=pauseGame;
    }

    // Update is called once per frame
    void Update () {
        // fem pausa del joc.
        if (Input.GetKeyDown("p"))
        {

            pauseGame = !pauseGame;
            canvasPause.enabled = pauseGame;
            // Time.timeScale regula la velocitat del joc, si es zero llavorsel joc està en pausa.
            // operador ternari ?, si val 0 la pausa esta desactivada i posarem 1 per activar-la i a la inversa.
            Time.timeScale = (pauseGame) ? 0f : 1f;
        }
    }
}
