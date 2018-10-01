using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // cambi de escena.
    public void SceneChange(string scene)
    {
        switch (scene)
        {
            // partida nova.
            case "play":
                SceneManager.LoadScene("Phase_A");
                break;
            // sortir joc.
            case "exit":
                Application.Quit();
                break;
        }
    }
}
